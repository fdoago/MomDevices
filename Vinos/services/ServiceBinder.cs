using System;
using Android.OS;

namespace Vinos.service
{
	public class ServiceBinder : Binder
	{
		public ServiceClass Service
		{
			get { return this.service; }
		} protected ServiceClass service;

		public bool IsBound { get; set; }

		// constructor
		public ServiceBinder (ServiceClass service)
		{
			this.service = service;
		}
	}
}

