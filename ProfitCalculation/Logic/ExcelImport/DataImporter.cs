using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using ProfitCalculation.DataBase.Models;
using ProfitCalculation.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.ExcelImport
{
    internal class DataImporter: IDataImporter
    {

        private readonly ProfitCalculatingContext _dbContext;

        public DataImporter(ProfitCalculatingContext dbContext)
        {
            _dbContext = dbContext;
        }

        List<string> sheetOrder = new List<string> { "СПР_типов", "СПР_шифр", "СПР_Контрагентов", "СПР_валют", "СПР_цехов",
            "СПР_переделов", "СПР_догоовров", "СПР_EИ", "СПР_РКМ", "БазовРасценка", "РасценкаПеред",
            "СПР_заказов_шапка", "СПР_заказов_строка", };

        public delegate void ReadSheetData(SheetData sheetData, WorkbookPart workbookPart);

        private readonly Dictionary<string, ReadSheetData> _sheetReaders = new Dictionary<string, ReadSheetData>()
        {
            {"СПР_типов", SheetParser.ReadTypes},
            {"СПР_шифр", SheetParser.ReadCiphers},
            {"СПР_Контрагентов", SheetParser.ReadCounterparty},
            {"СПР_валют", SheetParser.ReadCurrency},
            {"СПР_цехов", SheetParser.ReadWorkshop},
            {"СПР_переделов", SheetParser.ReadConversions},
            {"СПР_догоовров", SheetParser.ReadContract},
            {"СПР_EИ", SheetParser.ReadUM},
            {"СПР_РКМ", SheetParser.ReadCalculationMaterials},
            {"БазовРасценка", SheetParser.ReadBasicPricing},
            {"РасценкаПеред", SheetParser.ReadConversionsPriсe},
            {"СПР_заказов_шапка", SheetParser.ReadOrdersHeader},
            {"СПР_заказов_строка", SheetParser.ReadOrdersDetails}
        };

        public void ExcelFileImporter(string filePath, ProgressImportForm progressBarForm)
        {
            DeleteAllDataInAllDbSets();
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(filePath, false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                IEnumerable<Sheet> sheets = workbookPart.Workbook.Descendants<Sheet>().OrderBy(s => sheetOrder.IndexOf(s.Name));
                int doneSheets = 0;
                foreach (Sheet sheet in sheets)
                {
                    string sheetName = sheet.Name;
                    SheetData sheetData = ((WorksheetPart)workbookPart.GetPartById(sheet.Id)).Worksheet.Elements<SheetData>().First();

                    if (_sheetReaders.ContainsKey(sheetName))
                    {
                        _sheetReaders[sheetName](sheetData, workbookPart);
                    }
                    else
                    {
                        Console.WriteLine($"Не удалось найти метод чтения данных для листа {sheetName}");
                    }
                    doneSheets++;
                    progressBarForm.UpdateProgress(doneSheets * 100 / sheets.Count());
                    Application.DoEvents();
                }
                progressBarForm.StopProgressReport();
            }
        }

        List<string> sheetOrderDB = new List<string> { "guide_Types", "guide_Cipher", "guide_Counterparty", "guide_Currency", "guide_Workshops",
            "guide_Conversions", "guide_Contracts", "guide_Units_Measurement", "guide_Calculation_Materials", "basic_Pricing", "Conversions_Price",
            "guide_Orders_header", "guide_Orders_details", "Result_Chains" };

        public void DeleteAllDataInAllDbSets()
        {
            using (var context = new ProfitCalculatingContext())
            {
                var tableNames = context.Model.GetEntityTypes()
                    .Select(t => t.GetTableName())
                    .Where(name => name != "__EFMigrationsHistory")
                    .ToList();

                foreach (var tableName in sheetOrderDB.Intersect(tableNames).Reverse())
                {
                    context.Database.ExecuteSqlRaw($"DELETE FROM {tableName}");
                }

                context.SaveChanges();
            }
        }
    }
}
