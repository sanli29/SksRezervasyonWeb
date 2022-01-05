using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SksRezervasyon.Core.Repository.Models
{
    [Table("Tesis")]
    public partial class Tesi
    {
        [Key]
        [Column("TesisID")]
        public int TesisId { get; set; }
        [StringLength(50)]
        public string TesisTur { get; set; }
        [StringLength(50)]
        public string BaslangicSaati { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }
        [Column("OgrenciID")]
        public int? OgrenciId { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(OgrenciId))]
        [InverseProperty("Tesis")]
        public virtual Ogrenci Ogrenci { get; set; }
    }
}
