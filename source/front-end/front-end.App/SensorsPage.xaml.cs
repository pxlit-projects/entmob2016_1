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
        }
    }
}
