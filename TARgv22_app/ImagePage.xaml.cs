using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        Switch sw;
        Image img;
        public ImagePage()
        {
            img = new Image { Source = "lill.jpg" };
            var tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 2;
            img.GestureRecognizers.Add(tap);
            BackgroundColor= Color.Pink;

            sw = new Switch
            {
                IsEnabled = true,
                VerticalOptions= LayoutOptions.Center,
                HorizontalOptions= LayoutOptions.Center,
            };
            sw.Toggled += Sw_Toggled;
            this.Content = new StackLayout { Children = {img, sw} };
        }
        int tapid = 0;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            tapid++;
            var imagesender = (Image)sender;
            if (tapid % 2 == 0)
            {
                img.Source = "lill.jpg";
            }
            else { img.Source = "lill1.jpg"; }
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                img.IsVisible= true;
            }
            else { 
                img.IsVisible= false;
            }
        }
    }
}