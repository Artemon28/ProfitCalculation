using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ProfitCalculation.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculation.Logic.ExcelImport
{
    internal static class SheetParser
    {
        public static void ReadTypes(SheetData sheetData, WorkbookPart workbookPart)
        {
            var guideTypes = new List<GuideType>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 3) continue;
                var id = int.Parse(cells[0].CellValue.InnerText);
                var typeShort = GetCellText(cells[1], workbookPart);
                var  typeName = GetCellText(cells[2], workbookPart);   
                var guideType = new GuideType
                {
                    TypeName = typeName,
                    TypeShort = typeShort,
                    Id = id
                };

                guideTypes.Add(guideType);
            }
            using (var context = new ProfitCalculatingContext())
            {
                if (context.GuideTypes.Count() > 0)
                {
                    context.GuideTypes.UpdateRange(guideTypes);
                }
                else
                {
                    context.GuideTypes.AddRange(guideTypes);
                }
                context.SaveChanges();
            }
        }
        public static void ReadCiphers(SheetData sheetData, WorkbookPart workbookPart)
        {
            var guideCiphers = new List<GuideCipher>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 4) continue;
                var id = long.Parse(cells[0].CellValue.InnerText);
                var cipher = long.Parse(cells[1].CellValue.InnerText);
                var name = GetCellText(cells[2], workbookPart);
                var typeId = int.Parse(cells[3].CellValue.InnerText);
                var amount = cells[4].CellValue.InnerText == "" ? null : (decimal?)Math.Round(decimal.Parse(cells[4].CellValue.InnerText, NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture), 6);
                var price = cells[5].CellValue.InnerText == "" ? null : (decimal?)Math.Round(decimal.Parse(cells[5].CellValue.InnerText, NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture), 6);
                var guideCipher = new GuideCipher
                {
                    Id = id,
                    Code = cipher,
                    CipherName = name,
                    TypeId = typeId,
                    Amount = amount,
                    Price = price,
                };

                guideCiphers.Add(guideCipher);
            }
            using (var context = new ProfitCalculatingContext())
            {

                if (context.GuideCiphers.Count() > 0)
                {
                    context.GuideCiphers.UpdateRange(guideCiphers);
                } else
                {
                    context.GuideCiphers.AddRange(guideCiphers);
                }
                context.SaveChanges();
            }
        }

        public static void ReadCounterparty(SheetData sheetData, WorkbookPart workbookPart)
        {
            var guideCounterparties = new List<GuideCounterparty>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 3) continue;
                var id = int.Parse(cells[0].CellValue.InnerText);
                var code = int.Parse(cells[1].CellValue.InnerText);
                var name = GetCellText(cells[2], workbookPart);
                var guideCounterparty = new GuideCounterparty
                {
                    Id = id,
                    Code = code,
                    Name = name
                };

                guideCounterparties.Add(guideCounterparty);
            }

            using (var context = new ProfitCalculatingContext())
            {
                if (context.GuideCounterparties.Count() > 0)
                {
                    context.GuideCounterparties.UpdateRange(guideCounterparties);
                } else
                {
                    context.GuideCounterparties.AddRange(guideCounterparties);
                }
                context.SaveChanges();
            }
        }

        public static void ReadCurrency(SheetData sheetData, WorkbookPart workbookPart)
        {
            var guideCurrencies = new List<GuideCurrency>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 4) continue;
                var id = int.Parse(cells[0].CellValue.InnerText);
                var name = GetCellText(cells[1], workbookPart);
                var shortName = GetCellText(cells[2], workbookPart);
                var exchange = decimal.Parse(cells[3].CellValue.InnerText, CultureInfo.InvariantCulture);
                var guideCurrency = new GuideCurrency
                {
                    Id = id,
                    Name = name,
                    ShortName = shortName,
                    Exchange = exchange
                };

                guideCurrencies.Add(guideCurrency);
            }
            using (var context = new ProfitCalculatingContext())
            {
                if (context.GuideCurrencies.Count() > 0)
                {
                    context.GuideCurrencies.UpdateRange(guideCurrencies);
                } else
                {
                    context.GuideCurrencies.AddRange(guideCurrencies);
                }
                context.SaveChanges();
            }
        }

        public static void ReadWorkshop(SheetData sheetData, WorkbookPart workbookPart)
        {
            var guideWorkshops = new List<GuideWorkshop>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 3) continue;
                var id = int.Parse(cells[0].CellValue.InnerText);
                var code = int.Parse(cells[1].CellValue.InnerText);
                var workshopName = GetCellText(cells[2], workbookPart);
                var guideWorkshop = new GuideWorkshop
                {
                    Id = id,
                    Code = code,
                    WorkshopName = workshopName,
                };
                guideWorkshops.Add(guideWorkshop);
            }
            using (var context = new ProfitCalculatingContext())
            {
                if (context.GuideWorkshops.Count() > 0)
                {
                    context.GuideWorkshops.UpdateRange(guideWorkshops);
                } else
                {
                    context.GuideWorkshops.AddRange(guideWorkshops);
                }
                context.SaveChanges();
            }
        }

        public static void ReadConversions(SheetData sheetData, WorkbookPart workbookPart)
        {
            var guideConversions = new List<GuideConversion>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 4) continue;
                var id = int.Parse(cells[0].CellValue.InnerText);
                var code = int.Parse(cells[1].CellValue.InnerText);
                var name = GetCellText(cells[2], workbookPart);
                var workshopId = int.Parse(cells[3].CellValue.InnerText);

                var guideConversion = new GuideConversion
                {
                    Id = id,
                    Code = code,
                    ConversionName = name,
                    WorkshopId = workshopId
                };

                guideConversions.Add(guideConversion);
            }

            using (var context = new ProfitCalculatingContext())
            {
                if (context.GuideConversions.Count() > 0)
                {
                    context.GuideConversions.UpdateRange(guideConversions);
                } else
                {
                    context.GuideConversions.AddRange(guideConversions);
                }
                context.SaveChanges();
            }
        }

        public static void ReadContract(SheetData sheetData, WorkbookPart workbookPart)
        {
            var guideContracts = new List<GuideContract>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 4) continue;
                var id = int.Parse(cells[0].CellValue.InnerText);
                var number = int.Parse(cells[1].CellValue.InnerText);
                var year = int.Parse(cells[2].CellValue.InnerText);
                var counterpartyId = int.Parse(cells[3].CellValue.InnerText);
                var guideContract = new GuideContract
                {
                    Id = id,
                    Number = number,
                    Year = year,
                    СounterpartyId = counterpartyId,
                };

                guideContracts.Add(guideContract);
            }
            using (var context = new ProfitCalculatingContext())
            {
                if (context.GuideContracts.Count() > 0)
                {
                    context.GuideContracts.UpdateRange(guideContracts);
                }
                else
                {
                    context.GuideContracts.AddRange(guideContracts);
                }
                context.SaveChanges();
            }
        }

        public static void ReadUM(SheetData sheetData, WorkbookPart workbookPart)
        {
            var guideUnits = new List<GuideUnitsMeasurement>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 3) continue;
                var id = int.Parse(cells[0].CellValue.InnerText);
                var shortName = GetCellText(cells[1], workbookPart);
                var name = GetCellText(cells[2], workbookPart);

                var guideUnit = new GuideUnitsMeasurement
                {
                    Id = id,
                    ShortName = shortName,
                    Name = name,
                };

                guideUnits.Add(guideUnit);
            }

            using (var context = new ProfitCalculatingContext())
            {
                if (context.GuideUnitsMeasurements.Count() > 0)
                {
                    context.GuideUnitsMeasurements.UpdateRange(guideUnits);
                } else
                {
                    context.GuideUnitsMeasurements.AddRange(guideUnits);
                }
                context.SaveChanges();
            }
        }

        public static void ReadCalculationMaterials(SheetData sheetData, WorkbookPart workbookPart)
        {
            var guideCalculationMaterials = new List<GuideCalculationMaterial>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 3) continue;
                var mainSign = cells[0].CellValue.InnerText == "" ? null : (int?)int.Parse(cells[0].CellValue.InnerText);
                var conversionId = cells[1].CellValue.InnerText == "" ? null : (int?)int.Parse(cells[1].CellValue.InnerText);
                var releaseId = long.Parse(cells[2].CellValue.InnerText);
                long? createdForId = null;
                decimal? laborIntensityRatio = null;
                decimal? expenseRatio = null;
                if (cells.Count > 3 && cells[3].CellValue.InnerText != "")
                {
                    createdForId = long.Parse(cells[3].CellValue.InnerText);
                }
                if (cells.Count > 4 && cells[4].CellValue.InnerText != "")
                {
                    expenseRatio = Math.Round(decimal.Parse(cells[4].CellValue.InnerText, NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture), 6);
                }
                if (cells.Count > 5 && cells[5].CellValue.InnerText != "")
                {
                    laborIntensityRatio = Math.Round(decimal.Parse(cells[5].CellValue.InnerText, NumberStyles.AllowExponent | NumberStyles.Float, CultureInfo.InvariantCulture), 6);
                }
                var guideCalculationMaterial = new GuideCalculationMaterial
                {
                    MainSign = mainSign,
                    ConversionId = conversionId,
                    ReleaseId = releaseId,
                    CreatedForId = createdForId,
                    ExpenseRatio = expenseRatio,
                    LaborIntensityRatio = laborIntensityRatio,
                };
                guideCalculationMaterials.Add(guideCalculationMaterial);
            }

            using (var context = new ProfitCalculatingContext())
            {
                if (context.GuideCalculationMaterials.Count() > 0)
                {
                    context.GuideCalculationMaterials.UpdateRange(guideCalculationMaterials);
                }
                else
                {
                    context.GuideCalculationMaterials.AddRange(guideCalculationMaterials);
                }
                context.SaveChanges();
            }
        }

        public static void ReadBasicPricing(SheetData sheetData, WorkbookPart workbookPart)
        {
            var basicPricingList = new List<BasicPricing>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 2) continue;
                if (cells[0].CellValue == null)
                {
                    continue;
                }
                var conversionId = cells[0].CellValue.InnerText == "" ? null : (int?)int.Parse(cells[0].CellValue.InnerText);
                var cipherId = long.Parse(cells[1].CellValue.InnerText);
                decimal? wastes = null;
                decimal? auxiliaryAdditionalExpenses = null;
                decimal? specialTreatment = null;
                decimal? salary = null;
                decimal? socialInsurance = null;
                if (cells.Count > 2 && cells[2].CellValue.InnerText != "")
                {
                    wastes = decimal.Parse(cells[2].CellValue.InnerText, CultureInfo.InvariantCulture);
                }
                if (cells.Count > 3 && cells[3].CellValue.InnerText != "")
                {
                    auxiliaryAdditionalExpenses = decimal.Parse(cells[3].CellValue.InnerText, CultureInfo.InvariantCulture);
                }
                if (cells.Count > 4 && cells[4].CellValue.InnerText != "")
                {
                    specialTreatment = decimal.Parse(cells[4].CellValue.InnerText, CultureInfo.InvariantCulture);
                }
                if (cells.Count > 5 && cells[5].CellValue.InnerText != "")
                {
                    salary = decimal.Parse(cells[5].CellValue.InnerText, CultureInfo.InvariantCulture);
                }
                if (cells.Count > 6 && cells[6].CellValue.InnerText != "")
                {
                    socialInsurance = decimal.Parse(cells[6].CellValue.InnerText, CultureInfo.InvariantCulture);
                }
                
                var basicPricing = new BasicPricing
                {
                    ConversionId = conversionId,
                    CipherId = cipherId,
                    Wastes = wastes,
                    AuxiliaryAdditionalExpenses = auxiliaryAdditionalExpenses,
                    SpecialTreatment = specialTreatment,
                    Salary = salary,
                    SocialInsurance = socialInsurance
                };

                basicPricingList.Add(basicPricing);
            }

            using (var context = new ProfitCalculatingContext())
            {
                foreach (var g in basicPricingList)
                {
                    var check = context.BasicPricings.Find(g.CipherId);
                    if (check != null)
                    {
                        context.BasicPricings.Remove(check);
                        //context.BasicPricings.UpdateRange(g);
                    } //else
                    //{
                    //    context.BasicPricings.Add(g);
                    //}
                    context.BasicPricings.Add(g);
                    context.SaveChanges();
                }
                //if (context.BasicPricings.Count() > 0)
                //{
                //    context.BasicPricings.UpdateRange(basicPricingList);
                //}
                //else
                //{
                //    context.BasicPricings.AddRange(basicPricingList);
                //}
                //context.SaveChanges();
            }
        }

        public static void ReadConversionsPriсe(SheetData sheetData, WorkbookPart workbookPart)
        {
            var conversionsPrices = new List<ConversionsPrice>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 2) continue;
                var conversionsId = int.Parse(cells[0].CellValue.InnerText);
                var avgPrice = decimal.Parse(cells[1].CellValue.InnerText, CultureInfo.InvariantCulture);

                var conversionsPrice = new ConversionsPrice
                {
                    ConversionsId = conversionsId,
                    AvgPrice = avgPrice
                };

                conversionsPrices.Add(conversionsPrice);
            }

            using (var context = new ProfitCalculatingContext())
            {
                if (context.ConversionsPrices.Count() > 0)
                {
                    context.ConversionsPrices.UpdateRange(conversionsPrices);
                } else
                {
                    context.ConversionsPrices.AddRange(conversionsPrices);
                }
                context.SaveChanges();
            }
        }
        public static void ReadOrdersHeader(SheetData sheetData, WorkbookPart workbookPart)
        {
            var ordersHeaders = new List<GuideOrdersHeader>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 5) continue;
                if (cells[0].CellValue == null)
                {
                    continue;
                }
                var id = int.Parse(cells[0].CellValue.InnerText);
                var number = int.Parse(cells[1].CellValue.InnerText);
                var year = int.Parse(cells[2].CellValue.InnerText);
                var contractId = int.Parse(cells[3].CellValue.InnerText);
                var cargoRecipientId = int.Parse(cells[4].CellValue.InnerText);
                var payerId = int.Parse(cells[5].CellValue.InnerText);

                var ordersHeader = new GuideOrdersHeader
                {
                    Id = id,
                    Number = number,
                    Year = year,
                    ContractId = contractId,
                    CargoRecipientId = cargoRecipientId,
                    PayerId = payerId,
                };

                ordersHeaders.Add(ordersHeader);
            }

            using (var context = new ProfitCalculatingContext())
            {
                if (context.GuideOrdersHeaders.Count() > 0)
                {
                    context.GuideOrdersHeaders.UpdateRange(ordersHeaders);
                } else
                {
                    context.GuideOrdersHeaders.AddRange(ordersHeaders);
                }
                context.SaveChanges();
            }
        }

        public static void ReadOrdersDetails(SheetData sheetData, WorkbookPart workbookPart)
        {
            var guideOrdersDetails = new List<GuideOrdersDetail>();
            var rows = sheetData.Descendants<Row>();
            foreach (var row in rows.Skip(1))
            {
                var cells = row.Descendants<Cell>().ToList();
                if (cells.Count < 9) continue;
                if (cells[0].CellValue == null)
                {
                    continue;
                }
                int id = int.Parse(cells[0].CellValue.InnerText);
                int headerId = int.Parse(cells[1].CellValue.InnerText);
                var cipherId = long.Parse(cells[2].CellValue.InnerText);
                var unitsMeasurementId = int.Parse(cells[3].CellValue.InnerText);
                var specifications = GetCellText(cells[4], workbookPart);
                var amount = int.Parse(cells[5].CellValue.InnerText);
                var price = decimal.Parse(cells[6].CellValue.InnerText, CultureInfo.InvariantCulture);
                var currencyId = int.Parse(cells[7].CellValue.InnerText);
                var deliveryDate = DateTime.FromOADate(double.Parse(cells[8].CellValue.InnerText));

                var guideOrdersDetail = new GuideOrdersDetail
                {
                    Id = id,
                    HeaderId = headerId,
                    CipherId = cipherId,
                    UnitsMeasurementId = unitsMeasurementId,
                    Specifications = specifications,
                    Amount = amount,
                    Price = price,
                    CurrencyId = currencyId,
                    DeliveryDate = deliveryDate,
                };

                guideOrdersDetails.Add(guideOrdersDetail);
            }

            using (var context = new ProfitCalculatingContext())
            {
                if (context.GuideOrdersDetails.Count() > 0)
                {
                    context.GuideOrdersDetails.UpdateRange(guideOrdersDetails);
                } else
                {
                    context.GuideOrdersDetails.AddRange(guideOrdersDetails);
                }
                context.SaveChanges();
            }
        }   

        private static string GetCellText(Cell c, WorkbookPart workbookPart)
        {
            string val = "";

            if ((c.DataType != null) && (c.DataType == CellValues.SharedString))
            {
                int ssid;
                if (int.TryParse(c.CellValue.Text, out ssid))
                {
                    SharedStringTablePart sharedStringTablePart = workbookPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                    if (sharedStringTablePart != null)
                    {
                        SharedStringTable sharedStringTable = sharedStringTablePart.SharedStringTable;
                        if (ssid >= 0 && ssid < sharedStringTable.Count())
                        {
                            val = sharedStringTable.ElementAt(ssid).InnerText;
                        }
                    }
                }
            }
            else if ((c.DataType != null) && c.DataType == CellValues.InlineString)
            {
                val = c.InnerText;
            }
            else if (c.CellValue != null)
            {
                val = c.CellValue.Text;
            }

            if (val == null)
                val = "";

            return val;
        }

        public static string GetCellValueAsDate(Cell cell, WorkbookPart workbookPart)
        {
            string cellValue = cell.InnerText;
            if (cell.DataType != null && cell.DataType == CellValues.Number)
            {
                if (DateTime.TryParse(cellValue, out DateTime dateValue))
                {
                    var workbookProperties = workbookPart.Workbook.GetFirstChild<WorkbookProperties>();
                    var date1904 = workbookProperties?.Date1904 ?? false;
                    if (date1904)
                    {
                        dateValue = dateValue.AddDays(1462);
                    }
                    return dateValue.ToShortDateString();
                }
            }

            return cellValue;
        }
    }


}
