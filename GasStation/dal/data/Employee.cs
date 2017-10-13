namespace GasStation.dal.data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int EmployeeId { get; set; }

        [StringLength(200)]
        public string EmployeeName { get; set; }

        [StringLength(50)]
        public string EmployeeSex { get; set; }

        public string EmployeeAddress { get; set; }

        public bool? EmployeeIsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
