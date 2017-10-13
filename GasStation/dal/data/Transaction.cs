namespace GasStation.dal.data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        public int TransactionId { get; set; }

        public int? CustomerId { get; set; }

        public int? FuelTypeId { get; set; }

        public int? EmployeeId { get; set; }

        public int? UserId { get; set; }

        public double? TransactionLiters { get; set; }

        public double? TransactionRebate { get; set; }

        public bool? TransactionIsActive { get; set; }

        [StringLength(50)]
        public string TransactionReceiptNo { get; set; }

        public DateTime? TransactionDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual FuelType FuelType { get; set; }

        public virtual UserLevel UserLevel { get; set; }
    }
}
