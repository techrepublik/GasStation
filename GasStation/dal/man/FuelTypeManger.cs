using System.Collections.Generic;
using System.Linq;
using GasStation.dal.data;

namespace GasStation.dal.man
{
    class FuelTypeManger
    {
        public static DataRepository<FuelType> D;

        public static int Save(FuelType fuelType)
        {
            var a = new FuelType
            {
                FuelTypeId = fuelType.FuelTypeId,
                FuelTypeName = fuelType.FuelTypeName,
                FuelTypeRebate = fuelType.FuelTypeRebate
            };

            using (D = new DataRepository<FuelType>())
            {
                if (fuelType.FuelTypeId > 0)
                    D.Update(a);
                else D.Add(a);

                D.SaveChanges();
            }

            return a.FuelTypeId;
        }

        public static bool Delete(FuelType fuelType)
        {
            using (D = new DataRepository<FuelType>())
            {
                D.Delete(fuelType);
                D.SaveChanges();
            }

            return true;
        }

        public static bool Delete(int iId)
        {
            using (D = new DataRepository<FuelType>())
            {
                D.Delete(d => d.FuelTypeId == iId);
                D.SaveChanges();
            }

            return true;
        }

        public static List<FuelType> GetAll()
        {
            using (D = new DataRepository<FuelType>())
            {
                D.LazyLoadingEnabled = false;
                return D.GetAll().ToList();
            }
        }
    }
}
