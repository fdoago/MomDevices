using System;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Vinos
{
	public class ordenRequest : ApiClient
	{
		public ordenRequest ()
		{
		
		}
			
		public ordenDTO addProduct (int id_user, int id_wine, int cantidad)
		{
			try{
				RestClient cliente = new RestClient(ApiUrl);
				ordenDTO resultado = new ordenDTO();
				RestRequest request = new RestRequest("api/v1/orden/insert/", Method.POST);
				request.RequestFormat = DataFormat.Json;
				request.AddParameter ("id_user", id_user);
				request.AddParameter ("id_wine", id_wine);
				request.AddParameter ("cantidad", cantidad);
				var Result = cliente.Execute(request);
				resultado = JsonConvert.DeserializeObject<ordenDTO>(Result.Content);
				return resultado;
			}catch(Exception ex){
				Console.Out.WriteLine("Personas Error: {0}", ex.Message);
				return null;
			}
		}

		public ordenDTO getOrder (int id_user)
		{
			try{
				RestClient cliente = new RestClient(ApiUrl);
				ordenDTO resultado = new ordenDTO();
				RestRequest request = new RestRequest("api/v1/orden/ordenactiva/" + id_user.ToString(), Method.GET);
				request.RequestFormat = DataFormat.Json;
				var Result = cliente.Execute(request);
				resultado = JsonConvert.DeserializeObject<ordenDTO>(Result.Content);
				return resultado;
			}catch(Exception ex){
				Console.Out.WriteLine("Retrieve Order Error: {0}", ex.Message);
				return null;
			}
		}

		public List<ordenVinosDTO> getOrderList (int id_order)
		{
			try{
				RestClient cliente = new RestClient(ApiUrl);
				List<ordenVinosDTO> resultado = new List<ordenVinosDTO>();
				RestRequest request = new RestRequest("api/v1/orden/productosorden/" + id_order.ToString(), Method.GET);
				request.RequestFormat = DataFormat.Json;
				var Result = cliente.Execute(request);
				resultado = JsonConvert.DeserializeObject<List<ordenVinosDTO>>(Result.Content);
				return resultado;
			}catch(Exception ex){
				Console.Out.WriteLine("Retrieve Order List Error: {0}", ex.Message);
				return null;
			}
		}
	}
}

