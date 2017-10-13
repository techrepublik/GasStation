using System.Collections.Generic;
using System.Linq;
using GasStation.dal.data;

namespace GasStation.dal.man
{
    class EmployeeManager
    {
        public static DataRepository<Employee> D;

        public static int Save(Employee employee)
        {
            var a = new Employee
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                EmployeeAddress = employee.EmployeeAddress,
                EmployeeIsActive = employee.EmployeeIsActive,
                EmployeeSex = employee.EmployeeSex
            };

            using (D = new DataRepository<Employee>())
            {
                if (employee.EmployeeId > 0)
                    D.Update(a);
                else D.Add(a);

                D.SaveChanges();
            }

            return a.EmployeeId;
        }

        public static bool Delete(Employee employee)
        {
            using (D = new DataRepository<Employee>())
            {
                D.Delete(employee);
                D.SaveChanges();
            }

            return true;
        }

        public static bool Delete(int iId)
        {
            using (D = new DataRepository<Employee>())
            {
                D.Delete(d => d.EmployeeId == iId);
                D.SaveChanges();
            }

            return true;
        }

        public static List<Employee> GetAll()
        {
            using (D = new DataRepository<Employee>())
            {
                D.LazyLoadingEnabled = false;
                return D.GetAll().ToList();
            }
        }
    }
}
