namespace AppleRepair.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialInDelivery")]
    public partial class MaterialInDelivery
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaterialId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeliveryId { get; set; }

        public int Amount { get; set; }

        public virtual Delivery Delivery { get; set; }

        public virtual Material Material { get; set; }
    }
}
