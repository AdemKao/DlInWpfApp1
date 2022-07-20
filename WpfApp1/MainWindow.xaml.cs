using System.Windows;
using WpfLib;

namespace WpfApp1;

public partial class MainWindow : Window
{

    private IDataAccess _dataAccess;
    public MainWindow(IDataAccess dataAccess)
    {
        InitializeComponent();
        _dataAccess = dataAccess;
    }

    private void bt_GetData_Click(object sender, RoutedEventArgs e)
    {
        tb_DataAccessInfo.Text = _dataAccess.GetData();
    }
}
