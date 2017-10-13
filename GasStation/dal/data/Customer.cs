namespace GasStation.dal.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int CustomerId { get; set; }

        [StringLength(200)]
        public string CustomerName { get; set; }

        public int? CustomerCardNo { get; set; }

        [StringLength(50)]
        public string CustomerPlateNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CustomerDateRegistered { get; set; }

        [StringLength(50)]
        public string CustomerVehicle { get; set; }

        public bool? CustomerIsActive { get; set; }

        [StringLength(200)]
        public string CustomerAddress { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
