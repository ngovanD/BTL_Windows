namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        public int MaNhanVien { get; set; }

        [StringLength(100)]
        public string HoTen { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        public int? NgayCong { get; set; }

        public int? Luong1Ngay { get; set; }

        public int? Thuong { get; set; }

        public int? ID { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
