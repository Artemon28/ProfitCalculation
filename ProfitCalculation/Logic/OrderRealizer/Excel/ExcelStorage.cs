using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfitCalculation.DataBase.Models;
using ProfitCalculation.Logic.Chains.Models;

namespace ProfitCalculation.Logic.OrderRealizer.Excel
{
    internal class ExcelStorage
    {
        //public void SaveChainsExcel(List<Chain> chains)
        //{
        //    var package = new ExcelPackage();
        //    var worksheet = package.Workbook.Worksheets.Add("Chains");

        //    // Set the headers for the table
        //    worksheet.Cells[1, 1].Value = "Conversion ID";
        //    worksheet.Cells[1, 2].Value = "Release ID";
        //    worksheet.Cells[1, 3].Value = "Created For ID";
        //    worksheet.Cells[1, 4].Value = "Base Material ID";
        //    worksheet.Cells[1, 5].Value = "Step";
        //    worksheet.Cells[1, 6].Value = "Expense Ratio";
        //    worksheet.Cells[1, 7].Value = "ThroughFlow Ratio";
        //    worksheet.Cells[1, 8].Value = "Amount";
        //    worksheet.Cells[1, 9].Value = "Price";
        //    worksheet.Cells[1, 10].Value = "Wastes";
        //    worksheet.Cells[1, 11].Value = "Add Expenses";
        //    worksheet.Cells[1, 12].Value = "Cost Price";
        //    worksheet.Cells[1, 13].Value = "End Cost Price";

        //    // Fill the table with data from the list of Chain objects
        //    int row = 2;
        //    foreach (Chain chain in chains)
        //    {
        //        worksheet.Cells[row, 1].Value = chain.ConversionId;
        //        worksheet.Cells[row, 2].Value = chain.ReleaseId;
        //        worksheet.Cells[row, 3].Value = chain.CreatedForId;
        //        worksheet.Cells[row, 4].Value = chain.BaseMaterialId;
        //        worksheet.Cells[row, 5].Value = chain.Step;
        //        worksheet.Cells[row, 6].Value = chain.ExpenseRatio;
        //        worksheet.Cells[row, 7].Value = chain.ThroughFlowRatio;
        //        worksheet.Cells[row, 8].Value = chain.Amount;
        //        worksheet.Cells[row, 9].Value = chain.Price;
        //        worksheet.Cells[row, 10].Value = chain.Wastes;
        //        worksheet.Cells[row, 11].Value = chain.addExpenses;
        //        worksheet.Cells[row, 12].Value = chain.CostPrice;
        //        worksheet.Cells[row, 13].Value = chain.EndCostPrice;
        //        row++;
        //    }

        //    // Save the Excel workbook to a file
        //    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ChainData.xlsx");
        //    FileInfo excelFile = new FileInfo(filePath);
        //    package.SaveAs(excelFile);
        //}
        
    }
}
