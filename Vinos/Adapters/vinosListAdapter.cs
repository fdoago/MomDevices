using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;

namespace Vinos
{
	public class vinosListAdapter : BaseAdapter<ordenVinosDTO>
	{

		private readonly Activity context;
		private readonly List<ordenVinosDTO> vinos;
		private ordenVinosDTO ItemSelected;

		public vinosListAdapter (Activity context, List<ordenVinosDTO> vinos)
		{
			this.context = context;
			this.vinos = vinos;
		}


		public ordenVinosDTO getItem(int position){
			return vinos[position];
		}


		public override ordenVinosDTO this[int position]
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

		public ordenVinosDTO GetObject (int position){
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

		public ordenVinosDTO GetItemAtPosition(int position)
		{
			return vinos[position];
		}

		public void SetItemSelected(int position){
			this.ItemSelected = this.vinos [position];
		}

		public ordenVinosDTO GetItemSelected(){
			return this.ItemSelected;
		}
	}
}

