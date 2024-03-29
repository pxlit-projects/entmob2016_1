﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Mobile_App.Droid
{
    [Activity(Label = "Mobile_App", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            var a = new Robotics.Mobile.Core.Bluetooth.LE.Adapter();
            App.SetAdapter(a);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            IMD5 md5 = new Mobile_App.Droid.MD5();

            LoadApplication(new App(md5));
        }
    }
}

