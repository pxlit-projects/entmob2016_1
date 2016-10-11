using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using front_end.Domain;
using front_end.Services;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using front_end.App;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SplitViewDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SensorsPage : Page
    {
        public SensorsPage()
        {
            this.InitializeComponent();
            init();
        }
        private void init()
        {
            ISensorService service = new SensorService();
            List<Sensor> sensors = service.All();
            sensorsList.DataContext = sensors;

        }

        private void sensorsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            this.DataContext = ((Sensor)sensorsList.SelectedItem);
            sensorUsageList.DataContext = "";
            
        }

        

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Sensor sensor = new Sensor();
            ISensorService service = new SensorService();
            try
            {
                sensor.Sensor_id = Int32.Parse(idTxt.Text);
                sensor.Sensor_name = nameTxt.Text;
                sensor.Status = Boolean.Parse(statusTxt.Text);
                service.Update(sensor);
                init();
            }
            catch (Exception ex)
            {
                MessageDialog message = new MessageDialog("You might have made a mistake in one of the textboxes. :" + ex.ToString());
                message.Title = "Error";
                message.Commands.Add(new UICommand("Ok") { Id = 0 });                ;
                message.DefaultCommandIndex = 0;

                var result = await message.ShowAsync();

                
                    
            }
        }

        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            ISensorService service = new SensorService();
            Sensor sensor = (Sensor)sensorsList.SelectedItem;
            service.ChangeStatus(sensor);
            init();
            
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var sensordialog = new AddSensorDialog();
            var result = await sensordialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                init();
                
            } 
        }

        private void sensorUsageButton_Click(object sender, RoutedEventArgs e)
        {
            ISensorUsageService service = new SensorUsageService();
            sensorUsageList.DataContext = service.Find(((Sensor)sensorsList.SelectedItem).Sensor_id);
        }
    }
}
