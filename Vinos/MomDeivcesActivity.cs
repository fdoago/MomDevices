
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
using Vinos.Requests;
using Vinos.Models;

namespace Vinos
{
	[Activity (Label = "Moms Deivces", MainLauncher = true	)]			
	public class MomDeivcesActivity : Activity
	{
		String notifyMsg;
		readonly string logTag = "MainActivity";
		ListView MomDeviceListView;
		private List<string> MomDevicesDataSet;

		protected override void OnCreate (Bundle savedInstanceState)
		{


			base.OnCreate (savedInstanceState);

			// Set the view from the "main" layout resource
			SetContentView(Resource.Layout.MomDevices);

			MomDevicesRequest momDevicesRequest = new MomDevicesRequest ();
			List<MomDeviceDTO> momDevices = new List<MomDeviceDTO> ();
			MomDevicesDataSet = new List<string> ();
			momDevices = momDevicesRequest.get ();

			MomDeviceListView = FindViewById<ListView> (Resource.Id.momDeviceList);
			MomDeviceListView.Tag = 0;


			MomDeviceAdapter momDevicesAdaptar = new MomDeviceAdapter(this, momDevices);
			MomDeviceListView.FastScrollEnabled = true;
			MomDeviceListView.Adapter = momDevicesAdaptar;

			App.StartLocationService();





		}
	}
}

