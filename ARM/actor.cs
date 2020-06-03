namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.actors")]
    public partial class actor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public actor()
        {
            films_and_actors = new HashSet<films_and_actors>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(8000)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        [StringLength(8000)]
        public string country { get; set; }

        [StringLength(8000)]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<films_and_actors> films_and_actors { get; set; }

        public override string ToString() {
            return string.Format("{0} ({1}, {2})", name, birthday.HasValue ? birthday.Value.ToShortDateString() : DateTime.MinValue.Date.ToShortDateString(), country );
        }
    }
}
