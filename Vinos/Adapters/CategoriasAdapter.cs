using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace Vinos
{
	public class CategoriasAdapter : BaseAdapter<CategoriaDTO>
	{
		private readonly Activity context;
		private readonly List<CategoriaDTO> Categorias;
		private CategoriaDTO ItemSelected;

		public CategoriasAdapter (Activity context, List<CategoriaDTO> categorias)
		{
			this.context = context;
			this.Categorias = categorias;
		}


		public CategoriaDTO getItem(int position){
			return Categorias[position];
		}


		public override CategoriaDTO this[int position]
		{
			get
			{
				return Categorias[position];
			}
		}

		public override int Count
		{
			get
			{
				return Categorias.Count;
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

		public CategoriaDTO GetObject (int position){
			return Categorias [position];
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; 
			if (view == null) // otherwise create a new one
			{
				view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
			}
			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = Categorias[position].nombre.ToString();
			return view;
		}

		public CategoriaDTO GetItemAtPosition(int position)
		{
			return Categorias[position];
		}

		public void SetItemSelected(int position){
			this.ItemSelected = this.Categorias [position];
		}

		public CategoriaDTO GetItemSelected(){
			return this.ItemSelected;
		}


	}
}

