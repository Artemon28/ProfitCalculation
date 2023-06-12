using ProfitCalculation.Logic.Handlings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.Handlings.Services
{
    internal interface IHandlingService
    {
        decimal CalculateExpenses(long CipherId, int ConversionId);
        decimal GetWastes(long CipherId);
        List<Handling> GetAllHandlings();
    }
}
