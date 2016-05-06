using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace Vinos
{
	public class CategoriasRequest: ApiClient
	{
		public List<CategoriaDTO> get(){
			try{
				RestClient cliente = new RestClient(ApiUrl);
				List<CategoriaDTO> resultado = new List<CategoriaDTO>();
				RestRequest request = new RestRequest("api/v1/categorias/get", Method.GET);
				request.RequestFormat = DataFormat.Json;
				var Result = cliente.Execute(request);
				resultado = JsonConvert.DeserializeObject<List<CategoriaDTO>>(Result.Content);
					return resultado;
			}catch(Exception ex){
				Console.Out.WriteLine("Personas Error: {0}", ex.Message);
				return null;
			}	
		}
	}
}

