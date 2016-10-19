using Mobile_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IMD5 md5)
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel(md5);
        }
    }
}
