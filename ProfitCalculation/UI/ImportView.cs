using System;
using System.Windows.Forms;
using ProfitCalculation.Presenter;
using ProfitCalculation.UI.Interfaces;

namespace ProfitCalculation.UI
{
    public partial class ImportView : Form, IImportView
    {
        public ImportView()
        {
            InitializeComponent();
            ImportPresenter presenter = new ImportPresenter(this);
            button1.Click += ImportExcelFile;
            var lastFile = GetLastFileData();
            if (lastFile.Item1 == null || lastFile.Item1 == "")
            {
                label3.Text = "нет импортированных данных";
                label4.Visible = false;
            } else
            {
                label3.Text = "последний импортированный файл: " + lastFile.Item1;
                label4.Visible = true;
                label4.Text = lastFile.Item2.ToString();
            }
            
        }

        public static Tuple<string?, DateTime?> GetLastFileData()
        {
            Properties.Settings settings = Properties.Settings.Default;
            string? name = null;
            DateTime? date = null;
            try
            {
                name = settings.LastFileName;                
            } catch  { }
            try
            {
                date = settings.LastFileSaveTime;
            }
            catch (NullReferenceException) 
            {
                date = null;
            }
            return Tuple.Create(name, date);
        }

        public event EventHandler ImportExcelFile;

        public static ImportView _instance;
        public static ImportView GetInstace(Form parentContainer)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new ImportView();
                _instance.MdiParent = parentContainer;
                _instance.FormBorderStyle = FormBorderStyle.None;
                _instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (_instance.WindowState == FormWindowState.Minimized)
                    _instance.WindowState = FormWindowState.Normal;
                _instance.BringToFront();
            }
            return _instance;
        }

        public void SetImportFileName(string name, DateTime time)
        {
            label3.Text = "последний импортированный файл: " + name;
            label4.Visible = true;
            label4.Text = time.ToString();
        }
    }
}
