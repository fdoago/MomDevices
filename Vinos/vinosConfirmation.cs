
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
using Newtonsoft.Json;
using Android.Support.V4.View;
using Android.Support.V7.App;

namespace Vinos
{
	[Activity (Label = "Confirmación")]                     
	public class vinosConfirmation : Activity
	{
		private ListView ListOrder;
		private vinosListAdapter vinosListAdapter;
		private List<string> VinosListaDataSet;
		private Intent vinosIntent;
		private int order;

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
			//Log.Debug ("MainActivity",_Mybinder.BoundService.SayHello());
		}


		protected async override void OnCreate (Bundle bundle){
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.vinosConfirmation);
			order = Intent.GetIntExtra ("order_id", 0);
			ordenRequest ordenRequest = new ordenRequest ();
			List<ordenVinosDTO> listaVinos = new List<ordenVinosDTO> ();
			VinosListaDataSet = new List<string> ();
			listaVinos = ordenRequest.getOrderList (order);
			ListOrder = FindViewById<ListView> (Resource.Id.ListOrder);
			ListOrder.Tag = 0;

			// Custom adapter
			vinosListAdapter = new vinosListAdapter(this, listaVinos);
			ListOrder.FastScrollEnabled = true;
			ListOrder.Adapter = vinosListAdapter;



			ListOrder.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				
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
			return true;
		}
	}
}

