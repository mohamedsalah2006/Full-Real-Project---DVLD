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

        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public int MinimumAllowedAge { set; get; }
        public int DefaultValidityLength { set; get; }
        public float ClassFees { set; get; }

        public clsLicenseClassesBusiness()

        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 10;
            this.ClassFees = 0;


        }

        public clsLicenseClassesBusiness(int LicenseClassID, string ClassName,
            string ClassDescription,
            int MinimumAllowedAge, int DefaultValidityLength, float ClassFees)

        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassesData.GetAllLicenseClasses();
        }
        static public clsLicenseClassesBusiness GetLicenseClassInfo(int LicenseClassID)
        {
            clsLicenseClassesData LicenseClassInfo = new clsLicenseClassesData();

            if( clsLicenseClassesData.GetLicenseClassInfo(LicenseClassID,ref LicenseClassInfo))
            {
                return new clsLicenseClassesBusiness(LicenseClassID, LicenseClassInfo.LicenseClassName, LicenseClassInfo.ClassDescription,
                   LicenseClassInfo.MinimumAllowedAge, LicenseClassInfo.DefaultValidityLength, LicenseClassInfo.ClassFees);
            }
            return null;
        }
        static public clsLicenseClassesBusiness GetLicenseClassInfo(string LicenseClassName)
        {
            clsLicenseClassesData LicenseClassInfo = new clsLicenseClassesData();

            if (clsLicenseClassesData.GetLicenseClassInfo(LicenseClassName, ref LicenseClassInfo))
            {
                return new clsLicenseClassesBusiness(LicenseClassInfo.LicenseClassID,LicenseClassName, LicenseClassInfo.ClassDescription,
                   LicenseClassInfo.MinimumAllowedAge, LicenseClassInfo.DefaultValidityLength, LicenseClassInfo.ClassFees);
            }
            return null;
        }



    }
}
