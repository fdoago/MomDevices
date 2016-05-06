using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Vinos;

namespace Vinos
{
	[Activity (Label = "Vinos", Theme = "@style/Theme.AppCompat.Light", Icon = "@mipmap/icon", MainLauncher = true)]			
	public class login : Activity
	{
		private Intent MainActivityIntent;
		private EditText email;
		private EditText password;
		private Button sendLogin;
		private TextView message;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.login);
			// Se crea el intent para lanzar la aplicacion principal

			// Obtenemos los elementos del layout.
			email = FindViewById<EditText>(Resource.Id.textEmailAddress);
			password = FindViewById<EditText>(Resource.Id.passInput);
			sendLogin = FindViewById<Button>(Resource.Id.sendLogin);
			message = FindViewById<TextView> (Resource.Id.message);
			sendLogin.Click += sendLoginEventFunc;
		}

		// Funcion de envento onclick sendlogin
		private void sendLoginEventFunc(object sender, EventArgs ea){
			UserRequest userRequest = new UserRequest ();
			userDTO user = new userDTO ();
			user = userRequest.login (email.Text, password.Text);
			if(user != null){
				MainActivityIntent = new Intent(this, typeof(MainActivity));
				this.StartActivity(MainActivityIntent);
			}else{
				message.Text = "Error en login";
			}
		}
	}
}

