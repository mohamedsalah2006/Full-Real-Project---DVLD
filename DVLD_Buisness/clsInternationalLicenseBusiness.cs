using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer
{
    public class clsInternationalLicenseBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int IsActive { get; set; }
        public int CreatedByUserID { get; set; }


        public clsInternationalLicenseBusiness( int iNT_LicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, int isActive, int createdByUserID)
        {
            Mode = enMode.Update;

            InternationalLicenseID = iNT_LicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
        }
        public clsInternationalLicenseBusiness()
        {
            InternationalLicenseID = 0;
            ApplicationID = 0;
            DriverID = 0;
            IssuedUsingLocalLicenseID = 0;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now.AddYears(1);
            IsActive = 1;
            CreatedByUserID = 0;

            Mode = enMode.AddNew;
        }
        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {

            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);

        }
        public static clsInternationalLicenseBusiness Find(int InternationalLicenseID)
        {
            clsInternationalLicenseData internationalLicense = new clsInternationalLicenseData();


            if (clsInternationalLicenseData.GetInternationalLicenseInfoByID(InternationalLicenseID, ref internationalLicense)) 
            {
                return new clsInternationalLicenseBusiness(internationalLicense.InternationalLicenseID, internationalLicense.ApplicationID, internationalLicense.DriverID, internationalLicense.IssuedUsingLocalLicenseID, internationalLicense.IssueDate, internationalLicense.ExpirationDate, internationalLicense.IsActive, internationalLicense.CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        bool _AddInternationalLicense()
        {
            clsInternationalLicenseData LicenseData = new clsInternationalLicenseData();

            LicenseData.ApplicationID=this.ApplicationID;
            LicenseData.DriverID=this.DriverID;
            LicenseData.IssuedUsingLocalLicenseID = this.IssuedUsingLocalLicenseID; 
            LicenseData.IssueDate = this.IssueDate;
            LicenseData.ExpirationDate = this.ExpirationDate;
            LicenseData.IsActive = this.IsActive;
            LicenseData.CreatedByUserID=this.CreatedByUserID;
            this.InternationalLicenseID = LicenseData.AddInternationalLicense();

            return this.InternationalLicenseID != -1;
            
        }
        bool _UpdateInternationalLicense()
        {
            clsInternationalLicenseData LicenseData = new clsInternationalLicenseData();

            LicenseData.ApplicationID = this.ApplicationID;
            LicenseData.DriverID = this.DriverID;
            LicenseData.IssuedUsingLocalLicenseID = this.IssuedUsingLocalLicenseID;
            LicenseData.IssueDate = this.IssueDate;
            LicenseData.ExpirationDate = this.ExpirationDate;
            LicenseData.IsActive = this.IsActive;
            LicenseData.CreatedByUserID = this.CreatedByUserID;

            return LicenseData.UpdateInternationalLicense();
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    return _AddInternationalLicense();


                case enMode.Update:

                    return _UpdateInternationalLicense();

            }

            return false;
        }
       
        static public DataTable GetAllInternationalLicenseToPerson(int DriverID)
        {
            return clsInternationalLicenseData.GetAllInternationalLicenseToPerson(DriverID);
        }
        static public DataTable GetAllInternationalLicense()
        {
            return clsInternationalLicenseData.GetAllInternationalLicense();
        }

    }
}
