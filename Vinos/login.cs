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
	[Activity (Label = "Vinos", Theme = "@style/Theme.AppCompat.Light", Icon = "@mipmap/icon")]			
	public class login : Activity
	{
		private Intent MainActivityIntent;
		private EditText email;
		private EditText password;
		private Button sendLogin;
		private TextView message;
		UserLocalStore userLocalStore;
		User userStorage;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.login);
			// Se crea el intent para lanzar la aplicacion principal

			//Objeto que guarda y recupera los datos guardados en localstorage
			userLocalStore = new UserLocalStore(this);



			// Obtenemos los elementos del layout.
			email = FindViewById<EditText>(Resource.Id.textEmailAddress);
			password = FindViewById<EditText>(Resource.Id.passInput);
			sendLogin = FindViewById<Button>(Resource.Id.sendLogin);
			message = FindViewById<TextView> (Resource.Id.message);

			if (userLocalStore.getLoggedInUser() != null) {
				if (userLocalStore.checkRemember () == true) {
					User remembered = userLocalStore.getLoggedInUser ();
					email.Text = remembered.nickname;
					password.Text = remembered.password;
				}
			}

			sendLogin.Click += sendLoginEventFunc;
		}

		// Funcion de envento onclick sendlogin
		private void sendLoginEventFunc(object sender, EventArgs ea){
			UserRequest userRequest = new UserRequest ();
			userDTO user = new userDTO ();
			user = userRequest.login (email.Text, password.Text);
			if(user != null){

				userStorage = new User(user.id, email.Text, password.Text);
				logUserIn (userStorage);

				MainActivityIntent = new Intent(this, typeof(MainActivity));
				//MainActivityIntent = new Intent(this, typeof(MomDeivcesActivity));
				this.StartActivity(MainActivityIntent);
			}else{
				message.Text = "Error en login";
			}
		}

		private void logUserIn(User user) {
			CheckBox remember = FindViewById<CheckBox> (Resource.Id.checkBox1);
			userLocalStore.storeUserData(userStorage);
			userLocalStore.setUserLoggedIn(true);
			userLocalStore.setRemember (remember.Checked);
		}

	}
}

