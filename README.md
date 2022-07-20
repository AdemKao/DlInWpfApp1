## Dependency Injection In WPF

This Repo is demo Dependency Inject in .Net6 which is from [leadmagnets.app](https://www.youtube.com/watch?v=dLR_D2IJE1M).

This target is to create multiple child forms in same button.

We will use `Factory Pattern` and `Delegate Pattern` in this project.

### Step1 Create a WPF (.Net6) Project
    WPF Project is startup from `App.xaml`,so we need to change the StartupUri.

### Step2 Delete  `StartupUri="MainWindow.xaml"` in `App.xaml'
	```
	    <Application x:Class="WpfApp1.App"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:local="clr-namespace:WpfApp1"
                 >
        <Application.Resources>
             
        </Application.Resources>
        </Application>

	```
### Step3 Install `Microsoft.Extensions.DependencyInjection` and `Microsoft.Extensions.Hosting` from Nuget
### Step4 Update code in `App.xaml.cs`
-   import lib
-   change `namesapce WpfApp1{}`  to `namesapce WpfApp1;`
    this is new for above C#.10, call [File Scoped Namespaces](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-10.0/file-scoped-namespaces).
-   Create and override three functions
    -   Constracture
        ```
            ...
            public static IHost? AppHost { get; private set; }

            public App()
            {
                AppHost = Host.CreateDefaultBuilder()
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddSingleton<MainWindow>(); //Main Form 
                        //TODO
                    })
                    .Build();
            }
        ```
    -   OnStartup
        ```
            protected override async void OnStartup(StartupEventArgs e)
            {
                await AppHost!.StartAsync();

                var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
                startupForm.Show();

                base.OnStartup(e);
            }
        ```
    -   OnExit
        ```
            protected override async void OnExit(ExitEventArgs e)
            {
                await AppHost!.StopAsync();
                base.OnExit(e);
            }
        ```
### Step5 Create TextBox and Button in `MainWindow.xaml`
    ```
    <Window x:Class="WpfApp1.MainWindow"
        ...
        Title="MainWindow" Height="200" Width="500" FontSize="24">
        <Grid>
            <StackPanel VerticalAlignment="Center" HorizontalAlignment="Center">
                <TextBox x:Name="tb_DataAccessInfo" Margin="10"></TextBox>
                <Button x:Name="bt_GetData" Padding="20 10" Click="bt_GetData_Click">Get Data</Button>
                <Button x:Name="bt_CreateForm" Padding="20 10">Create ChildForm</Button>
            </StackPanel> 
        </Grid>
    </Window>
    ```

## Step6 Add Some Data to TextBox
   This step we need to create some test data,so we will create a new project `WpfLib`.
   Then Create a class `DataAccess.cs` and `IDataAccess.cs`.
   ```
   //DataAccess.cs
   namespace WpfLib;
   
   public class DataAccess :IDataAccess
   {
       public string GetData()
       {
           return "This is calling DataAccess GetData().";
       }
   }
   ```
   Then add params in `MainWindow.xaml.cs` constructor and click function
   ```
   //MainWindow.xaml.cs
   ...
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
   ```
   And then the import part is need to add `AddTransient` in `App.xaml.cs`
   ```
   //App.xaml.cs
   ...
       public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                ...
                services.AddTransient<IDataAccess, DataAccess>();
                
            })
            .Build();
    }
   ```
## Step7 Create ChildForm

