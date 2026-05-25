using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{



    public class clsLocalDrivingLicenseApplicationsBusiness : clsApplicationsBusiness
    {
        enum enMode { AddNew,Update}


        enMode Mode = enMode.AddNew;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClassesBusiness LicenseClassInfo { get; set; }
       


        private clsLocalDrivingLicenseApplicationsBusiness(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID, int LicenseClassID)

        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
            this.ApplicationID = ApplicationID;
            this.PersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationType = (clsApplicationsBusiness.enApplicationType)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUser = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClassesBusiness.GetLicenseClassInfo(LicenseClassID);
            this.PersonInfo = clsPeopleBusiness.FindPeopleByID(PersonID);

            Mode = enMode.Update;
        }

        public clsLocalDrivingLicenseApplicationsBusiness()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;

        }



        public static DataTable GetAllLocalLicense()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalLicense();
        }

        public bool _AddNewLocalDrivingLicenseApplications()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplications(this.ApplicationID, this.LicenseClassID);
            return LocalDrivingLicenseApplicationID!=-1;
        }
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            //call DataAccess Layer 

            return clsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplication  (this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);

        }
        public bool Save()
        {
            base.Mode = (clsApplicationsBusiness.enMode)Mode;
            if (!base.Save())
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLocalDrivingLicenseApplications())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();
                default:
                    break;
            }
            return false;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static clsLocalDrivingLicenseApplicationsBusiness FindByLocalDrivingAppLicenseID(int LocalDrivingLicenseApplicationID)
        {
            clsLocalDrivingLicenseApplicationsData LocalDrivingAppInfo = new clsLocalDrivingLicenseApplicationsData();
            bool IsFound = clsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID, ref LocalDrivingAppInfo);

            if(IsFound)
            {
                clsApplicationsBusiness AppInfo = clsApplicationsBusiness.FindApplication(LocalDrivingAppInfo.ApplicationID);
                return new clsLocalDrivingLicenseApplicationsBusiness(LocalDrivingAppInfo.LocalDrivingLicenseApplicationID, LocalDrivingAppInfo.ApplicationID, AppInfo.PersonID, AppInfo.ApplicationDate,(int) AppInfo.ApplicationType, (clsApplicationsBusiness.enApplicationStatus)AppInfo.ApplicationStatus, AppInfo.LastStatusDate, AppInfo.PaidFees, AppInfo.CreatedByUser, LocalDrivingAppInfo.LicenseClassID);
            }
            return null;
        }
        public  bool Delete()
        {
            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;

            IsLocalDrivingApplicationDeleted = clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplications(this.LocalDrivingLicenseApplicationID);


            if (IsLocalDrivingApplicationDeleted)
            {
                IsBaseApplicationDeleted = base.Delete();
            }
            return IsBaseApplicationDeleted;
        }




        
       
        
        public int GetPassedTestCount()
        {
            return clsTestBusiness.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }
        public bool DidLicenseIssued ()
        {
            return clsLicenseBusiness.DidLicenseExistByPersonID(this.PersonID, LicenseClassID);
        }
        public bool DidThePersonPassInThisTestType(int TestType)
        {
            return clsTestBusiness.DidThePersonPassInThisTestType(this.LocalDrivingLicenseApplicationID, TestType);
        }

        public  int TotalTrialsPerTest( int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public bool IsFailedInTest( int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsData.IsFailedInTest(this.LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public  bool PassedAllTests()
        {
            return clsTestBusiness.GetPassedTestCount(this.LocalDrivingLicenseApplicationID) == 3;
        }
        public int GetActiveLicenseID()
        {
            return clsLicenseBusiness.GetActiveLicenseIDByPersonID(this.PersonID, this.LicenseClassID);
     
        }


        public int IssueLicenseForTheFirstTime(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;

            clsDriverBusiness Driver = clsDriverBusiness.GetDriverInfoByPersonID(this.PersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new clsDriverBusiness();

                Driver.PersonID = this.PersonID;
                Driver.CreatedByUserID = CreatedByUserID;
                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }

            clsLicenseBusiness NewLicense = new clsLicenseBusiness();


            NewLicense.ApplicationID = this.ApplicationID;
            NewLicense.DriverID = DriverID;
            NewLicense.LicenseClass = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicenseClassesBusiness.GetLicenseClassInfo(LicenseClassID).DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.CreatedByUserID = CreatedByUserID;
            NewLicense.IsActive = 1;
            NewLicense.IssueReason = clsLicenseBusiness.enIssueReason.FirstTime;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;



           

            if (NewLicense.Save())
            {
                //now we should set the application status to complete.
                clsApplicationsBusiness.UpdateStatus(ApplicationID, clsApplicationsBusiness.enApplicationStatus.Completed);

                return NewLicense.LicenseID;
            }

            else
                return -1;
        }

    }

}
