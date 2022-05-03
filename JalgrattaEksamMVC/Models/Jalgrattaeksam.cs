using System;
using System.Collections.Generic;

#nullable disable

namespace JalgrattaEksamMVC.Models
{
    public partial class Jalgrattaeksam
    {
        public int Id { get; set; }
        public string Eesnimi { get; set; }
        public string Perekonnanimi { get; set; }
        public int? Teooriatulemus { get; set; }
        public int? Slaalom { get; set; }
        public int? Ringtee { get; set; }
        public int? Tanav { get; set; }
        public int? Luba { get; set; }
    }
}
