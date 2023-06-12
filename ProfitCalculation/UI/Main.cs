using System.Windows.Forms;
using ProfitCalculation.Presenter;
using ProfitCalculation.UI.Interfaces;

namespace ProfitCalculation.UI;

public partial class MainView : Form, IMainView
{
    public MainView()
    {
        InitializeComponent();
        this.IsMdiContainer = true;
    }

    public event EventHandler LoadDataBase;
    public event EventHandler ShowImportView;
    public event EventHandler ShowCalculateView;

    private void Main_Load(object sender, EventArgs e)
    {
        IsMdiContainer = true;
        MainPresenter presenter = new MainPresenter(this);
        presenter.LoadDataBase(sender, e);
    }
    private void btnCalc_Click(object sender, EventArgs e)
    {
        CalcView calcView = new CalcView();
        calcView.MdiParent = this;
        calcView.FormBorderStyle = FormBorderStyle.None;
        calcView.Dock = DockStyle.Fill;
        calcView.Show();
    }

    private void btnImport_Click(object sender, EventArgs e)
    {
        ImportView importView = new ImportView();
        importView.MdiParent = this;

        importView.Dock = DockStyle.Fill;
        importView.FormBorderStyle = FormBorderStyle.None;

        importView.Show();
    }
}