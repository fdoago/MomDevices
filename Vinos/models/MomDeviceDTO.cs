﻿using System;

namespace Vinos.Models
{
	public class MomDeviceDTO
	{
		public int id { get; set;}
		public string giroescopio_x {get; set;}
		public string giroescopio_y {get; set;}
		public string giroescopio_z {get; set;}
		public string acelerometro_x {get; set;}
		public string acelerometro_y {get; set;}
		public string acelerometro_z {get; set;}
		public string mac {get; set;}
		public Boolean active { get; set;}
		public Boolean status { get; set;}
	}
}