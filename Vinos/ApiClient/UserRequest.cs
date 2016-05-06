using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Widget;
using Newtonsoft.Json;
using RestSharp;

namespace Vinos
{
	public class UserRequest : ApiClient
	{
		public UserRequest ()
		{
			
		}

		public userDTO login (string nickname, string password)
		{
			try{
				RestClient cliente = new RestClient(ApiUrl);
				userDTO resultado = new userDTO();
				RestRequest request = new RestRequest("api/v1/user/login", Method.POST);
				request.RequestFormat = DataFormat.Json;
				request.AddParameter ("nickname", nickname);
				request.AddParameter ("password", password);
				var Result = cliente.Execute(request);
				resultado = JsonConvert.DeserializeObject<userDTO>(Result.Content);
				return resultado;
			}catch(Exception ex){
				Console.Out.WriteLine("Personas Error: {0}", ex.Message);
				return null;
			}
		}
	}
}

