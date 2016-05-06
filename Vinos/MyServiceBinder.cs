using System;
using Android.OS;
using Android.Util;

namespace Vinos
{
	public class MyServiceBinder : Binder 
	{
		private MyService _myBoundService;

		public MyService BoundService {
			get{return _myBoundService;}
		}

		public MyServiceBinder (MyService _myBoundService){
			this._myBoundService = _myBoundService;
			Log.Debug ("MyBoundServiceBinder", "NewBinder");
		}
	}
}

