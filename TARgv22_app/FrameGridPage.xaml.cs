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
    public partial class FrameGridPage : ContentPage
    {
        Frame frame;
        Grid grid;
        Random rnd;
        Label label;
        Button button;
        public FrameGridPage()
        {
            Random rnd = new Random();
            grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Gray
            };
            for (int i = 0; i < 2; i++)
            {
                //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                for (int j = 0; j < 3; j++)
                {
                    grid.Children.Add(
                        button = new Button
                        {
                            Text = i.ToString()+j.ToString(),
                            CornerRadius = 10,
                            BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)),
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                        }, i, j);
                    button.Clicked += Button_Clicked;
                }
            }
            label = new Label { Text = "Tekst" };

            grid.Children.Add(label, 0, 3);
            Grid.SetColumnSpan(label, 2);
            Content = grid;
        }
        Boolean klik = false;
        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            var r = Grid.GetRow(button);
            var c = Grid.GetColumn(button);
            if (klik)
            {
                button.BackgroundColor = Color.Pink;
                klik = false;
            }
            else 
            { 
                Random rnd = new Random();
                button.BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                klik = true;
            }
            label.Text = r.ToString()+c.ToString();
        }
    }
}