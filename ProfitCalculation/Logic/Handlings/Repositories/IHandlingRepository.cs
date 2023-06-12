using ProfitCalculation.Logic.Handlings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Handlings.Repositories
{
    internal interface IHandlingRepository
    {
        List<Handling> GetAllHandlings();

        Dictionary<long, Expenses> GetAllExpenses();
        Expenses? GetExpensesById(long id);

        ConversionExpenses GetconversionExpensesById(long id);
    }
}
