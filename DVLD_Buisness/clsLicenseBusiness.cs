using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer
{
    public class clsLicenseBusiness
    {

         public int LicenseID { get; set; }
         public int ApplicationID { get; set; }
         public int DriverID { get; set; }
         public int LicenseClass { get; set; }
         public DateTime IssueDate { get; set; }
         public DateTime ExpirationDate { get; set; }
         public string Notes { get; set; }
         public int PaidFees { get; set; }
         public int IsActive { get; set; }
         public int IssueReason { get; set; }
         public int CreatedByUserID { get; set; }
         public int PersonID { get; set; }

        clsLicenseBusiness(int  licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate, DateTime expirationDate, string notes, int paidFees, int isActive, int issueReason, int createdByUserID, int personID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            PersonID = personID;
        }
        public clsLicenseBusiness ()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = -1;
            this.IsActive = -1;
            this.IssueReason = -1;
            this.CreatedByUserID = -1;
        }

        public bool AddNewLicense()
        {
            clsLicenseData licenseData = new clsLicenseData();

            licenseData.ApplicationID = this.ApplicationID;
            licenseData.DriverID = this.DriverID;
            licenseData.LicenseClass = this.LicenseClass;
            licenseData.IssueDate = this.IssueDate;
            licenseData.ExpirationDate = this.ExpirationDate;
            licenseData.Notes = this.Notes;
            licenseData.CreatedByUserID = this.CreatedByUserID;
            licenseData.IsActive =  this.IsActive;
            licenseData.IssueReason = this.IssueReason;
            licenseData.PaidFees= this.PaidFees;


            this.LicenseID = clsLicenseData.AddNewLicense(licenseData);



            return this.LicenseID != -1;
        }
       
        public static clsLicenseBusiness FindActiveLicenseByID_ClassID(int LicenseID)
        {
            clsLicenseData LicenseData = new clsLicenseData();

            if(clsLicenseData.GetActiveLicenseByID_ClassID(LicenseID,ref LicenseData))
            {
                return new clsLicenseBusiness(LicenseData.LicenseID, LicenseData.ApplicationID, LicenseData.DriverID, LicenseData.LicenseClass, LicenseData.IssueDate, LicenseData.ExpirationDate, LicenseData.Notes, LicenseData.PaidFees, LicenseData.IsActive, LicenseData.IssueReason, LicenseData.CreatedByUserID,LicenseData.PersonID);
            }
            return null;
        }
        static public bool IsTheLicenseNotExpired(int LicenseID)
        {
            return clsLicenseData.IsTheLicenseNotExpired(LicenseID);
        }
        static public bool IsTheLicenseActive(int LicenseID)
        {
            return clsLicenseData.IsTheLicenseActive(LicenseID);
        }
        static public clsLicenseBusiness GetLicenseInfo(int LicenseID)
        {
            clsLicenseData LicenseData = new clsLicenseData();

            if (clsLicenseData.GetLicenseInfo(LicenseID, ref LicenseData))
            {
                return new clsLicenseBusiness(LicenseData.LicenseID, LicenseData.ApplicationID, LicenseData.DriverID, LicenseData.LicenseClass, LicenseData.IssueDate, LicenseData.ExpirationDate, LicenseData.Notes, LicenseData.PaidFees, LicenseData.IsActive, LicenseData.IssueReason, LicenseData.CreatedByUserID, LicenseData.PersonID);
            }
            return null;
        }
        static public bool DeactivateLicense(int LicenseID)
        {
            return clsLicenseData.DeactivateLicense(LicenseID);
        }

        static public int GetActiveLicenseIDByPersonID(int PersonID,int LicenseClassID)
        {
           return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }
        static public bool DidLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return GetActiveLicenseIDByPersonID(PersonID,LicenseClassID) != -1;
        }
        public static DataTable GetPersonLocalLicense(string NationalNo)
        {
            return clsLicenseData.GetPersonLocalLicense(NationalNo);
        }

    }
}
