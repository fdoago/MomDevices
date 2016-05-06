using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using Vinos;

namespace Vinos
{
	public class MomDevicesRequest
	{
		public MomDevicesRequest ()
		{
		}

		public List<MomDeviceDTO> get (){
			try{
				RestClient cliente = new RestClient("http://vacaciones-todo-incluido.com/");
				List<MomDeviceDTO> resultado = new List<MomDeviceDTO>();
				RestRequest request = new RestRequest("api/v1/giroescopio/get/", Method.GET);
				request.RequestFormat = DataFormat.Json;
				var Result = cliente.Execute(request);
				resultado = JsonConvert.DeserializeObject<List<MomDeviceDTO>>(Result.Content);
				return resultado;
			}catch(Exception ex){
				Console.Out.WriteLine("vinos Error: {0}", ex.Message);
				return null;
			}
		}
	}
}

