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