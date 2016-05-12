using System;

using Android.App;
using Android.Util;
using Android.Content;
using Android.OS;
using System.Threading;
using Vinos;
using System.Collections.Generic;
using Vinos.Requests;
using Vinos.Models;

using Vinos.Models;
using Vinos.Requests;

namespace Vinos.service
{
	[Service]
	public class ServiceClass : Service
	{
		
		String notifyMsg;
		MomDevicesRequest MomRequest = new MomDevicesRequest();
		List<MomDeviceDTO> MomDeviceList = new List<MomDeviceDTO>();
		public Intent serviceIntent {
			get;
			set;
		} 

		public ServiceClass ()
		{
		}

		IBinder binder;
		readonly string logTag = "NotificationService";


		public override void OnCreate ()
		{
			base.OnCreate ();
			Log.Debug (logTag, "OnCreate called in the Service");
			this.serviceIntent = null;
		}

		// This gets called when StartService is called in our App class
		[Obsolete("deprecated in base class")]
		public override StartCommandResult OnStartCommand (Intent intent, StartCommandFlags flags, int startId)
		{
			Log.Debug (logTag, "Service started");

			return StartCommandResult.Sticky;
		}

		// This gets called once, the first time any client bind to the Service
		// and returns an instance of the LocationServiceBinder. All future clients will
		// reuse the same instance of the binder
		public override IBinder OnBind (Intent intent)
		{
			Log.Debug (logTag, "Client now bound to service");

			binder = new ServiceBinder (this);
			return binder;
		}

		public void HeavyBackgroundWork(){
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

		// Handle location updates from the location manager
		public void StartUpdates () 
		{
			var t = new Thread (() => {
				// Obtenemos los valores de los dispositivos que creamos.
				while (true) {
					Thread.Sleep (10000);
					MomDeviceList = MomRequest.get();
					foreach (MomDeviceDTO MomDevice in MomDeviceList) {
						if (MomDevice.status == true && MomDevice.active == true && this.serviceIntent == null) {
							
							/*NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
							notifyMsg  = "Notification message text goes here. ";
							notifyMsg += "You can modify the message in this text box ";
							notifyMsg += "before tapping LAUNCH NOTIFICATION, or you can ";
							notifyMsg += "just use this default text.";
							Notification.Builder builder = new Notification.Builder(this)
								.SetContentTitle("Sample Notification")
								.SetContentText(notifyMsg)
								.SetSmallIcon(Resource.Drawable.abc_seekbar_thumb_material)
								.SetAutoCancel(true);
							builder.SetContentTitle("Big Text Notification");
							var textStyle = new Notification.BigTextStyle();
							textStyle.BigText(notifyMsg);
							textStyle.SetSummaryText("The summary text goes here.");
							builder.SetStyle(textStyle);
							builder.SetVisibility(NotificationVisibility.Public);
							builder.SetPriority((int)NotificationPriority.Max);
							builder.SetCategory(Notification.CategoryAlarm);
							TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
							stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(SecondActivity)));
							stackBuilder.AddNextIntent(serviceIntent);
							const int pendingIntentId = 0;
							PendingIntent pendingIntent = stackBuilder.GetPendingIntent(pendingIntentId, PendingIntentFlags.OneShot);
							builder.SetContentIntent(pendingIntent);
							Notification notification = builder.Build();
							notification.Defaults |= NotificationDefaults.Sound;
							notification.Defaults |= NotificationDefaults.Vibrate;
							const int notificationId = 1;

							*/
							Console.WriteLine("Sleep for 15 seconds.");
							Console.WriteLine("start intent.");
							//notificationManager.Notify(notificationId, notification);

							// Se crea el intent
							serviceIntent = new Intent(this, typeof(SecondActivity));
							serviceIntent.PutExtra("momDevice", MomDevice.mac);
							serviceIntent.SetFlags(ActivityFlags.NewTask);
							StartActivity(serviceIntent);

						}
					}
				}				
				StopSelf ();
			}
			);
			t.Start ();






		

			// Uncomment this code to update the notification 5 seconds later:
			//Thread.Sleep(5000);
			// builder.SetContentTitle("Updated Notification");
			// builder.SetContentText("Changed to this message after five seconds.");
			// notification = builder.Build();
			// notificationManager.Notify(notificationId, notification);
			Log.Debug (logTag, "Now sending updates");
		}

		public override void OnDestroy ()
		{
			base.OnDestroy ();
			Log.Debug (logTag, "Service has been terminated");
		}
	}
}

