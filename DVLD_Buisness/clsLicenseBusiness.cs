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
using static BusinessLayer.clsApplicationsBusiness;

namespace BusinessLayer
{
    public class clsLicenseBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public int LicenseID { get; set; }
         public int ApplicationID { get; set; }
         public int DriverID { get; set; }
         public int LicenseClass { get; set; }
         public DateTime IssueDate { get; set; }
         public DateTime ExpirationDate { get; set; }
         public string Notes { get; set; }
         public float PaidFees { get; set; }
         public int IsActive { get; set; }
        public enIssueReason IssueReason { set; get; }
        public string IssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time";
                    case enIssueReason.Renew:
                        return "Renew";
                    case enIssueReason.DamagedReplacement:
                        return "Replacement for Damaged";
                    case enIssueReason.LostReplacement:
                        return "Replacement for Lost";
                    default:
                        return "First Time";
                }
            }
        }
        public int CreatedByUserID { get; set; }
        public bool IsDetained
        {
            get { return clsDetainLicenseBusiness.IsTheLicenseDetained(this.LicenseID); }
        }


        public clsDriverBusiness DriverInfo {  get; set; }
        public clsLicenseClassesBusiness LicenseClassIfo {  get; set; }
        public clsDetainLicenseBusiness DetainedInfo { set; get; }





        clsLicenseBusiness(int  licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate, DateTime expirationDate, string notes, float paidFees, int isActive, clsLicenseBusiness.enIssueReason issueReason, int createdByUserID)
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

            this.DriverInfo = clsDriverBusiness.GetDriverInfoByDriverID(this.DriverID);
            this.LicenseClassIfo = clsLicenseClassesBusiness.GetLicenseClassInfo(this.LicenseClass);
            this.DetainedInfo = clsDetainLicenseBusiness.GetDetainLicenseInfo(this.LicenseID);

            Mode = enMode.Update;
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
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;

        }

        bool _AddNewLicense()
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
            licenseData.IssueReason = (int)this.IssueReason;
            licenseData.PaidFees= this.PaidFees;


            this.LicenseID = clsLicenseData.AddNewLicense(licenseData);



            return this.LicenseID != -1;
        }
        bool _UpdateLicense()
        {
            clsLicenseData licenseData = new clsLicenseData();

            licenseData.ApplicationID = this.ApplicationID;
            licenseData.DriverID = this.DriverID;
            licenseData.LicenseClass = this.LicenseClass;
            licenseData.IssueDate = this.IssueDate;
            licenseData.ExpirationDate = this.ExpirationDate;
            licenseData.Notes = this.Notes;
            licenseData.CreatedByUserID = this.CreatedByUserID;
            licenseData.IsActive = this.IsActive;
            licenseData.IssueReason = (int)this.IssueReason;
            licenseData.PaidFees = this.PaidFees;


            return licenseData.UpdateLicense();


        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }

        static public bool IsTheLicenseExpired(int LicenseID)
        {
            return clsLicenseData.IsTheLicenseExpired(LicenseID);
        }
        public bool IsTheLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }
        static public bool IsTheLicenseActive(int LicenseID)
        {
            return clsLicenseData.IsTheLicenseActive(LicenseID);
        }
        public bool IsTheLicenseActive()
        {
            return this.IsActive == 1;
        }
        static public clsLicenseBusiness GetLicenseInfo(int LicenseID)
        {
            clsLicenseData LicenseData = new clsLicenseData();

            if (clsLicenseData.GetLicenseInfo(LicenseID, ref LicenseData))
            {
                return new clsLicenseBusiness(LicenseData.LicenseID, LicenseData.ApplicationID, LicenseData.DriverID, LicenseData.LicenseClass, LicenseData.IssueDate, LicenseData.ExpirationDate, LicenseData.Notes, LicenseData.PaidFees, LicenseData.IsActive,(enIssueReason) LicenseData.IssueReason, LicenseData.CreatedByUserID);
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
        public static DataTable GetDriverLocalLicense(int DriverID)
        {
            return clsLicenseData.GetPersonLocalLicense(DriverID);
        }
       


        
        public bool Detain()
        {
            return clsDetainLicenseBusiness.DetainLicense(this.LicenseID,this.PaidFees,this.CreatedByUserID);
        }





        clsApplicationsBusiness _AddApp(int CreateByUser, enApplicationType ApplicationType)
        {
            clsApplicationsBusiness Application = new clsApplicationsBusiness();



            Application.ApplicationStatus = clsApplicationsBusiness.enApplicationStatus.Completed;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationsTypesBusiness.GetApplicationTypeInfoByID((int)ApplicationType).Fees;

            Application.ApplicationType = ApplicationType;

            Application.CreatedByUser = CreateByUser;
            Application.PersonID = DriverInfo.PersonID;
            

            Application.Save();

            return Application;


        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {
            clsApplicationsBusiness Application = _AddApp(ReleasedByUserID,enApplicationType.ReleaseDetainedDrivingLicsense);

            if (Application==null)
            {
                return false;
            }

            return clsDetainLicenseBusiness.ReleasedLicense(this.LicenseID,Application.CreatedByUser,Application.ApplicationID);

        }
        public clsLicenseBusiness RenewDrivingLicense(string Notes, int CreatedByUserID)
        {


            clsApplicationsBusiness App = _AddApp(CreatedByUserID,clsApplicationsBusiness.enApplicationType.RenewDrivingLicense);
            if(App == null)
            {
                return null;
            }

            clsLicenseBusiness RenewLicense = new clsLicenseBusiness();

            RenewLicense.ApplicationID = App.ApplicationID;
            RenewLicense.DriverID = this.DriverID;
            RenewLicense.LicenseClass = this.LicenseClass;
            RenewLicense.IssueDate = DateTime.Now;
            RenewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassIfo.DefaultValidityLength);
            RenewLicense.Notes = Notes;
            RenewLicense.CreatedByUserID = CreatedByUserID;
            RenewLicense.IsActive = 1;
            RenewLicense.IssueReason = enIssueReason.Renew;
            RenewLicense.PaidFees = this.PaidFees;

            if (clsLicenseBusiness.DeactivateLicense(LicenseID))
            {
                if(RenewLicense.Save())
                {
                    return RenewLicense;
                }
            }
            return null;

        }
        public clsLicenseBusiness Replace(enIssueReason IssueReason,  int CreatedByUserID)
        {
            clsApplicationsBusiness.enApplicationType _AppType = new enApplicationType();


            if (IssueReason==enIssueReason.LostReplacement)
            {
                _AppType = enApplicationType.ReplaceLostDrivingLicense;
            }
            else if(IssueReason==enIssueReason.DamagedReplacement)
            {
                _AppType = enApplicationType.ReplaceDamagedDrivingLicense;
            }
            else
            {
                return null;
            }

            clsApplicationsBusiness Application = new clsApplicationsBusiness();

            Application = _AddApp(CreatedByUserID, _AppType);

            if (Application==null)
            {
                return null;
            }

            clsLicenseBusiness NewLicense = new clsLicenseBusiness();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;// no fees for the license because it's a replacement.
            NewLicense.IsActive = 1;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (clsLicenseBusiness.DeactivateLicense(LicenseID))
            {
                if (NewLicense.Save())
                {
                    return NewLicense;
                }
            }
            return null;



        }




    }
}
