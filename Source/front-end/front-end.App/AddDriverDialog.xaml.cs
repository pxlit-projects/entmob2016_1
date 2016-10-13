using front_end.Domain;
using front_end.Services;
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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace front_end.App
{
    public sealed partial class AddDriverDialog : ContentDialog
    {
        private IEmployeeService service;

        public AddDriverDialog()
        {
            Windows.UI.ViewManagement.InputPane.GetForCurrentView().Showing += (s, args) =>
            {
                const double extraHeightBuffer = 20.0;

                UIElement focused = FocusManager.GetFocusedElement() as UIElement;
                if (null != focused)
                {
                    GeneralTransform gt = focused.TransformToVisual(this);
                    Point focusedPoint = gt.TransformPoint(new Point(0, focused.RenderSize.Height - 1));
                    double bottomOfFocused = focusedPoint.Y + extraHeightBuffer;
                    if (bottomOfFocused > args.OccludedRect.Top)
                    {
                        var trans = new TranslateTransform();
                        trans.Y = -(bottomOfFocused - args.OccludedRect.Top);
                        this.RenderTransform = trans;
                    }
                    args.EnsuredFocusedElementInView = true;
                }
            };

            Windows.UI.ViewManagement.InputPane.GetForCurrentView().Hiding += (s, args) =>
            {
                var trans = new TranslateTransform();
                trans.Y = 0;
                this.RenderTransform = trans;
                args.EnsuredFocusedElementInView = false;
            };
            this.InitializeComponent();

            List<string> sexItems = new List<string> { "Male", "Female" };
            List<string> statusItems = new List<string> { "Active", "Non-active" };
            sexBox.ItemsSource = sexItems;
            statusBox.ItemsSource = statusItems;
        }


        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (checkBoxes())
            {
                try
                {
                    Employee employee = new Employee();
                    service = new EmployeeService();
                    employee.surName = surNameBox.Text;
                    employee.name = nameBox.Text;
                    employee.email = emailBox.Text;
                    employee.street = streetBox.Text;
                    employee.housenr = houseNrBox.Text;
                    City city = new City();
                    city.city = cityBox.Text;
                    city.postal_code = postalAddressBox.Text;
                    employee.city = city;
                    employee.date_employement = dateEmployementBox.Date.DateTime;
                    employee.mobile_phone = mobileBox.Text;
                    employee.telephone_number = telephoneBox.Text;
                    employee.sex = sexBox.SelectedItem.ToString();

                    if (statusBox.SelectedItem.ToString() == "Active")
                    {
                        employee.status = true;
                    }
                    else
                    {
                        employee.status = false;
                    }

                    service.Add(employee);
                    this.Title = "Succesfull!";
                    this.Hide();
                }
                catch (Exception)
                {
                    this.Title = "Error! Please try again";
                }
                
            }
            else
            {
                this.Title = "Error, you must fill in all the boxes.";
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }

        private void Box_FocusEngaged(Control sender, FocusEngagedEventArgs args)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = "";
        }

        private Boolean checkBoxes()
        {
            if (surNameBox.Text != null && nameBox.Text != null && emailBox.Text != null && 
                streetBox.Text != null && houseNrBox.Text != null && cityBox.Text != null && 
                postalAddressBox != null && dateEmployementBox.Date.DateTime != null && mobileBox.Text != null &&
                telephoneBox.Text != null && sexBox.SelectedItem != null && statusBox.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
