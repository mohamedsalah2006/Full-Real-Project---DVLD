using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsDriverBusiness
    {

        static public int IsThePersonADriver(int PersonID)
        {
            return clsDriverData.IsThePersonADriver(PersonID);
        }
        static public int InsertDriver(int PersonID, DateTime CreatedDate, int CreatedByUserID)
        {
            return clsDriverData.InsertDriver(PersonID, CreatedDate, CreatedByUserID);
        }
        static public DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }
    }
}
