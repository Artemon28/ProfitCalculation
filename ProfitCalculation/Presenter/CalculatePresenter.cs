using Microsoft.Extensions.DependencyInjection;
using ProfitCalculation.DataBase.Models;
using ProfitCalculation.Logic.Chains.Models;
using ProfitCalculation.Logic.Chains.Repository;
using ProfitCalculation.Logic.Chains.Service;
using ProfitCalculation.Logic.Handlings.Repositories;
using ProfitCalculation.Logic.Materials.Repositories;
using ProfitCalculation.Logic.OrderRealizer.Models;
using ProfitCalculation.Logic.OrderRealizer.Services;
using ProfitCalculation.Logic.Orders.Repositories;
using ProfitCalculation.UI;

namespace ProfitCalculation.Presenter
{
    internal class CalculatePresenter
    {
        private CalcView calcView;

        public CalculatePresenter(CalcView calcView)
        {
            this.calcView = calcView;
            this.calcView.CalculateProfit += CalculateProfit;
        }

        internal HandlingRepository HandlingRepository
        {
            get => default;
            set
            {
            }
        }

        internal MaterialRepository MaterialRepository
        {
            get => default;
            set
            {
            }
        }

        internal OrderRepository OrderRepository
        {
            get => default;
            set
            {
            }
        }

        internal ChainRepository ChainRepository
        {
            get => default;
            set
            {
            }
        }

        internal ChainService ChainService
        {
            get => default;
            set
            {
            }
        }

        internal RealizerService RealizerService
        {
            get => default;
            set
            {
            }
        }

        private void CalculateProfit(object sender, EventArgs e)
        {
            if (!calcView.Get_radioButton1() && !calcView.Get_radioButton2())
            {
                calcView.SetWarning("Please select a radio button.");
                return;
            }

            DateTime startDate = calcView.GetDateTime1().Date;
            DateTime endDate = calcView.GetDateTime2().Date;
            if (startDate == null || endDate == null)
            {
                calcView.SetWarning("Please select both start and end dates.");
                return;
            }
            if (startDate >= endDate)
            {
                calcView.SetWarning("End date must be later than start date.");
                return;
            }
            calcView.DeleteWarning();
            bool choice = calcView.Get_radioButton1() ? true : false;
            Calculate(choice, startDate, endDate);
        }

        private void Calculate(bool choice, DateTime startDate, DateTime endDate)
        {
            var progressBarForm = new ProgressImportForm();
            progressBarForm.ControlBox = false;
            progressBarForm.RenameBar("Составление цепочек");
            progressBarForm.Show();
            Application.DoEvents();
            var serviceProvider = MainPresenter.services.BuildServiceProvider();

            var orderRepository = serviceProvider.GetService<IOrderRepository>();
            var materialRepository = serviceProvider.GetService<IMaterialRepository>();
            var handlingRepository = serviceProvider.GetService<IHandlingRepository>();
            var chainService = serviceProvider.GetService<IChainService>();
            var chainRepository = serviceProvider.GetService<IChainRepository>();
            var realizer = serviceProvider.GetService<IRealizerServise>();

            var orders = orderRepository.GetAllOrders();
            var materials = materialRepository.GetAllMaterials();
            var handlings = handlingRepository.GetAllHandlings();

            List<Chain> chains = chainService.MakeChains(materials, handlings, progressBarForm);
            chainRepository.SaveChains<ResultChain>(chains);
            List<Portfol> port;
            decimal prof = 0;
            if (choice)
            {
                (port, prof) = realizer.RealizeOrdersByLowestCost(orders, chains, startDate, endDate, progressBarForm, materials);
            } else
            {
                port = realizer.RealizeOrdersByLeastHandlings(orders, chains, startDate, endDate, progressBarForm, materials);
            }

            var profit = realizer.CalculateProfit(port);
            progressBarForm.StopProgressReport();

            calcView.OpenResults(chains, port, profit + prof);

        }
    }
}
