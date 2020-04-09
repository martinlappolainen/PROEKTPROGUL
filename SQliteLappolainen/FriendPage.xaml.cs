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
    public partial class FriendPage : ContentPage
    {
        public FriendPage()
        {
            InitializeComponent();
        }
        private async void SaveFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            if (!String.IsNullOrEmpty(friend.Name) && 
            !String.IsNullOrEmpty(friend.Phone) && 
            !String.IsNullOrEmpty(friend.Opis)&&
            !String.IsNullOrEmpty(friend.Email) &&
            !String.IsNullOrWhiteSpace(friend.Name) &&
            !String.IsNullOrWhiteSpace(friend.Phone) &&
            !String.IsNullOrWhiteSpace(friend.Opis) &&
            !String.IsNullOrWhiteSpace(friend.Email) &&
            friend.Email.Contains("@"))
            {
                App.Database.SaveItem(friend);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Ошибка", "Заполните поля правильно", "ОК");
            }
        }
        private void DeleteFriend(object sender, EventArgs e)
        {
            var friend = (Friend)BindingContext;
            App.Database.DeleteItem(friend.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}