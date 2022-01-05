using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SksRezervasyon.Core.Repository.Models
{
    [Table("Misafirhane")]
    public partial class Misafirhane
    {
        [Key]
        [Column("MisafirhaneID")]
        public int MisafirhaneId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? GirisTarihi { get; set; }
        [StringLength(50)]
        public string OdaTuru { get; set; }
        [Column("OgrenciID")]
        public int? OgrenciId { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(OgrenciId))]
        [InverseProperty("Misafirhanes")]
        public virtual Ogrenci Ogrenci { get; set; }
    }
}
