namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.users")]
    public partial class user
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string login { get; set; }

        [Required]
        [MaxLength(2147483647)]
        public byte[] password_hash { get; set; }

        [Required]
        [StringLength(100)]
        public string salt { get; set; }

        [Column(TypeName = "date")]
        public DateTime registration_date { get; set; }

        [Required]
        [StringLength(50)]
        public string role { get; set; }
    }
}
