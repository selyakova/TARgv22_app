﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateTimePage : ContentPage
    {
        Label lbl;
        DatePicker dp;
        TimePicker tp;
        public DateTimePage()
        {
            lbl = new Label
            {
                Text = "Vali mingi kuupäev",
                //BackgroundColor = Color.Gray,
            };
            dp = new DatePicker
            {
                Format = "D",
                MinimumDate = DateTime.Now.AddDays(-10),
                MaximumDate = DateTime.Now.AddDays(10),
                TextColor = Color.Gray,
            };
            dp.DateSelected += Dp_DateSelected;
            tp = new TimePicker
            {
                Time = new TimeSpan(12, 0, 0),
            };
            tp.PropertyChanged += Tp_PropertyChanged;


            AbsoluteLayout abs = new AbsoluteLayout
            {
                Children = { lbl, dp, tp }
            };

            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.1, 0.2, 200, 50));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(dp, new Rectangle(0.1, 0.5, 300, 50));
            AbsoluteLayout.SetLayoutFlags(dp, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(tp, new Rectangle(0.5, 0.7, 300, 50));
            AbsoluteLayout.SetLayoutFlags(tp, AbsoluteLayoutFlags.PositionProportional);
            Content = abs;
        }
            private void Tp_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                lbl.Text = "Oli valitud aeg: " + tp.Time;
            }

            private void Dp_DateSelected(object sender, DateChangedEventArgs e)
            {
                lbl.Text = "Oli valitud kuupäev: " + e.NewDate.ToString("G");
            }       
    }
}