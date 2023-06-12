using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ProfitCalculation.Logic.Chains.Models;
using ProfitCalculation.Logic.Materials.Models;
using ProfitCalculation.Logic.OrderRealizer.Models;
using ProfitCalculation.Logic.Orders.Models;
using ProfitCalculation.UI;

namespace ProfitCalculation.Logic.OrderRealizer.Services
{
    internal class RealizerService : IRealizerServise
    {
        public RealizerService()
        {
        }

        private List<OrderDetail> GetDeatails(List<Order> orders, DateTime startDate, DateTime endDate)
        {
            var ordersDetailed = new List<OrderDetail>();
            foreach (Order order in orders)
            {
                ordersDetailed.AddRange(order.OrderDetails);
            }
            ordersDetailed = ordersDetailed.Where(m => m.DeliveryDate >= startDate && m.DeliveryDate <= endDate)
                .OrderBy(m => m.DeliveryDate)
                .ThenByDescending(m => m.Price)
                .ToList();
            return ordersDetailed;
        }

        public (List<Portfol>, decimal) RealizeOrdersByLowestCost(List<Order> orders, List<Chain> chains, 
            DateTime startDate, DateTime endDate, ProgressImportForm progressBarForm, List<Material> materials)
        {
            progressBarForm.RenameBar("Расчет заказов");
            progressBarForm.UpdateProgress(0);
            Application.DoEvents();
            var portfol = new List<Portfol>();
            var ordersDetailed = GetDeatails(orders, startDate, endDate);
            int qty = 0;
            foreach (OrderDetail detail in ordersDetailed)
            {
                qty++;
                progressBarForm.UpdateProgress(qty * 100 / ordersDetailed.Count());
                Application.DoEvents();
                var options = chains
                    .Select((chain, index) => new { Chain = chain, Index = index })
                    .Where(m => m.Chain.ReleaseId == detail.CipherId && m.Chain.Remain >= detail.Amount)
                    .OrderBy(m => m.Chain.Price)
                    .ToList();

                int originalIndex = chains.IndexOf(options.First().Chain);
                if (options.Count <= 0)
                {
                    throw new Exception($"We can't realize an order {detail.CipherId}");
                }
                portfol.Add(new Portfol(detail, (long)options[0].Chain.BaseMaterialId,
                    options[0].Chain.Price * detail.Amount));
                chains[originalIndex].Distribute += detail.Amount;
                RecalculateChains(chains, options[0].Chain.BaseMaterialId, (decimal)(detail.Amount * options[0].Chain.ThroughFlowRatio));
            }
            var profit = CalculateRemainsByLowestCost(chains, materials, progressBarForm);
            return (portfol, (decimal)profit);
        }

        private decimal CalculateRemainsByLowestCost(List<Chain> chains, List<Material> materials, ProgressImportForm progressBarForm)
        {
            progressBarForm.RenameBar("Оценка остатков на складе");
            progressBarForm.UpdateProgress(0);
            Application.DoEvents();
            int qty = 0;
            decimal profit = 0;
            foreach (Chain chain in chains)
            {
                qty++;
                progressBarForm.UpdateProgress(qty * 100 / chains.Count());
                Application.DoEvents();
                if (chain.Remain < 0.01m)
                {
                    continue;
                }
                var options = chains
                    .Select((chain, index) => new { Chain = chain, Index = index })
                    .Where(m => m.Chain.BaseMaterialId == chain.BaseMaterialId && isFinal(m.Chain.ReleaseId, materials))
                    .OrderBy(m => m.Chain.Price)
                    .ToList();
                if (options.Count() <= 0)
                {
                    continue;
                }
                int originalIndex = chains.IndexOf(options.First().Chain);
                    
                chains[originalIndex].Distribute += chains[originalIndex].Remain;
                profit += (decimal)((materials.Where(m => m.Id == chains[originalIndex].ReleaseId).ToList()[0].Price - chains[originalIndex].Price)
                    * chains[originalIndex].Remain);
                RecalculateChains(chains, options[0].Chain.BaseMaterialId, (decimal)(chains[originalIndex].Remain * options[0].Chain.ThroughFlowRatio));
            }
            return profit;
        }

        private bool isFinal(long? id, List<Material> materials)
        {
            if (id == null)
            {
                return false;
            }
            return materials.Where(m => m.Id == id).ToList()[0].IsFinalProduct();
        }

        private void RecalculateChains(List<Chain> chains, long? BaseId, decimal orderAmount)
        {
            var materialId = chains.FindIndex(m => m.ReleaseId == BaseId && m.ReleaseId == m.BaseMaterialId);
            chains[materialId].Remain -= orderAmount;
            for (int i = materialId + 1; i < chains.Count() && chains[i].BaseMaterialId == BaseId; i++)
            {
                chains[i].Remain = (decimal)(chains[materialId].Remain / chains[i].ThroughFlowRatio);
            }
        }

        public List<Portfol> RealizeOrdersByLeastHandlings(List<Order> orders, List<Chain> chains,
            DateTime startDate, DateTime endDate, ProgressImportForm progressBarForm, List<Material> materials)
        {
            progressBarForm.RenameBar("Расчет заказов");
            Application.DoEvents();
            var portfol = new List<Portfol>();
            var ordersDetailed = GetDeatails(orders, startDate, endDate);
            int qty = 0;
            foreach (OrderDetail detail in ordersDetailed)
            {
                var options = chains
                    .Select((chain, index) => new { Chain = chain, Index = index })
                    .Where(m => m.Chain.ReleaseId == detail.CipherId && m.Chain.Remain >= detail.Amount)
                    .OrderBy(m => m.Chain.Price)
                    .ToList();

                int originalIndex = chains.IndexOf(options.First().Chain);
                if (options.Count <= 0)
                {
                    throw new Exception($"We can't realize an order {detail.CipherId}");
                }
                portfol.Add(new Portfol(detail, (long)options[0].Chain.BaseMaterialId,
                    options[0].Chain.Price * detail.Amount));
                chains[originalIndex].Distribute += detail.Amount;
                RecalculateChains(chains, options[0].Chain.BaseMaterialId, (decimal)(detail.Amount / options[0].Chain.ThroughFlowRatio));
                qty++;
                progressBarForm.UpdateProgress(qty * 100 / ordersDetailed.Count());
                Application.DoEvents();
            }
            return portfol;
        }


        private void CalculateRemainsByLeastHandlings(List<Chain> chains)
        {

        }


        public decimal CalculateProfit(List<Portfol> portfol)
        {
            decimal profit = 0;
            foreach(Portfol order in portfol)
            {
                profit = order.detail.Price - order.endCost;
            }
            return profit;
        }


        public void SaveChainsExcel(List<Chain> chains, string fileName)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();
                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Chains" };
                sheets.Append(sheet);
                Row headerRow = new Row();
                headerRow.Append(CreateTextCell("ConversionId"));
                headerRow.Append(CreateTextCell("ReleaseId"));
                headerRow.Append(CreateTextCell("CreatedForId"));
                headerRow.Append(CreateTextCell("BaseMaterialId"));
                headerRow.Append(CreateTextCell("Step"));
                headerRow.Append(CreateTextCell("ExpenseRatio"));
                headerRow.Append(CreateTextCell("ThroughFlowRatio"));
                headerRow.Append(CreateTextCell("Amount"));
                headerRow.Append(CreateTextCell("Distribute"));
                headerRow.Append(CreateTextCell("Remain"));
                headerRow.Append(CreateTextCell("Price"));
                headerRow.Append(CreateTextCell("Wastes"));
                headerRow.Append(CreateTextCell("addExpenses"));
                headerRow.Append(CreateTextCell("CostPrice"));
                headerRow.Append(CreateTextCell("EndCostPrice"));
                sheetData.AppendChild(headerRow);
                foreach (var chain in chains)
                {
                    Row row = new Row();
                    row.Append(CreateIntCell(chain.ConversionId ?? 0));
                    row.Append(CreateDecimalCell(chain.ReleaseId));
                    row.Append(CreateDecimalCell(chain.CreatedForId ?? 0));
                    row.Append(CreateDecimalCell(chain.BaseMaterialId ?? 0));
                    row.Append(CreateIntCell(chain.Step));
                    row.Append(CreateDecimalCell(chain.ExpenseRatio ?? 0));
                    row.Append(CreateDecimalCell(chain.ThroughFlowRatio ?? 0));
                    row.Append(CreateDecimalCell(chain.Amount));
                    row.Append(CreateDecimalCell(chain.Distribute));
                    row.Append(CreateDecimalCell(chain.Remain));
                    row.Append(CreateDecimalCell(chain.Price));
                    row.Append(CreateDecimalCell(chain.Wastes));
                    row.Append(CreateDecimalCell(chain.addExpenses));
                    row.Append(CreateDecimalCell(chain.CostPrice));
                    row.Append(CreateDecimalCell(chain.EndCostPrice));
                    sheetData.AppendChild(row);
                }

                worksheetPart.Worksheet.Save();
            }
        }

        private Cell CreateTextCell(string value)
        {
            var inlineString = new InlineString(new Text(value));
            var cell = new Cell(inlineString);
            cell.DataType = new EnumValue<CellValues>(CellValues.InlineString);
            return cell;
        }

        private Cell CreateIntCell(int value)
        {
            return new Cell { DataType = CellValues.Number, CellValue = new CellValue(value) };
        }
        private Cell CreateDecimalCell(decimal value)
        {
            return new Cell { DataType = CellValues.Number, CellValue = new CellValue(value) };
        }
    }
}
