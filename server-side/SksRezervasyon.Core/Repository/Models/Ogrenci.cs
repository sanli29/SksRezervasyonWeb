using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SksRezervasyon.Core.Repository.Models
{
    [Table("Ogrenci")]
    public partial class Ogrenci
    {
        public Ogrenci()
        {
            Kutuphanes = new HashSet<Kutuphane>();
            Misafirhanes = new HashSet<Misafirhane>();
            Tesis = new HashSet<Tesi>();
            Yemekhanes = new HashSet<Yemekhane>();
        }

        [Key]
        [Column("OgrenciID")]
        public int OgrenciId { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Adi { get; set; }
        [StringLength(50)]
        public string Sifre { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        [InverseProperty(nameof(Kutuphane.Ogrenci))]
        public virtual ICollection<Kutuphane> Kutuphanes { get; set; }
        [InverseProperty(nameof(Misafirhane.Ogrenci))]
        public virtual ICollection<Misafirhane> Misafirhanes { get; set; }
        [InverseProperty(nameof(Tesi.Ogrenci))]
        public virtual ICollection<Tesi> Tesis { get; set; }
        [InverseProperty(nameof(Yemekhane.Ogrenci))]
        public virtual ICollection<Yemekhane> Yemekhanes { get; set; }
    }
}
