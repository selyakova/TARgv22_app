using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilePage : ContentPage
	{
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public FilePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateFileList();
        }

        private void UpdateFileList()
        {
            fList.ItemsSource = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f));
            fList.SelectedItem = null;
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            string filename = (string)((MenuItem)sender).BindingContext;
            File.Delete(Path.Combine(folderPath, filename));
            UpdateFileList();
        }

        private void filesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            string filename = (string)e.SelectedItem;
            tEditor.Text = File.ReadAllText(Path.Combine(folderPath, (string)e.SelectedItem));
            fEntry.Text = filename;
            fList.SelectedItem = null;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string filename = fEntry.Text;
            if (String.IsNullOrEmpty(filename)) return;
            if (File.Exists(Path.Combine(folderPath, filename)))
            {
                bool isRewrited = await DisplayAlert("Kinnitus", "Fail on juba olemas, Kas salvestada ümber?", "Jah", "Ei");
                if (isRewrited == false) return;
            }
            File.WriteAllText(Path.Combine(folderPath, filename), tEditor.Text);
            UpdateFileList();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            string fileName = (string)((MenuItem)sender).BindingContext;
            File.Delete(Path.Combine(folderPath, fileName));
            UpdateFileList();
        }

        private void ToList_Clicked(object sender, EventArgs e)
        {
            string fileName = (String)((MenuItem)sender).BindingContext;
            List<string> järjend = File.ReadLines(Path.Combine(folderPath, fileName)).ToList();
            list.ItemsSource = järjend;
        }
    }
}