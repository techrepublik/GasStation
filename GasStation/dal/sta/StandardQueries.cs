using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasStation.dal.data;
using GasStation.dal.obj;

namespace GasStation.dal.sta
{
    class StandardQueries
    {
        public static List<FuelData> GetFuelDatas()
        {
            using (var d = new GasModel())
            {
                var q = from q1 in d.FuelTypes
                    select new FuelData
                    {
                        FuelTypeId = q1.FuelTypeId,
                        FuelTypeName = q1.FuelTypeName,
                        FuelTypeRebate = q1.FuelTypeRebate
                    };
                return q.ToList();
            }
        }
    }
}
