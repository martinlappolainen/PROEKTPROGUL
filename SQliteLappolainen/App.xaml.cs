using Xamarin.Forms;

namespace SQliteLappolainen
{
        public partial class App : Application
        {

            public const string DATABASE_NAME = "friends.db";
            public static FriendRepository database;
            public static FriendRepository Database
            {
                get
                {
                    if (database == null)
                    {
                        database = new FriendRepository(DATABASE_NAME);
                    }
                    return database;
                }
            }

            public App()
            {
                InitializeComponent();
                MainPage = new NavigationPage(new MainPage())
                {
                    BarBackgroundColor=Color.FromHex("#ceefe4"),
                    BarTextColor = Color.Black
                };
            }
                protected override void OnStart() { }
                protected override void OnSleep() { }
                protected override void OnResume() { }
        }
}
