using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SksRezervasyon.Core.Repository.Models
{
    [Table("Yemekhane")]
    public partial class Yemekhane
    {
        [Key]
        [Column("YemekhaneID")]
        public int YemekhaneId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }
        [Column("OgrenciID")]
        public int? OgrenciId { get; set; }
        public int? IsRandevu { get; set; }
        [StringLength(50)]
        public string Fiyat { get; set; }
        [StringLength(50)]
        public string Ogun { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(OgrenciId))]
        [InverseProperty("Yemekhanes")]
        public virtual Ogrenci Ogrenci { get; set; }
    }
}
