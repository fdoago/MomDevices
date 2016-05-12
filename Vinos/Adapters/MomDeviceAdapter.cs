/*using System;

namespace Vinos
{
	public class MomDeviceAdapter
	{
		public MomDeviceAdapter ()
		{
		}
	}
}
*/
using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Vinos.Models;

namespace Vinos
{
	public class MomDeviceAdapter : BaseAdapter<MomDeviceDTO>
	{
		private readonly Activity context;
		private readonly List<MomDeviceDTO> MomDevices;
		private MomDeviceDTO ItemSelected;

		public MomDeviceAdapter (Activity context, List<MomDeviceDTO> momdevices)
		{
			this.context = context;
			this.MomDevices = momdevices;
		}


		public MomDeviceDTO getItem(int position){
			return MomDevices[position];
		}


		public override MomDeviceDTO this[int position]
		{
			get
			{
				return MomDevices[position];
			}
		}

		public override int Count
		{
			get
			{
				return MomDevices.Count;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override Java.Lang.Object GetItem (int position) {
			// could wrap a Contact in a Java.Lang.Object
			// to return it here if needed
			return null;
		}

		public MomDeviceDTO GetObject (int position){
			return MomDevices [position];
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; 
			if (view == null) // otherwise create a new one
			{
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
			}
			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = MomDevices[position].mac.ToString();
			return view;
		}

		public MomDeviceDTO GetItemAtPosition(int position)
		{
			return MomDevices[position];
		}

		public void SetItemSelected(int position){
			this.ItemSelected = this.MomDevices [position];
		}

		public MomDeviceDTO GetItemSelected(){
			return this.ItemSelected;
		}


	}
}



