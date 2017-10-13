using System.Collections.Generic;
using System.Linq;
using GasStation.dal.data;

namespace GasStation.dal.man
{
    class TransactionManager
    {
        public static DataRepository<Transaction> D;

        public static int Save(Transaction transaction)
        {
            var a = new Transaction
            {
                TransactionId = transaction.TransactionId,
                CustomerId = transaction.CustomerId,
                FuelTypeId = transaction.FuelTypeId,
                EmployeeId = transaction.EmployeeId,    
                UserId = transaction.UserId,
                TransactionLiters = transaction.TransactionLiters,
                TransactionIsActive = transaction.TransactionIsActive,
                TransactionRebate = transaction.TransactionRebate,
                TransactionReceiptNo = transaction.TransactionReceiptNo,
                TransactionDate = transaction.TransactionDate
            };

            using (D = new DataRepository<Transaction>())
            {
                if (transaction.TransactionId > 0)
                    D.Update(a);
                else D.Add(a);

                D.SaveChanges();
            }

            return a.TransactionId;
        }

        public static bool Delete(Transaction transaction)
        {
            using (D = new DataRepository<Transaction>())
            {
                D.Delete(transaction);
                D.SaveChanges();
            }

            return true;
        }

        public static bool Delete(int iId)
        {
            using (D = new DataRepository<Transaction>())
            {
                D.Delete(d => d.CustomerId == iId);
                D.SaveChanges();
            }

            return true;
        }

        public static List<Transaction> GetAll()
        {
            using (D = new DataRepository<Transaction>())
            {
                D.LazyLoadingEnabled = false;
                return D.GetAll().ToList();
            }
        }
        public static List<Transaction> GetAll(int? iId)
        {
            using (D = new DataRepository<Transaction>())
            {
                D.LazyLoadingEnabled = false;
                return D.Find(f => f.CustomerId == iId).OrderByDescending(o => o.TransactionDate).ToList();
            }
        }
    }
}
