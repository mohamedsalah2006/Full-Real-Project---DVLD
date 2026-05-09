using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsLicenseClassesBusiness
    {
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }
        static public int GetValidityLength(int LicenseClassID)
        {
            return clsLicenseClassesData.GetValidityLength(LicenseClassID);
        }
        static public int GetClassFees(int LicenseClassID)
        {
            return clsLicenseClassesData.GetClassFees(LicenseClassID);
        }

        static public int GetValidityLength(string LicenseClassName)
        {
            return clsLicenseClassesData.GetValidityLength(LicenseClassName);
        }
        static public int GetClassFees(string LicenseClassName)
        {
            return clsLicenseClassesData.GetClassFees(LicenseClassName);
        }

    }
}
