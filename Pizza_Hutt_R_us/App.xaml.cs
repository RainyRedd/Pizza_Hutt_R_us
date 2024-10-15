using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;

namespace Pizza_Hutt_R_us
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            
            CultureInfo danishCulture = new CultureInfo("da-DK");
            Thread.CurrentThread.CurrentCulture = danishCulture;
            Thread.CurrentThread.CurrentUICulture = danishCulture;
        }
    }

}
