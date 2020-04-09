using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Messaging; 

namespace SQliteLappolainen
{
    
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public bool smsSpam;
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void CreateFriend(object sender, EventArgs e)
        {
            Friend friend = new Friend();
            FriendPage friendPage = new FriendPage();
            friendPage.BindingContext = friend;
            await Navigation.PushAsync(friendPage);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Otmaza otmaza = new Otmaza();
            await Navigation.PushAsync(otmaza);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Sending send = new Sending();
            await Navigation.PushAsync(send);
        }
    }
}
