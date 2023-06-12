using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.UI.Interfaces
{
    public interface IMainView
    {
        event EventHandler ShowImportView;
        event EventHandler ShowCalculateView;
    }
}
