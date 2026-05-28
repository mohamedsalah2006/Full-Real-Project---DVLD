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
        public int DetainID {  get; set; }
        public int LicenseID {  get; set; }
        public DateTime DetainDate {  get; set; }
        public float FineFees {  get; set; }
        public int CreateByUserID {  get; set; }
        public int IsReleased {  get; set; }
        public DateTime? ReleasedDate {  get; set; }
        public int? ReleasedByUserID {  get; set; }
        public int? ReleasedAppID {  get; set; }

        clsDetainLicenseBusiness(int detainID, int licenseID, DateTime detainDate, float fineFees, int createByUserID, int isReleased, DateTime? releasedDate, int? releasedByUserID, int? releasedAppID)
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
        public clsDetainLicenseBusiness()
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
        static public int DetainLicense(int LicenseID, float FineFees, int CreateByUserID)
        {
            return clsDetainLicenseData.DetainLicense(LicenseID, FineFees, CreateByUserID) ;
        }
        static public bool ReleasedLicense(int LicenseID, int ReleasedByUserID, int ReleasedAppID)
        {
            return clsDetainLicenseData.ReleasedLicense(LicenseID, ReleasedByUserID, ReleasedAppID);
        }
        static public bool IsTheLicenseDetained(int LicenseID)
        {
            return clsDetainLicenseData.IsTheLicenseDetained(LicenseID);
        }
        static public clsDetainLicenseBusiness GetDetainLicenseInfoByLicenseID(int LicenseID)
        {
            clsDetainLicenseData DetainLicenseData = new clsDetainLicenseData();

            if(clsDetainLicenseData.GetDetainLicenseInfoByLicenseID(LicenseID,ref DetainLicenseData))
            {
                return new clsDetainLicenseBusiness(DetainLicenseData.DetainID, DetainLicenseData.LicenseID, DetainLicenseData.DetainDate, DetainLicenseData.FineFees, DetainLicenseData.CreateByUserID, DetainLicenseData.IsReleased,DetainLicenseData.ReleasedDate, DetainLicenseData.ReleasedByUserID, DetainLicenseData.ReleasedAppID);
            }
            return null;
        }
    }
}
