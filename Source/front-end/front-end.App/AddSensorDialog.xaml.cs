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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace front_end.App
{
    public sealed partial class AddSensorDialog : ContentDialog
    {
        public AddSensorDialog()
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
        }


        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (checkBoxes())
            {
                Sensor sensor = new Sensor();
                ISensorService service = new SensorService();
                sensor.sensor_name = nameBox.Text;
                sensor.status = true;
                service.Add(sensor);
                this.Title = "Succesfull!";
                this.Hide();
            } else
            {
                this.Title = "Error, you must add a name.";
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }

        private void nameBox_FocusEngaged(Control sender, FocusEngagedEventArgs args)
        {
            nameBox.Text = "";
        }

        private Boolean checkBoxes()
        {
            if (nameBox.Text == null)
            {

                return false;
            } else
            {
                return true;
            }
        }
    }
}
