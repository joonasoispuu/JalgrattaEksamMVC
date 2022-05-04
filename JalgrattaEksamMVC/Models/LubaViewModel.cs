using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JalgrattaEksamMVC.Models
{
	public class LubaViewModel
	{
		public int Id { get; set; }
		public string Eesnimi { get; set; }
		public string Perekonnanimi { get; set; }
		public int Teooriatulemus { get; set; }
		public string Slaalom { get; set; }
		public string Ringtee { get; set; }
		public string Tanav { get; set; }
		public string Luba { get; set; }
	}
}