using System;
using System.Collections.Generic;

namespace Vinos
{
	public class producto
	{
		public int id { get; set; }
		public string nombre { get; set; }
		public string descipcion { get; set;}
		public double precio { get; set; }
		public List<categoria> categoria { get; set;}

		public producto ()
		{
			
		}
	}
}

