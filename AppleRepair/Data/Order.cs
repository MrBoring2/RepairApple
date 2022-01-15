namespace AppleRepair.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            MaterialToOrder = new HashSet<MaterialToOrder>();
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int ClientId { get; set; }

        public int PhoneModelId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public double Price { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Decription { get; set; }

        public virtual Client Client { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialToOrder> MaterialToOrder { get; set; }

        public virtual PhoneModel PhoneModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service> Service { get; set; }
    }
}
