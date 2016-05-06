
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


namespace Vinos
{
	[Activity (Label = "Vinos")]			
	public class VinoDetailActivity : Activity
	{
		private vinosDTO vino;
		private TextView name;
		private TextView year;
		private TextView grapes;
		private TextView country;
		private TextView region;
		private TextView description;
		private ImageView img;
		private TextView price;
		private Button agregar;
		private Intent AddWineIntent;
		private ordenDTO orden;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.vinosDetailActivity);
			vino = JsonConvert.DeserializeObject<vinosDTO> (Intent.GetStringExtra ("vino"));
			name = FindViewById<TextView> (Resource.Id.name);
			year = FindViewById<TextView> (Resource.Id.year);
			grapes = FindViewById<TextView> (Resource.Id.grapes);
			country = FindViewById<TextView> (Resource.Id.country);
			region = FindViewById<TextView> (Resource.Id.region);
			description = FindViewById<TextView> (Resource.Id.description);
			img = FindViewById<ImageView> (Resource.Id.img);
			price = FindViewById<TextView> (Resource.Id.price);
			agregar = FindViewById<Button> (Resource.Id.agregar);

			name.Text = vino.name;
			year.Text = vino.year;
			grapes.Text = vino.grapes;
			country.Text = vino.country;
			region.Text = vino.region;
			description.Text = vino.descripcion;
			price.Text = vino.price;

			agregar.Click+= delegate(object sender, EventArgs e) {
				ordenRequest ordenRequestObj = new ordenRequest();
				orden = ordenRequestObj.addProduct(1,vino.id);
				AddWineIntent = new Intent(this, typeof(OrdenAddConfirmationActivity));
				AddWineIntent.PutExtra("orden", JsonConvert.SerializeObject(orden));
				this.StartActivity(AddWineIntent);
			};

		}
	}
}

