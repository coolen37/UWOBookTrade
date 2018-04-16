using Android.App;
using Android.Widget;
using Android.OS;

namespace UWOBookTrade.Activities {
    [Activity(Label = "UWOBookTrade", MainLauncher = true)]
    public class MainActivity : Activity {
        Button login;
        Button register;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            login = FindViewById<Button>(Resource.Id.btnLogin);
            login.Click += Login_Click;

            register = FindViewById<Button>(Resource.Id.btnRegister);
            register.Click += Register_Click;
        }

        private void Register_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        private void Login_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
        }
    }
}

