## Dependecy Injection In WPF

This Repo is demo from [leadmagnets.app](https://www.youtube.com/watch?v=dLR_D2IJE1M)

### Step1 Create a WPF (.Net6) Project
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
ewqewq

    -   import lib
    -   change `namesapce WpfApp1{}`  to `namesapce WpfApp1;`
    -   Create and override three functions
        -   Constracture
        -   OnStartup
        -   OnExit

