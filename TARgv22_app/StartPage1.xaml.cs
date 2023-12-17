using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [assembly: ExportFont("beer-money12.ttf")]
    public partial class StartPage1 : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() { 
            new EntryPage(), 
            new BoxViewPage(), 
            new TimerPage(), 
            new DateTimePage(), 
            new StepperSliderPage(), 
            new Valgusfoor(), 
            new FrameGridPage(), 
            new ImagePage(), 
            new PickerPage(), 
            new TablePage(), 
            new FilePage(), 
            new EestiSonad() };

        List<string> teksts = new List<string> { 
            "Ava Entry leht", 
            "Ava BoxView leht", 
            "Ava Timer leht", 
            "Ava DateTime leht", 
            "Ava StepperSlider leht", 
            "Ava valgusfoor", 
            "Ava frame grid leht", 
            "Ava image leht", 
            "Oma browser", 
            "Ava table page", 
            "Ava file leht", 
            "Ava sõnade mäng"};

        StackLayout st;

        public StartPage1()
        {
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor= Color.Gray,

            };
            for (int i = 0; i< pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = teksts[i],
                    TabIndex = i,
                    BackgroundColor = Color.Pink,
                    TextColor = Color.Gray,
                    FontFamily= "beer-money12.ttf#Beer Money"
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}