﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mobile_App
{
	public class EmptyStringConverter : IValueConverter
	{
		public object Convert (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			String str = (String)value;
			return String.IsNullOrWhiteSpace (str) ? "<un-named device>" : str;
		}

		public object ConvertBack (
			object value,
			Type targetType,
			object parameter,
			CultureInfo culture)
		{
			throw new NotImplementedException ("EmptyStringConverter is one-way");
		}
	}
}

