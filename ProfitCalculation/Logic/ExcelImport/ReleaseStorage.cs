using Microsoft.EntityFrameworkCore;
using ProfitCalculation.DataBase.Models;

namespace ProfitCalculation.Logic.ExcelImport
{
    internal class ReleaseStorage
    {
        public void DeleteAllDataInAllDbSets(DbContext dbContext)
        {
            using (var context = new ProfitCalculatingContext())
            {
                var tableNames = context.Model.GetEntityTypes()
                    .Select(t => t.GetTableName())
                    .Where(name => name != "__EFMigrationsHistory")
                    .ToList();

                foreach (var tableName in tableNames)
                {
                    context.Database.ExecuteSqlRaw($"DELETE FROM {tableName}");
                }

                context.SaveChanges();
            }
        }
    }
}
