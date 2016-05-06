using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.AppCompat;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Content;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;


namespace Vinos
{
	[Activity (Label = "Vinos")]			
	public class vinosActivity : Activity
	{
		private Intent VinosDetailIntent;
		private ListView ListVinos;
		private CategoriaDTO categoria;
		private vinosResquest vinosrequest;
		private List<vinosDTO> vinosElements;
		private vinosAdapter vinosadapter;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView(Resource.Layout.vinosActivity);
			ListVinos = FindViewById<ListView> (Resource.Id.ListVinos);
			categoria = JsonConvert.DeserializeObject<CategoriaDTO>(Intent.GetStringExtra ("categoria"));
			vinosrequest = new vinosResquest();
			vinosElements = vinosrequest.get (categoria);
			vinosadapter = new vinosAdapter (this, vinosElements);
			ListVinos.Adapter = vinosadapter;

			ListVinos.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				vinosDTO SelectedItemList = vinosadapter.GetItemAtPosition(e.Position);
				VinosDetailIntent = new Intent(this, typeof(VinoDetailActivity));
				VinosDetailIntent.PutExtra("vino", JsonConvert.SerializeObject(SelectedItemList));
				this.StartActivity(VinosDetailIntent);
			};
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

		public override bool OnOptionsItemSelected (Android.Views.IMenuItem item)
		{
			Android.Widget.Toast.MakeText (this, 
				"Selected Item: " + 
				item.TitleFormatted, 
				Android.Widget.ToastLength.Short).Show();
			VinosDetailIntent = new Intent(this, typeof(VinoDetailActivity));
			this.StartActivity(VinosDetailIntent);
			return true;
		}
	}


}

