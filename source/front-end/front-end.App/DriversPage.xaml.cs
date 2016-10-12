using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using front_end.Services;
using front_end.Domain;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SplitViewDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DriversPage : Page
    {
        private IEmployeeService service;

        public DriversPage()
        {
            this.InitializeComponent();
        }

        private void init()
        {
            service = new EmployeeService();
            List<Employee> employees = service.All();
            driversList.DataContext = employees;
        }

        private void driversList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DataContext = ((Employee)driversList.SelectedItem);
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                employee.Employee_id = Int32.Parse(idTxt.Text);
                employee.SurName = surNameTxt.Text;
                employee.Name = nameTxt.Text;
                employee.Email = emailTxt.Text;
                employee.Mobile_phone = mobileTxt.Text;
                employee.Telephone_number = telephoneTxt.Text;
                employee.Status = Convert.ToBoolean(statusTxt);
                service.Update(employee);
                init();
            }
            catch (Exception ex)
            {
                MessageDialog message = new MessageDialog("You might have made a mistake in one of the textboxes. :" + ex.ToString());
                message.Title = "Error";
                message.Commands.Add(new UICommand("Ok") { Id = 0 });
                message.DefaultCommandIndex = 0;
                var result = await message.ShowAsync();
            }
        }

        private async void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = (Employee) driversList.SelectedItem;
            if (employee.Status == true)
            {
                MessageDialog message = new MessageDialog("Are you sure you want to deactivate this driver?");
                message.Title = "Deactivate driver";
                var yesCommand = new UICommand("Yes") { Id = 0 };
                var noCommand = new UICommand("No") { Id = 1 };
                message.Commands.Add(yesCommand);
                message.Commands.Add(noCommand);

                message.DefaultCommandIndex = 0;
                message.CancelCommandIndex = 1;

                var result = await message.ShowAsync();

                if (result == yesCommand)
                {
                    employee.Status = false;
                    service.Update(employee);
                    init();
                }
            }
            else
            {
                MessageDialog message = new MessageDialog("Are you sure you want to activate this driver?");
                message.Title = "Activate driver";
                var yesCommand = new UICommand("Yes") { Id = 0 };
                var noCommand = new UICommand("No") { Id = 1 };
                message.Commands.Add(yesCommand);
                message.Commands.Add(noCommand);

                message.DefaultCommandIndex = 0;
                message.CancelCommandIndex = 1;

                var result = await message.ShowAsync();

                if (result == yesCommand)
                {
                    employee.Status = true;
                    service.Update(employee);
                    init();
                }
            }
        }
    }
}
