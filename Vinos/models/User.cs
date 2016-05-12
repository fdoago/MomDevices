using System;

namespace Vinos
{
	public class User
	{
		public int user_id;
		public string nickname, password;


		public User(int user_id, string nickname, string password) {

			this.user_id = user_id;
			this.nickname = nickname;
			this.password = password;
		}
	}
}

