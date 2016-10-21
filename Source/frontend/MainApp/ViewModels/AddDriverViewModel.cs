using frontend.Service;
using MainApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainApp.ViewModels
{
    public class AddDriverViewModel
    {
        private IEmployeeService service;

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddDriverViewModel(IEmployeeService service)
        {
            this.service = service;
            LoadCommands();
        }

        private void LoadCommands()
        {
            AddCommand = new CustomCommand(AddDriver, null);
        }

        private void AddDriver(object obj)
        {
            //if (checkBoxes())
            //{
            //    try
            //    {
            //        Employee employee = new Employee();
            //        service = new EmployeeService();
            //        employee.surName = surNameBox.Text;
            //        employee.name = nameBox.Text;
            //        employee.email = emailBox.Text;
            //        employee.street = streetBox.Text;
            //        employee.housenr = houseNrBox.Text;
            //        City city = new City();
            //        city.city = cityBox.Text;
            //        city.postal_code = postalAddressBox.Text;
            //        employee.city = city;
            //        employee.date_employement = dateEmployementBox.Date.DateTime;
            //        employee.mobile_phone = mobileBox.Text;
            //        employee.telephone_number = telephoneBox.Text;
            //        employee.sex = sexBox.SelectedItem.ToString();

            //        if (statusBox.SelectedItem.ToString() == "Active")
            //        {
            //            employee.status = true;
            //        }
            //        else
            //        {
            //            employee.status = false;
            //        }

            //        service.Add(employee);
            //        this.Title = "Succesfull!";
            //        this.Hide();
            //    }
            //    catch (Exception)
            //    {
            //        this.Title = "Error! Please try again";
            //    }

            //}
            //else
            //{
            //    this.Title = "Error, you must fill in all the boxes.";
            //}
        }
    }
}
