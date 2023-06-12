using Microsoft.Extensions.DependencyInjection;
using ProfitCalculation.Logic.ExcelImport;
using ProfitCalculation.UI;
using System.Windows.Forms;
using System.Configuration;

namespace ProfitCalculation.Presenter
{
    internal class ImportPresenter
    {
        private ImportView importView;

        public ImportPresenter(ImportView importView)
        {
            this.importView = importView;
            this.importView.ImportExcelFile += ImportExcelFile;
        }

        internal DataImporter DataImporter
        {
            get => default;
            set
            {
            }
        }

        private void ImportExcelFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var progressBarForm = new ProgressImportForm();
                progressBarForm.ControlBox = false;
                progressBarForm.RenameBar("Импорт данных");
                progressBarForm.Show();
                Application.DoEvents();
                string filePath = openFileDialog.FileName;
                var serviceProvider = MainPresenter.services.BuildServiceProvider();
                var importer = serviceProvider.GetService<IDataImporter>();
                importer.ExcelFileImporter(filePath, progressBarForm);
                SaveLastFileData(filePath, DateTime.Now);
                importView.SetImportFileName(filePath, DateTime.Now);
            }
        }

        public static void SaveLastFileData(string fileName, DateTime saveTime)
        {
            Properties.Settings settings = Properties.Settings.Default;
            settings.LastFileName = fileName;
            settings.LastFileSaveTime = saveTime;
            settings.Save();
        }
    }
}
