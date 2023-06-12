using ProfitCalculation.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.ExcelImport
{
    internal interface IDataImporter
    {
        void ExcelFileImporter(string filePath, ProgressImportForm progressBarForm);
    }
}
