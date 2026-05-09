using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{


    public class clsLocalDrivingLicenseAppBusiness_View
    {
        public int    LD_LicenseID;
        public string ClassName;
        public string NationalNo;
        public string FullName;
        public DateTime ApplicationDate;
        public int    PassedTestCount;
        public string Status;

        clsLocalDrivingLicenseAppBusiness_View(int LD_LicenseID, string ClassName, string NationalNo, string FullName, DateTime ApplicationDate, int PassedTestCount, string status)
        {
            this.LD_LicenseID = LD_LicenseID;
            this.ClassName = ClassName;
            this.NationalNo = NationalNo;
            this.FullName= FullName;
            this.ApplicationDate = ApplicationDate;
            this.PassedTestCount = PassedTestCount;
            this.Status= status;


        }
        public static clsLocalDrivingLicenseAppBusiness_View FindLocalLicenseApp_View(int id)
        {
            clsLocalDrivingLicenseAppData_View AppInfo = new clsLocalDrivingLicenseAppData_View();
            if( clsLocalDrivingLicenseAppData_View.FindLocalLicenseApp_View(id,ref AppInfo))
            {
                return new clsLocalDrivingLicenseAppBusiness_View(AppInfo.LD_LicenseID, AppInfo.ClassName, AppInfo.NationalNo, AppInfo.FullName, AppInfo.ApplicationDate, AppInfo.PassedTestCount, AppInfo.Status);
            }
            return null;
        }


    }

    public class clsLocalDrivingLicenseApplicationsBusiness
    {
        

        public int D_L_AppID { get; set; }
        public int AppID { get; set; }
        public int LicenseClassID { get; set; }

        public clsLocalDrivingLicenseApplicationsBusiness(int d_L_AppID, int appID, int licenseClassID)
        {
            D_L_AppID = d_L_AppID;
            AppID = appID;
            LicenseClassID = licenseClassID;
        }
        public clsLocalDrivingLicenseApplicationsBusiness()
        {
            this.D_L_AppID = -1;
            this.AppID = -1;
            this.LicenseClassID = -1;
        }

        public static DataTable GetAllLocalLicense()
        {
            return clsLocalDrivingLicenseApplicationsData.GetAllLocalLicense();
        }
        public static bool AddNewLocalDrivingLicenseApplications(int AppID,int ClassID)
        {
            return clsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplications(AppID, ClassID) != -1;
        }
        static public bool IsApplicationWright(int Status, int ClassLicense, int PersonID)
        {
            return clsLocalDrivingLicenseApplicationsData.IsApplicationWright(Status, ClassLicense, PersonID);
        }
        static public clsLocalDrivingLicenseApplicationsBusiness FindLocalLicenseApp(int LocalDrivingLicenseApplicationID)
        {


            clsLocalDrivingLicenseApplicationsData LD_LicenseInfo = new clsLocalDrivingLicenseApplicationsData();

            if (clsLocalDrivingLicenseApplicationsData.FindLocalLicenseApp(LocalDrivingLicenseApplicationID,ref LD_LicenseInfo))
            {

                return new clsLocalDrivingLicenseApplicationsBusiness(LD_LicenseInfo.LocalDrivingLicenseApplicationID, LD_LicenseInfo.ApplicationID, LD_LicenseInfo.LicenseClassID);

            }
            return null;


        }
        public static DataTable GetPersonLocalLicense(string NationalNo)
        {
            return clsLocalDrivingLicenseApplicationsData.GetPersonLocalLicense(NationalNo);
        }
        public static bool DeleteLocalDrivingLicenseApplications(int L_D_L_ID)
        {
            return clsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplications(L_D_L_ID);
        }
    }

}
