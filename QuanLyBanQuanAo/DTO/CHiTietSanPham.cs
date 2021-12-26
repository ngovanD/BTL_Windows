namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHiTietSanPham")]
    public partial class CHiTietSanPham
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSanPham { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_KichThuoc { get; set; }

        public int? SoLuongCon { get; set; }

        public virtual KichThuoc KichThuoc { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
