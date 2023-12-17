using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            Button Ent_button = new Button
            {
                Text = "Entry_page",
                BackgroundColor = Color.Gray
            };

            Button Time_button = new Button
            {
                Text = "Timer_page",
                BackgroundColor = Color.Gray
            };

            Button Box_button = new Button
            {
                Text = "BoxView_page",
                BackgroundColor = Color.Gray
            };

            StackLayout st = new StackLayout
            {
                Children= {Ent_button, Time_button, Box_button},
                BackgroundColor = Color.Beige,
            };

            Content= st;
            Ent_button.Clicked += Ent_button_Clicked;
            Time_button.Clicked += Time_button_Clicked;
            Box_button.Clicked += Box_button_Clicked;
        }

        private async void Box_button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxViewPage());
        }

        private async void Time_button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }

        private async void Ent_button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }
    }
}