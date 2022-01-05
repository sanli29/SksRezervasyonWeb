using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SksRezervasyon.Core.Repository.Models
{
    [Table("Kutuphane")]
    public partial class Kutuphane
    {
        [Key]
        [Column("KutuphaneID")]
        public int KutuphaneId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }
        [StringLength(50)]
        public string BaslangicSaati { get; set; }
        public int? OdaNo { get; set; }
        [Column("OgrenciID")]
        public int? OgrenciId { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey(nameof(OgrenciId))]
        [InverseProperty("Kutuphanes")]
        public virtual Ogrenci Ogrenci { get; set; }
    }
}
