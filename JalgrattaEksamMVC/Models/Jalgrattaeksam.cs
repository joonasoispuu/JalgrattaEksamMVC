using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace JalgrattaEksamMVC.Models
{
    public partial class Jalgrattaeksam
    {
        public int Id { get; set; }
        [StringLength(64)]
        [Required]
        public string Eesnimi { get; set; }
        [StringLength(64)]
        [Required]
        public string Perekonnanimi { get; set; }
        [Range(-1, 10)]
        public int Teooriatulemus { get; set; } = -1;
        public int Slaalom { get; set; } = -1;
        public int Ringtee { get; set; } = -1;
        public int Tanav { get; set; } = -1;
        public int Luba { get; set; } = -1;
    }
}
