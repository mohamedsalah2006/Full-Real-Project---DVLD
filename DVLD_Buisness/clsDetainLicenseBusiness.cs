using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsDetainLicenseBusiness
    {
        public int DetainID;
        public int LicenseID;
   public DateTime DetainDate;
        public int FineFees;
        public int CreateByUserID;
        public int IsReleased;
        public DateTime? ReleasedDate;
        public int ReleasedByUserID;
        public int ReleasedAppID;

        clsDetainLicenseBusiness(int detainID, int licenseID, DateTime detainDate, int fineFees, int createByUserID, int isReleased, DateTime? releasedDate, int releasedByUserID, int releasedAppID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreateByUserID = createByUserID;
            IsReleased = isReleased;
            ReleasedDate = releasedDate;
            ReleasedByUserID = releasedByUserID;
            ReleasedAppID = releasedAppID;
        }
        clsDetainLicenseBusiness()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = -1;
            this.CreateByUserID = -1;
            this.IsReleased = -1;
            this.ReleasedDate = DateTime.Now;
            this.ReleasedByUserID = -1;
            this.ReleasedAppID = -1;
        }

        static public DataTable GetAllDetainedLicense()
        {
            return clsDetainLicenseData.GetAllDetainedLicense();
        }
        static public int DetainLicense(int LicenseID, int FineFees, int CreateByUserID)
        {
            return clsDetainLicenseData.DetainLicense(LicenseID, FineFees, CreateByUserID);
        }
        static public bool ReleasedLicense(int LicenseID, int ReleasedByUserID, int ReleasedAppID)
        {
            return clsDetainLicenseData.ReleasedLicense(LicenseID, ReleasedByUserID, ReleasedAppID);
        }
        static public bool IsTheLicenseDetained(int LicenseID)
        {
            return clsDetainLicenseData.IsTheLicenseDetained(LicenseID);
        }
        static public clsDetainLicenseBusiness GetDetainLicenseInfo(int DetainLicenseID)
        {
            clsDetainLicenseData DetainLicenseData = new clsDetainLicenseData();

            if(clsDetainLicenseData.GetDetainLicenseInfo(DetainLicenseID,ref DetainLicenseData))
            {
                return new clsDetainLicenseBusiness(DetainLicenseData.DetainID, DetainLicenseData.LicenseID, DetainLicenseData.DetainDate, DetainLicenseData.FineFees, DetainLicenseData.CreateByUserID, DetainLicenseData.IsReleased,DetainLicenseData.ReleasedDate, DetainLicenseData.ReleasedByUserID, DetainLicenseData.ReleasedAppID);
            }
            return null;
        }
    }
}
