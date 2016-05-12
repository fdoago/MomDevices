using System;
using RestSharp;
using Newtonsoft.Json;

namespace Vinos
{
	public class ordenRequest : ApiClient
	{
		public ordenRequest ()
		{
		
		}
			
		public ordenDTO addProduct (int id_user, int id_wine)
		{
			try{
				RestClient cliente = new RestClient(ApiUrl);
				ordenDTO resultado = new ordenDTO();
				RestRequest request = new RestRequest("api/v1/orden/insert/", Method.POST);
				request.RequestFormat = DataFormat.Json;
				request.AddParameter ("id_user", id_user);
				request.AddParameter ("id_wine", id_wine);
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
	}
}

