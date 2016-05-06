using System;
using Android.OS;

namespace Vinos.service
{
	public class ServiceConnectedEventArgs : EventArgs
	{
		public IBinder Binder { get; set; }
	}
}