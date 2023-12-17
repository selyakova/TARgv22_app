using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TARgv22_app
{
    public partial class PickerPage : ContentPage
    {
        Picker picker;
        WebView webView;
        StackLayout st;
        Frame frame;
        Entry entry;
        Button textButton, homeButton, backButton;
        string[] lehed = new string[4] {
            "https://moodle.edu.ee/my/",
            "https://www.tthk.ee/",
            "https://tahvel.edu.ee/#/",
            "https://anastassiaseljakova22.thkit.ee/" };
        Stack<string> navigationStack = new Stack<string>();

        public PickerPage()
        {
            picker = new Picker
            {
                Title = "VEEBILEHED"
            };
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            picker.Items.Add("Tahvel");
            picker.Items.Add("Minu veebileht");

            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
            webView = new WebView();

            entry = new Entry { };
            entry.Completed += Entry_Completed;

            textButton = new Button { Text = "Koduleht" };
            textButton.Clicked += TextButton_Clicked;

            homeButton = new Button { Text = "Kodulehele" };
            homeButton.Clicked += HomeButton_Clicked;

            backButton = new Button { Text = "Tagasi" };
            backButton.Clicked += BackButton_Clicked;

            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer();
            swipe.Swiped += Swipe_Swiped;
            swipe.Direction = SwipeDirection.Right;
            frame = new Frame
            {
                BorderColor = Color.White,
                CornerRadius = 20,
                HeightRequest = 20,
                WidthRequest = 400,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };
            st = new StackLayout
            {
                Children = { picker, frame, entry, textButton, homeButton, backButton }
            };
            frame.GestureRecognizers.Add(swipe);
            Content = st;
        }

        private void HomeButton_Clicked(object sender, EventArgs e)
        {
            LoadUrl(lehed[0]);
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            if (navigationStack.Count > 1)
            {
                navigationStack.Pop();
                string previousUrl = navigationStack.Peek();
                LoadUrl(previousUrl);
            }
        }

        private void TextButton_Clicked(object sender, EventArgs e)
        {
            LoadUrl((string)Preferences.Get("link", lehed[3]));
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string value = "http://www." + entry.Text;
            Preferences.Set("link", value);
            LoadUrl(value);
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {
            LoadUrl(lehed[3]);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            LoadUrl(lehed[picker.SelectedIndex]);
        }

        private void LoadUrl(string url)
        {
            if (webView != null)
            {
                st.Children.Remove(webView);
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = url },
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            st.Children.Add(webView);

            navigationStack.Push(url);
        }
    }
}