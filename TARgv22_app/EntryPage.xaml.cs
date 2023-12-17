using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        Label label, label2;
        Editor editor;
        public EntryPage()
        {
            editor = new Editor
            {
                Placeholder = "Sisesta siia tekst",
                BackgroundColor = Color.Gray,
                TextColor = Color.Pink,
            };

            //editor.TextChanged += Editor_TextChanged;
            //if (App.Current.Properties.TryGetValue("key", out key))
            //{
            //    string m = "key";
            //}
                label = new Label
            {
                //Text = "PEALKIRI", //(string)App.Current.Properties["key"],
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.Pink,
                BackgroundColor = Color.Gray
            };

            label2 = new Label
            {
                Text = Preferences.Get("key2", "ei ole veel key2"),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.Pink,
                BackgroundColor = Color.Gray
            };

            Button back_button = new Button
            {
                Text = "KODULEHELE",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            back_button.Clicked += Back_button_Clicked;

            Button c = new Button
            {
                Text = "Salvesta omadus",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            c.Clicked += C_Clicked;

            Button d = new Button
            {
                Text = "Salvesta preferences",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            d.Clicked += D_Clicked;

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { label, label2, editor, c, d, back_button },
                BackgroundColor = Color.Gray,
            };
            Content = st;
        }
        int j = 1;
        private void D_Clicked(object sender, EventArgs e)
        {
            string value2 = editor.Text;
            Preferences.Set("key2"+j.ToString(), value2);
            label2.Text = value2;
            j++;
        }

        private void C_Clicked(object sender, EventArgs e)
        {
            string value = editor.Text;
            App.Current.Properties.Remove("key");
            App.Current.Properties.Add("key", value);
            label.Text = (string)App.Current.Properties["key"];
        }

        protected override void OnAppearing()
        {
            object key = "";
            if (App.Current.Properties.TryGetValue("key", out key))
            {
                label.Text = (string)App.Current.Properties["key"];
            }
            base.OnAppearing();
        }

        int i = 0;
        //private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    char key = e.NewTextValue?.LastOrDefault() ?? ' ';
        //    if (key=='A')
        //    {
        //        i++;
        //        label.Text = key.ToString()+": "+i.ToString();
        //    };
        //}

        private async void Back_button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}