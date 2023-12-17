using System;
using Plugin.Messaging;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablePage : ContentPage
    {
        TableView tableView;
        SwitchCell switchCell;
        ImageCell imageCell;
        TableSection photoSection, additionalOptionsSection;

        EntryCell name = new EntryCell { Label = "Nimi: ", Placeholder = "", Keyboard = Keyboard.Default };
        EntryCell tel = new EntryCell { Label = "Tel:", Placeholder = "", Keyboard = Keyboard.Telephone };
        EntryCell sonum = new EntryCell { Label = "SMS:", Placeholder = "", Keyboard = Keyboard.Text };
        EntryCell email = new EntryCell { Label = "e-post:", Placeholder = "", Keyboard = Keyboard.Email };
        Editor ed = new Editor { Placeholder = "Kirjuta oma sõnum:", Keyboard = Keyboard.Default, AutoSize = EditorAutoSizeOption.TextChanges, HorizontalOptions = LayoutOptions.FillAndExpand };

        public TablePage()
        {
            photoSection = new TableSection();
            switchCell = new SwitchCell { Text = "Näita veel" };
            switchCell.OnChanged += SwitchCell_OnChanged;
            imageCell = new ImageCell
            {
                ImageSource = "smile.png",
                Text = "Foto nimetus",
                Detail = "Foto kirjeldus"
            };
            Button callButton = new Button { Text = "Call" };
            callButton.Clicked += CallButton_Clicked;
            Button smsButton = new Button { Text = "SMS" };
            smsButton.Clicked += SmsButton_Clicked;
            Button mailButton = new Button { Text = "e-post" };
            mailButton.Clicked += MailButton_Clicked;

            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmed:")
                {
                    new TableSection("Põhiandmed:")
                    {
                        name
                    },

                    new TableSection("Kontakti andmed:")
                    {

                        tel,
                        email,
                        sonum,
                        switchCell
                    },

                    photoSection,

                    new TableSection("")
                    {
                        new ViewCell
                        {
                            View = new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                Children =
                                {
                                    callButton
                                }

                            }
                        },
                        new ViewCell
                        {
                            View = new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                Children =
                                {
                                    smsButton
                                }
                            }
                        },

                        new ViewCell
                        {
                            View = new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                Children =
                                {
                                    mailButton
                                }

                            }
                        },
                        new ViewCell
                        {
                            View = new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                Children =
                                {
                                    ed
                                }
                            }
                        },
                    }
                }
            };

            Content = tableView;
        }

        private void MailButton_Clicked(object sender, EventArgs e)
        {
            var mail = CrossMessaging.Current.EmailMessenger;
            if (mail.CanSendEmail)
            {
                mail.SendEmail(email.Text, "Hello World!", ed.Text);
            }
        }

        private void SmsButton_Clicked(object sender, EventArgs e)
        {
            var sms = CrossMessaging.Current.SmsMessenger;
            if (sms.CanSendSms)
            {
                sms.SendSms(tel.Text, sonum.Text);
            }
        }

        private void CallButton_Clicked(object sender, EventArgs e)
        {
            var call = CrossMessaging.Current.PhoneDialer;
            if (call.CanMakePhoneCall)
            {
                call.MakePhoneCall(tel.Text);
            }
        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                photoSection.Title = "Foto: ";
                photoSection.Add(imageCell);
                switchCell.Text = "Peida";
            }
            else
            {
                photoSection.Title = "";
                photoSection.Remove(imageCell);
                switchCell.Text = "Naita";
            }
        }
    }
}
