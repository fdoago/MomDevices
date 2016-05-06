using System;
using Android.App;
using Android.Util;
using System.Threading;
using Android.OS;

namespace Vinos
{
	[Service]
	[IntentFilter (new String[]{"ca.services.MyBoundService"})]
	public class MyService : Service
	{

		IBinder _MyBinder = null;

		public String SayHello(){
			return "Helloworld";	
		}

		private void HeavyBackgroundWork(){
			int count = 0;
			var heavyWorkThread = new Thread (() => {
				while (count++ > 10) {
					Thread.Sleep(1000);
					Log.Debug("MyService", "Heavy work completed");
				}

				//StopSelf();
			});
			heavyWorkThread.Start ();
		}

		public override StartCommandResult OnStartCommand (Android.Content.Intent intent, StartCommandFlags flags, int startId)
		{
			//HeavyBackgroundWork ();
			_MyBinder = new MyServiceBinder(this);
			//return base.OnStartCommand (intent, flags, startId);
			return StartCommandResult.Sticky;
		}

		public override IBinder OnBind (Android.Content.Intent intent)
		{
			Log.Debug ("MyBoundService", "NewClient");
			return _MyBinder;
		}
	}
}

