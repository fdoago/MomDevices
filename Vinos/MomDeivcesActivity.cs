
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
using Vinos.service;
using Android.Util;

namespace Vinos
{
	[Activity (Label = "Moms Deivces")]			
	public class MomDeivcesActivity : Activity
	{
		String notifyMsg;
		readonly string logTag = "MainActivity";

		protected override void OnCreate (Bundle savedInstanceState)
		{


			base.OnCreate (savedInstanceState);
			Log.Debug (logTag, "OnCreate: Location app is becoming active");

			// Set the view from the "main" layout resource
			SetContentView(Resource.Layout.MomDevices);

			// Get the notifications manager:
			NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;


			notifyMsg  = "Notification message text goes here. ";
			notifyMsg += "You can modify the message in this text box ";
			notifyMsg += "before tapping LAUNCH NOTIFICATION, or you can ";
			notifyMsg += "just use this default text.";

			// Get notification launch button from the layout:
			Button launchBtn = FindViewById<Button>(Resource.Id.launchButton);

			launchBtn.Click += delegate {
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


				// Launch notification:
				notificationManager.Notify(notificationId, notification);


				// Uncomment this code to update the notification 5 seconds later:
				//Thread.Sleep(5000);
				// builder.SetContentTitle("Updated Notification");
				// builder.SetContentText("Changed to this message after five seconds.");
				// notification = builder.Build();
				// notificationManager.Notify(notificationId, notification);
			};


		}
	}
}

