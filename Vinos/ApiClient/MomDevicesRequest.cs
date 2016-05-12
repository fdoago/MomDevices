using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;
using Vinos.Models;

namespace Vinos.Requests
{
	public class MomDevicesRequest
	{
		public MomDevicesRequest ()
		{
		}

		public void turnOf(String mac){
			try{
				RestClient cliente = new RestClient("http://vacaciones-todo-incluido.com/");
				RestRequest request = new RestRequest("api/v1/giroescopio/turnOff/" + mac, Method.GET);
				request.RequestFormat = DataFormat.Json;
				var Result = cliente.Execute(request);
				//resultado = JsonConvert.DeserializeObject<Boolean>(Result.Content);
			}catch(Exception ex){
				Console.Out.WriteLine("vinos Error: {0}", ex.Message);
			}
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

