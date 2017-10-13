using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasStation.dal.data;

namespace GasStation.dal.obj
{
    [NotMapped]
    class FuelData : FuelType
    {
        public string FuelRebate => string.Format("{0} - ( {1} Php)", FuelTypeName, FuelTypeRebate);
    }
}
