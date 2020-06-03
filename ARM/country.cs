namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.countries")]
    public partial class country
    {
        public int id { get; set; }

        [StringLength(8000)]
        public string name { get; set; }
    }
}
