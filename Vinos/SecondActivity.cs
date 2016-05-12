
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
using Android.Media;
using System.Threading.Tasks;

using Vinos.Requests;


namespace Vinos
{
	[Activity (Label = "SecondActivity")]			
	public class SecondActivity : Activity
	{

		MediaPlayer _player;
		protected MediaPlayer player;
		TextView mac;

		private async void PlayTask( MediaPlayer player){
			Console.WriteLine ("Sound------------------------------------------------------------------------");
		}

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.SecondActivity);
			MomDevicesRequest MomRequest = new MomDevicesRequest();
			mac = FindViewById<TextView> (Resource.Id.mac);
			mac.Text = "Se activo el dispositivo: " + Intent.GetStringExtra ("momDevice");
			Window.AddFlags(WindowManagerFlags.KeepScreenOn|WindowManagerFlags.DismissKeyguard|WindowManagerFlags.ShowWhenLocked|WindowManagerFlags.TurnScreenOn);

			_player = MediaPlayer.Create(this, Resource.Raw.alarm);
			_player.Looping = true;
			_player.Start ();
			Button stopButton = FindViewById<Button> (Resource.Id.stopSound);
			stopButton.Click += delegate {
				MomRequest.turnOf(Intent.GetStringExtra ("momDevice"));
				_player.Stop();
				// le decimos al servicio que ya no se usara la actividad
				App.Current.Service.serviceIntent = null;
				Finish();
			};

			// Create your application here
		}

		public void StartPlayer(String  filePath)
		{
			if (player == null) {
				player = new MediaPlayer();
			} else {
				player.Reset();
				player.SetDataSource(filePath);
				player.Prepare();
				player.Start();
			}
		}
	}
}

