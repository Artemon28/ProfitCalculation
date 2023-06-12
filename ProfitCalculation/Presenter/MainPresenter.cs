using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProfitCalculation.DataBase.Models;
using ProfitCalculation.Logic.Chains.Models;
using ProfitCalculation.Logic.Chains.Repository;
using ProfitCalculation.Logic.Chains.Service;
using ProfitCalculation.Logic.ExcelImport;
using ProfitCalculation.Logic.Handlings.Repositories;
using ProfitCalculation.Logic.Handlings.Services;
using ProfitCalculation.Logic.Materials.Repositories;
using ProfitCalculation.Logic.Materials.Services;
using ProfitCalculation.Logic.OrderRealizer.Services;
using ProfitCalculation.Logic.Orders.Repositories;
using ProfitCalculation.Logic.Orders.Services;
using ProfitCalculation.UI;
using ProfitCalculation.UI.Interfaces;


namespace ProfitCalculation.Presenter
{
    public class MainPresenter
    {
        private MainView mainView;

        public MainPresenter(MainView mainView)
        {
            this.mainView = mainView;
            //this.mainView.ShowImportView += ShowImportView;
            //this.mainView.ShowCalculateView += ShowCalcView;
            this.mainView.ShowCalculateView += LoadDataBase; ;
        }

        public static ServiceCollection services;

        public void LoadDataBase(object sender, EventArgs e)
        {
            services = new ServiceCollection();

            services.AddDbContext<ProfitCalculatingContext>(options =>
                options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=ProfitCalculating;Trusted_Connection=True;"));
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IMaterialRepository, MaterialRepository>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddTransient<IHandlingRepository, HandlingRepository>();
            services.AddTransient<IHandlingService, HandlingService>();
            services.AddTransient<IChainRepository, ChainRepository>();
            services.AddTransient<IChainService, ChainService>();
            services.AddTransient<IRealizerServise, RealizerService>();
            services.AddSingleton<OrderMapperUtility>();
            services.AddSingleton<MaterialMapperUtility>();
            services.AddSingleton<HandlingMapperUtility>();
            services.AddTransient<IDataImporter, DataImporter>();
        }
    }
}
