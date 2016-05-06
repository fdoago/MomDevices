using System;

using Android.App;
using Android.Util;
using Android.Content;
using Android.OS;
using System.Threading;


namespace Vinos.service
{
	[Service]
	public class ServiceClass : Service
	{
		String notifyMsg;

		public ServiceClass ()
		{
		}

		IBinder binder;
		readonly string logTag = "NotificationService";


		public override void OnCreate ()
		{
			base.OnCreate ();
			Log.Debug (logTag, "OnCreate called in the Service");
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


			Console.WriteLine("Sleep for 10 seconds.");

			// Get the notifications manager:
			NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;


			notifyMsg  = "Notification message text goes here. ";
			notifyMsg += "You can modify the message in this text box ";
			notifyMsg += "before tapping LAUNCH NOTIFICATION, or you can ";
			notifyMsg += "just use this default text.";


			// Instantiate the notification builder:
			Notification.Builder builder = new Notification.Builder(this)
				.SetContentTitle("Sample Notification")
				.SetContentText(notifyMsg)
				.SetSmallIcon(Resource.Drawable.abc_seekbar_thumb_material)
				.SetAutoCancel(true);

			// Set the title for demo purposes:
			builder.SetContentTitle("Big Text Notification");

			// Using the Big Text style:
			var textStyle = new Notification.BigTextStyle();

			// Use the text in the edit box at the top of the screen.
			textStyle.BigText(notifyMsg);
			textStyle.SetSummaryText("The summary text goes here.");

			// Plug this style into the builder:
			builder.SetStyle(textStyle);

			// Set visibility based on Visibility spinner selection:
			builder.SetVisibility(NotificationVisibility.Public);

			// Set priority based on Priority spinner selection:
			builder.SetPriority((int)NotificationPriority.Max);

			// Set category based on Category spinner selection:
			builder.SetCategory(Notification.CategoryAlarm);

			// Setup an intent for SecondActivity:
			Intent secondIntent = new Intent (this, typeof(SecondActivity));

			// Pass the current notification string value to SecondActivity:
			secondIntent.PutExtra ("message", notifyMsg);

			// Pressing the Back button in SecondActivity exits the app:
			TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);

			// Add the back stack for the intent:
			stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(SecondActivity)));

			// Push the intent (that starts SecondActivity) onto the stack. The
			// pending intent can be used only once (one shot):
			stackBuilder.AddNextIntent(secondIntent);
			const int pendingIntentId = 0;
			PendingIntent pendingIntent = stackBuilder.GetPendingIntent(pendingIntentId, PendingIntentFlags.OneShot);

			// Uncomment this code to setup an intent so that notifications return to this app:
			// Intent intent = new Intent (this, typeof(MainActivity));
			// const int pendingIntentId = 0;
			// pendingIntent = PendingIntent.GetActivity (this, pendingIntentId, intent, PendingIntentFlags.OneShot);
			// builder.SetContentText("Hello World! This is my first action notification!");

			// Launch SecondActivity when the users taps the notification:
			builder.SetContentIntent(pendingIntent);

			// Build the notification:
			Notification notification = builder.Build();

			// Turn on sound if the sound switch is on:
			notification.Defaults |= NotificationDefaults.Sound;
			//builder.SetSound (RingtoneManager.GetDefaultUri(RingtoneType.Alarm));
			// Turn on vibrate if the sound switch is on:
			notification.Defaults |= NotificationDefaults.Vibrate;

			// Notification ID used for all notifications in this app.
			// Reusing the notification ID prevents the creation of 
			// numerous different notifications as the user experiments
			// with different notification settings -- each launch reuses
			// and updates the same notification.
			const int notificationId = 1;

			while (true) {
				// Launch notification:
				notificationManager.Notify(notificationId, notification);
				Thread.Sleep(15000);
				//Timer(15000);
			}


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

