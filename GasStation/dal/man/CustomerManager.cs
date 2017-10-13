using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasStation.dal.data;

namespace GasStation.dal.man
{
    class CustomerManager
    {
        public static DataRepository<Customer> _d;

        public static int Save(Customer customer)
        {
            var a = new Customer
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                CustomerCardNo = customer.CustomerCardNo,
                CustomerDateRegistered = customer.CustomerDateRegistered,
                CustomerIsActive = customer.CustomerIsActive,
                CustomerPlateNo = customer.CustomerPlateNo,
                CustomerVehicle = customer.CustomerVehicle,
                CustomerAddress = customer.CustomerAddress
            };

            using (_d = new DataRepository<Customer>())
            {
                if (customer.CustomerId > 0)
                    _d.Update(a);
                else _d.Add(a);

                _d.SaveChanges();
            }

            return a.CustomerId;
        }

        public static bool Delete(Customer customer)
        {
            using (_d = new DataRepository<Customer>())
            {
                _d.Delete(customer);
                _d.SaveChanges();
            }

            return true;
        }

        public static bool Delete(int iId)
        {
            using (_d = new DataRepository<Customer>())
            {
                _d.Delete(d => d.CustomerId == iId);
                _d.SaveChanges();
            }

            return true;
        }

        public static List<Customer> GetAll()
        {
            using (_d = new DataRepository<Customer>())
            {
                _d.LazyLoadingEnabled = false;
                return _d.GetAll().ToList();
            }
        }
    }
}
