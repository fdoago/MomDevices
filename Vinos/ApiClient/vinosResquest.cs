using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace Vinos
{
	public class vinosResquest
	{
		public vinosResquest ()
		{
			
		}

		public List<vinosDTO> get (CategoriaDTO categoria){
			try{
				RestClient cliente = new RestClient("http://vacaciones-todo-incluido.com/");
				List<vinosDTO> resultado = new List<vinosDTO>();
				RestRequest request = new RestRequest("api/v1/vinos/getbycategory/" + categoria.id, Method.GET);
				request.RequestFormat = DataFormat.Json;
				var Result = cliente.Execute(request);
				resultado = JsonConvert.DeserializeObject<List<vinosDTO>>(Result.Content);
				return resultado;
			}catch(Exception ex){
				Console.Out.WriteLine("vinos Error: {0}", ex.Message);
				return null;
			}
		}
	}
}

