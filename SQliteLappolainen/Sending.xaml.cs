using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQliteLappolainen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sending : ContentPage
    {
        public Sending()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            friendsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        private async void FriendsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Friend selectedFriend = (Friend)e.SelectedItem;
            FriendPage friendPage = new FriendPage();
            friendPage.BindingContext = selectedFriend;
            var action = await DisplayActionSheet("Отправить с помощью", "Cancel", null, "Электронной почты", "Смс", "Звонка");
            switch (action)
            {
               case "Смс":
                    var smsMessenger = CrossMessaging.Current.SmsMessenger;
                   if (smsMessenger.CanSendSms)
                       smsMessenger.SendSms(selectedFriend.Phone, "Здраствуйте" + " " +selectedFriend.Name + "\n" + selectedFriend.Opis);
                    break;
                case "Электронной почты":
                    var emailMessenger = CrossMessaging.Current.EmailMessenger;
                    if (emailMessenger.CanSendEmail)
                    {
                        emailMessenger.SendEmail(selectedFriend.Email, "Здраствуйте" + " " + selectedFriend.Name + "\n" + selectedFriend.Opis);
                    }
                    break;
                case "Звонка":
                    var TelephoneCall = CrossMessaging.Current.PhoneDialer;
                    if(TelephoneCall.CanMakePhoneCall)
                    {
                        TelephoneCall.MakePhoneCall(selectedFriend.Phone);
                    }
                    break;
                case "Cancel":
                    break;
            }
        }
    }
}