using NbaStatsClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NbaWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NbaApiClient.InitializeClient();
        }

        private async void SubmitButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                var url = urlTextBox.Text;
                var response = await LoadNbaTeam(url);
                outputBox.AppendText(response.ToString());
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        public static async Task<string> LoadString(string url)
        {
            using (HttpResponseMessage response = await NbaApiClient.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();

                    return responseString;
                }
                else
                {
                    var ex = new Exception(response.ReasonPhrase);
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }

        public static async Task<NbaTeam> LoadNbaTeam(string url)
        {
            using (HttpResponseMessage response = await NbaApiClient.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    NbaTeam nbaTeam = await response.Content.ReadAsAsync<NbaTeam>();

                    return nbaTeam;
                }
                else
                {
                    var ex = new Exception(response.ReasonPhrase);
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }
            }
        }
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " ->" + sMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("HandleError Exception: " + ex.Message);
            }
        }
    }
}
