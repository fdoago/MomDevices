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
using Android.Support.V4.View;
using Newtonsoft.Json;


namespace Vinos
{
	[Activity (Label = "Confirmacion de pedido")]			
	public class OrdenAddConfirmationActivity : Activity
	{

		private TextView id_orden;
		private TextView fecha;
		private TextView status;
		private ordenDTO orden;
		//Para recuperar los datos guardados
		UserLocalStore userLocalStore;
		User userStorage;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.OrdenAddConfirmation);
			// Create your application here
			id_orden = FindViewById<TextView> (Resource.Id.id_orden);
			fecha = FindViewById<TextView> (Resource.Id.fecha);
			status = FindViewById<TextView> (Resource.Id.status);
			//Inicializamos las variables que recuperan el id
			userLocalStore = new UserLocalStore(this);
			userStorage = userLocalStore.getLoggedInUser();
			orden =  JsonConvert.DeserializeObject<ordenDTO> (Intent.GetStringExtra ("orden"));
			id_orden.Text += orden.id.ToString();
			fecha.Text += orden.fecha.ToString();
			status.Text += orden.status.ToString ();
		}


		public override bool OnCreateOptionsMenu (Android.Views.IMenu menu)
		{

			menu.Add(new Java.Lang.String ("Normal item"));

			var actionItem = menu.Add(new Java.Lang.String ("Action Button"));

			// Items that show as actions should favor the "if room" setting, which will
			// prevent too many buttons from crowding the bar. Extra items will show in the
			// overflow area.
			MenuItemCompat.SetShowAsAction(actionItem, MenuItemCompat.ShowAsActionIfRoom);

			// Items that show as actions are strongly encouraged to use an icon.
			// These icons are shown without a text description, and therefore should
			// be sufficiently descriptive on their own.
			actionItem.SetIcon(Android.Resource.Drawable.IcMenuShare);
			return true;
		}


	}
}

