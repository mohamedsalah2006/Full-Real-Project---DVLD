using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsInternationalLicenseBusiness
    {
        public int INT_LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        static public bool IsPersonHasInternationalLicense(int LicenseID)
        {
            return clsInternationalLicenseData.IsPersonHasInternationalLicense(LicenseID);
        }
        public bool InsertInternationalLicense()
        {
            clsInternationalLicenseData LicenseData = new clsInternationalLicenseData();

            LicenseData.ApplicationID=this.ApplicationID;
            LicenseData.DriverID=this.DriverID;
            LicenseData.IssuedUsingLocalLicenseID = this.IssuedUsingLocalLicenseID; 
            LicenseData.IssueDate = this.IssueDate;
            LicenseData.ExpirationDate = this.ExpirationDate;
            LicenseData.IsActive = this.IsActive;
            LicenseData.CreatedByUserID=this.CreatedByUserID;
            this.INT_LicenseID = clsInternationalLicenseData.InsertInternationalLicense(LicenseData);

            return this.INT_LicenseID != -1;
            
        }
        static public DataTable GetAllInternationalLicenseToPerson(string NationalNo)
        {
            return clsInternationalLicenseData.GetAllInternationalLicenseToPerson(NationalNo);
        }
        static public DataTable GetAllInternationalLicense()
        {
            return clsInternationalLicenseData.GetAllInternationalLicense();
        }

    }
}
