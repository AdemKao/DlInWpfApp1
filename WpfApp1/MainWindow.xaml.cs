using System.Windows;
using WpfApp1.StartupHelper;
using WpfLib;

namespace WpfApp1;

public partial class MainWindow : Window
{

    private IDataAccess _dataAccess;
    private IAbstractFactory<ChildForm> _factory;
    public MainWindow(IDataAccess dataAccess,IAbstractFactory<ChildForm> factory)
    {
        InitializeComponent();
        _dataAccess = dataAccess;
        _factory = factory;
    }

    private void bt_GetData_Click(object sender, RoutedEventArgs e)
    {
        tb_DataAccessInfo.Text = _dataAccess.GetData();
    }

    private void bt_CreateForm_Click(object sender, RoutedEventArgs e)
    {
        _factory.Create().Show();
    }
}
