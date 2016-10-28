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

namespace MainApp.Views
{
    public sealed partial class AddProductDialog : ContentDialog
    {
        public AddProductDialog()
        {
            this.InitializeComponent();
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
        }


    }
}
