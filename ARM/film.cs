namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.films")]
    public partial class film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public film()
        {
            films_and_actors = new HashSet<films_and_actors>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(8000)]
        public string name { get; set; }

        public int? year { get; set; }

        [StringLength(8000)]
        public string country { get; set; }

        public decimal? budget { get; set; }

        public int? age_limit { get; set; }

        public int? duration { get; set; }

        public int? rating { get; set; }

        [StringLength(8000)]
        public string genre { get; set; }

        public int? company_id { get; set; }

        [StringLength(8000)]
        public string director { get; set; }

        [StringLength(8000)]
        public string composer { get; set; }

        public virtual company company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<films_and_actors> films_and_actors { get; set; }

        public override string ToString() {
            return string.Format("{0} ({1})", name, year);
        }
    }
}
