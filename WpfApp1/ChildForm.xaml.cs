using System.Windows;
using WpfLib;

namespace WpfApp1;

public partial class ChildForm : Window
{
    private readonly IDataAccess _dataAccess;

    public ChildForm(IDataAccess dataAccess)
    {
        InitializeComponent();
        _dataAccess = dataAccess;
    }
}
