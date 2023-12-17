using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EestiSonad : ContentPage
    {
        Button start;
        bool help = false;
        Label name;
        Label score;
        int point = 0;
        Button button;
        Button finish;

        private Dictionary<int, string> buttonLabels = new Dictionary<int, string>
        {
            { 1, "Цветок" },
            { 2, "Дерево" },
            { 3, "Куртка" },
            { 4, "Конфета" },
            { 5, "Тетрадь" },
            { 6, "Собака" },
            { 7, "Подарок" },
            { 8, "Сумка" },
            { 9, "Вилка" },
        };

        private List<string> translation = new List<string>
        {
            "Lill",
            "Puu",
            "Jope",
            "Komm",
            "Vihik",
            "Koer",
            "Kingitus",
            "Kott",
            "Kahvel"
        };

        public EestiSonad()
        {
            name = new Label
            {
                Text = "",
                FontSize = 20,
                TextColor = Color.Gray,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
                Margin = 2
            };

            score = new Label
            {
                Text = "",
                FontSize = 20,
                TextColor = Color.DarkGray,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.End,
                Margin = 2,
            };


            start = new Button
            {
                Text = "Alusta mäng!",
                FontSize = 20,
                TextColor = Color.Gray,
                BorderColor = Color.DarkGray,
                CornerRadius = 10,
                WidthRequest = 280,
                HeightRequest = 55,
                BorderWidth = 2,
                BackgroundColor = Color.Pink,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            start.Clicked += Start_Clicked;

            finish = new Button
            {
                Text = "Mängust välja",
                FontSize = 20,
                TextColor = Color.Gray,
                BorderColor = Color.DarkGray,
                CornerRadius = 10,
                WidthRequest = 280,
                HeightRequest = 55,
                BorderWidth = 2,
                BackgroundColor = Color.Pink,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };

            finish.IsVisible = false;
            finish.Clicked += Finish_ClickedAsync;

            Grid grid = new Grid
            {
                RowDefinitions =
            {
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            },
                ColumnDefinitions =
            {
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            }
            };

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    int buttonNumber = row * 3 + column + 1;
                    string buttonText = buttonLabels[buttonNumber];

                    button = new Button
                    {
                        Text = buttonText,
                        FontSize = 20,
                        TextColor = Color.Gray,
                        BorderColor = Color.DarkGray,
                        CornerRadius = 10,
                        HeightRequest = 100,
                        BorderWidth = 2,
                        BackgroundColor = Color.Pink,

                    };
                    grid.Children.Add(button, column, row);
                    button.Clicked += Button_ClickedAsync;
                }
            }

            Content = new StackLayout { Children = { name, score, start, grid, finish } };
        }

        private async void Finish_ClickedAsync(object sender, EventArgs e)
        {
            Button sampel = sender as Button;
            await Navigation.PopAsync();
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            if (help == true)
            {
                Button button = (Button)sender;
                string result = await DisplayPromptAsync("Ülesanne:", $"Tõlgi eesti keele '{button.Text}': ", "OK", keyboard: Keyboard.Chat);
                if (result == translation[0] & button.Text == buttonLabels[1])
                {
                    button.BackgroundColor = Color.LightPink;
                    point += 1;
                    score.Text = "Teie tulemus " + point.ToString();
                }
                else if (result == translation[1] & button.Text == buttonLabels[2])
                {
                    button.BackgroundColor = Color.LightPink;
                    point += 1;
                    score.Text = "Teie tulemus " + point.ToString();
                }
                else if (result == translation[2] & button.Text == buttonLabels[3])
                {
                    button.BackgroundColor = Color.LightPink;
                    point += 1;
                    score.Text = "Teie tulemus " + point.ToString();
                }
                else if (result == translation[3] & button.Text == buttonLabels[4])
                {
                    button.BackgroundColor = Color.LightPink;
                    point += 1;
                    score.Text = "Teie tulemus " + point.ToString();
                }
                else if (result == translation[4] & button.Text == buttonLabels[5])
                {
                    button.BackgroundColor = Color.LightPink;
                    point += 1;
                    score.Text = "Teie tulemus " + point.ToString();
                }
                else if (result == translation[5] & button.Text == buttonLabels[6])
                {
                    button.BackgroundColor = Color.LightPink;
                    point += 1;
                    score.Text = "Teie tulemus " + point.ToString();
                }
                else if (result == translation[6] & button.Text == buttonLabels[7])
                {
                    button.BackgroundColor = Color.LightPink;
                    point += 1;
                    score.Text = "Teie tulemus " + point.ToString();
                }
                else if (result == translation[7] & button.Text == buttonLabels[8])
                {
                    button.BackgroundColor = Color.LightPink;
                    point += 1;
                    score.Text = "ВTeie tulemus " + point.ToString();
                }
                else if (result == translation[8] & button.Text == buttonLabels[9])
                {
                    button.BackgroundColor = Color.LightPink;
                    point += 1;
                    score.Text = "Teie tulemus " + point.ToString();
                }
                else
                {
                    button.BackgroundColor = Color.LightPink;
                    DisplayAlert("Tulemus:", "Õpi veel natuke!", "ОК");
                }
            }
            else
            {
                DisplayAlert("Tähelepanu!", "Esimesena vajuta nupp 'Alusta mäng'", "ОК");
            }

        }
        private async void Start_Clicked(object sender, EventArgs e)
        {
            help = true;
            string result = await DisplayPromptAsync("Küsimus", "Kirjuta oma nimi: ", "OK", keyboard: Keyboard.Chat);
            name.Text = "Tere, " + result + "!";
            score.Text = "Teie tulemus: " + point;
            score.IsVisible = true;
            start.BackgroundColor = Color.Pink;
            start.IsVisible = false;
            if (start.IsVisible == false)
            {
                finish.IsVisible = true;
            }
        }
    }
}