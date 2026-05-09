using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer
{
    public class clsApplicationsBusiness
    {

        public enum enMode { AddMode = 0, UpdateMode = 1 }
        enMode Mode = enMode.AddMode;

        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        }
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };


        public int ApplicationID { get; set; }
        public int PersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationType { get; set; }
        public enApplicationStatus ApplicationStatus { set; get; }
        public DateTime LastStatusDate { get; set; }
        public int PaidFees { get; set; }
        public int CreatedByUser { get; set; }
        public clsApplicationsTypesBusiness ApplicationTypeInfo {  get; set; }
        public clsPeopleBusiness PersonInfo {  get; set; }
        public clsUsersBusiness UserInfo { get; set; }
        public string StatusText
        {
            get
            {

                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }

        }



        public clsApplicationsBusiness()
        {
            Mode = enMode.AddMode;
            ApplicationID = -1;
            PersonID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationType = -1;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.Now;
            PaidFees = -1;
            CreatedByUser = -1;
        }
        
        clsApplicationsBusiness( int applicationID, int personID, DateTime applicationDate, int applicationType, enApplicationStatus applicationStatus, DateTime lastStatusDate, int paidFees, int createdByUser)        
        {
            Mode = enMode.UpdateMode;
            ApplicationID = applicationID;
            PersonID = personID;
            ApplicationDate = applicationDate;
            ApplicationType = applicationType;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUser = createdByUser;
        }

        static public DataTable GetAllApplications()
        {
            return clsApplicationsData.GeTAllApplications();
        }

        bool _AddNewApplication()
        {
            clsApplicationsData appInfo = new clsApplicationsData();

            appInfo.ApplicationStatus =(int) this.ApplicationStatus;
            appInfo.ApplicationDate = this.ApplicationDate;
            appInfo.ApplicationType = this.ApplicationType;
            appInfo.LastStatusDate = this.LastStatusDate;
            appInfo.PaidFees = this.PaidFees;
            appInfo.CreatedByUser = this.CreatedByUser;
            appInfo.PersonID = this.PersonID;
            this.ApplicationID = appInfo.AddNewApplication();

            return this.ApplicationID != -1;
        }
        bool _UpdateApplication()
        {
            
            clsApplicationsData appInfo = new clsApplicationsData();

            appInfo.ApplicationStatus =(int) this.ApplicationStatus;
            appInfo.ApplicationDate = this.ApplicationDate;
            appInfo.ApplicationType = this.ApplicationType;
            appInfo.LastStatusDate = this.LastStatusDate;
            appInfo.PaidFees = this.PaidFees;
            appInfo.CreatedByUser = this.CreatedByUser;
            appInfo.PersonID = this.PersonID;
           
            return appInfo.UpdateApplication(this.ApplicationID);

        }
        public  bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.UpdateMode:
                    if (_UpdateApplication())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    break;
            }
            return false;
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationsData.DeleteApplication(ApplicationID);
        }
        public static clsApplicationsBusiness FindApplication(int ApplicationID)
        {
            clsApplicationsData AppInfo = new clsApplicationsData();
            if(clsApplicationsData.GetApplicationInfoByID(ApplicationID,ref AppInfo))
            {
                return new clsApplicationsBusiness( AppInfo.ApplicationID, AppInfo.PersonID, AppInfo.ApplicationDate, AppInfo.ApplicationType,(clsApplicationsBusiness.enApplicationStatus) AppInfo.ApplicationStatus, AppInfo.LastStatusDate, AppInfo.PaidFees, AppInfo.CreatedByUser);
            }
            return null;
        }
        public bool Cancel()
        {
            clsApplicationsBusiness App = clsApplicationsBusiness.FindApplication(this.ApplicationID);
            App.ApplicationStatus = enApplicationStatus.Cancelled;
            return (App.Save());
        }
        public bool Complete()
        {
            clsApplicationsBusiness App = clsApplicationsBusiness.FindApplication(this.ApplicationID);
            App.ApplicationStatus = enApplicationStatus.Completed;
            return (App.Save());
        }
        public bool Delete()
        {
            return clsApplicationsData.DeleteApplication(this.ApplicationID);
        }
    }
}
