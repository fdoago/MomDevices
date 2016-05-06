using System;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;

namespace Vinos
{
	public class vinosAdapter : BaseAdapter<vinosDTO>
	{
		
		private readonly Activity context;
		private readonly List<vinosDTO> vinos;
		private vinosDTO ItemSelected;

		public vinosAdapter (Activity context, List<vinosDTO> vinos)
		{
			this.context = context;
			this.vinos = vinos;
		}


		public vinosDTO getItem(int position){
			return vinos[position];
		}


		public override vinosDTO this[int position]
		{
			get
			{
				return vinos[position];
			}
		}

		public override int Count
		{
			get
			{
				return vinos.Count;
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

		public vinosDTO GetObject (int position){
			return vinos [position];
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; 
			if (view == null) // otherwise create a new one
			{
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
			}
			view.FindViewById<TextView> (Android.Resource.Id.Text1).Text = vinos [position].name.ToString ();
			return view;
		}

		public vinosDTO GetItemAtPosition(int position)
		{
			return vinos[position];
		}

		public void SetItemSelected(int position){
			this.ItemSelected = this.vinos [position];
		}

		public vinosDTO GetItemSelected(){
			return this.ItemSelected;
		}
	}
}

