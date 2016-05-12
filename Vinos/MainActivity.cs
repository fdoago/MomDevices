using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.AppCompat;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Content;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Android.Util;
using Vinos;
using System.Threading.Tasks;
using System.Threading;


namespace Vinos
{
	[Activity (Label = "MomDevices", Theme = "@style/Theme.AppCompat.Light", Icon = "@mipmap/icon")]                        
	public class MainActivity : ActionBarActivity
	{
		private ListView ListCategoria;
		private CategoriasAdapter categoriasAdapter;
		private List<string> CategoriasDataSet;
		private Intent vinosIntent;

		// Binder

		private MyServiceBinder _Mybinder;
		private Boolean _IsBound;

		public MyServiceBinder Binder{
			get{ return _Mybinder; }
			set{ _IsBound=true; }
		}

		public Boolean IsBound{
			get{ return _IsBound; }
			set{ _IsBound = value; }
		}

		public void ConsumeService(){
			Log.Debug ("MainActivity",_Mybinder.BoundService.SayHello());
		}


		protected async override void OnCreate (Bundle bundle){
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			CategoriasRequest categoriaRequest = new CategoriasRequest ();
			List<CategoriaDTO> categorias = new List<CategoriaDTO> ();
			CategoriasDataSet = new List<string> ();
			categorias = categoriaRequest.get ();
			ListCategoria = FindViewById<ListView> (Resource.Id.ListCategoria);
			ListCategoria.Tag = 0;

			// Custom adapter
			categoriasAdapter = new CategoriasAdapter(this, categorias);
			ListCategoria.FastScrollEnabled = true;
			ListCategoria.Adapter = categoriasAdapter;

			

			ListCategoria.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				CategoriaDTO selectedFromList = categoriasAdapter.GetItemAtPosition(e.Position);
				vinosIntent = new Intent(this, typeof(vinosActivity));
				vinosIntent.PutExtra("categoria", JsonConvert.SerializeObject(selectedFromList));
				this.StartActivity(vinosIntent);
			};

			App.StartLocationService();

			// Start the location service:
			//await Task.Run (() => App.StartLocationService());
		//StartService(new Intent(this, typeof(MyService)));
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
			vinosIntent = new Intent(this, typeof(vinosActivity));
			vinosIntent.PutExtra ("categoria", item.ToString()); 
			this.StartActivity(vinosIntent);
			return true;
		}
	}
}