namespace ARM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.films_and_actors")]
    public partial class films_and_actors
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int film_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int actor_id { get; set; }

        public decimal? actor_honorarium { get; set; }

        public virtual actor actor { get; set; }

        public virtual film film { get; set; }
    }

    //Класс для хранения составного первичного ключа контракта
    public class ContractPrimaryKey {
        public int FilmId { get; set; }
        public int ActorId { get; set; }
    }
}
