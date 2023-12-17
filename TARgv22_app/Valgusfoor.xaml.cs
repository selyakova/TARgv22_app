using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor : ContentPage
    {
        Button sisse, valja;
        Label label;
        bool help = false;
        Frame[] frm;
        string[] names = { "Punane", "Kollane", "Roheline" };

        public Valgusfoor()
        {
            TapGestureRecognizer esimene = new TapGestureRecognizer();
            TapGestureRecognizer teine = new TapGestureRecognizer();
            TapGestureRecognizer kolmas = new TapGestureRecognizer();
            TapGestureRecognizer[] taps = { esimene, teine, kolmas };
            esimene.Tapped += Esimene_Tapped;
            teine.Tapped += Teine_Tapped;
            kolmas.Tapped += Kolmas_Tapped;

            frm = new Frame[3];

            for (int i = 0; i < frm.Length; i++)
            {
                label = new Label
                {
                    Text = names[i],
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                };
                frm[i] = new Frame
                {
                    Content = label,
                    BackgroundColor = Color.Gray,
                    CornerRadius = 1000,
                    WidthRequest = 200,
                    HeightRequest = 200,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                };
                frm[i].GestureRecognizers.Add(taps[i]);
            }

            sisse = new Button
            {
                Text = "SISSE"
            };
            sisse.Clicked += Sisse_Clicked;

            valja = new Button
            {
                Text = "VÄLJA",
                HorizontalOptions = LayoutOptions.End,
            };
            valja.Clicked += Valja_Clicked;

            FlexLayout fl = new FlexLayout
            {
                Children = { sisse, valja },
                JustifyContent = FlexJustify.SpaceEvenly
            };

            Content = new StackLayout { Children = { frm[0], frm[1], frm[2], fl } };
        }

        private async void Valja_Clicked(object sender, EventArgs e)
        {
            help = false;
            await Navigation.PopAsync();
            frm[0].BackgroundColor = Color.Red;
            frm[1].BackgroundColor = Color.Yellow;
            frm[2].BackgroundColor = Color.Green;
            sisse.BackgroundColor = Color.Pink;
            valja.BackgroundColor = Color.Pink;
        }
        private void Sisse_Clicked(object sender, EventArgs e)
        {
            help = true;
            frm[0].BackgroundColor = Color.Red;
            frm[1].BackgroundColor = Color.Yellow;
            frm[2].BackgroundColor = Color.Green;
            sisse.BackgroundColor = Color.Pink;
            valja.BackgroundColor = Color.Pink;
        }
        private void Kolmas_Tapped(object sender, EventArgs e)
        {
            if (help == true)
            {
                Frame f = (Frame)sender;
                Label l = f.Content as Label;
                if (l.Text == "Mine!")
                {
                    l.Text = "Roheline";
                }
                else
                {
                    l.Text = "Mine!";
                    frm[2].BackgroundColor = Color.Green;
                }
            }
            else
            {
                DisplayAlert("Tähelepanu:", "Enne valgusfoori käivitamist vajutage esmalt nuppu SISSE", "OK");
            }
        }
        private void Teine_Tapped(object sender, EventArgs e)
        {
            if (help == true)
            {
                Frame f = (Frame)sender;
                Label l = f.Content as Label;
                if (l.Text == "Oota!")
                {
                    l.Text = "Kollane";
                }
                else
                {
                    l.Text = "Oota!";
                    frm[1].BackgroundColor = Color.Yellow;
                }
            }
            else
            {
                DisplayAlert("Tähelepanu:", "Enne valgusfoori käivitamist vajutage esmalt nuppu SISSE", "OK");
            }
        }
        private void Esimene_Tapped(object sender, EventArgs e)
        {
            if (help == true)
            {
                Frame f = (Frame)sender;
                Label l = f.Content as Label;
                if (l.Text == "Stop!")
                {
                    l.Text = "Punane";
                }
                else
                {
                    l.Text = "Stop!";
                    frm[0].BackgroundColor = Color.Red;
                }
            }
            else
            {
                DisplayAlert("Tähelepanu:", "Enne valgusfoori käivitamist vajutage esmalt nuppu SISSE", "OK");
            }
        }
    }
}

