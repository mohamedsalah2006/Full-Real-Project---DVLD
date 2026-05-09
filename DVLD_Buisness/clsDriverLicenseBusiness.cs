using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsDriverLicenseBusiness
    {

        public string FullName { get; set; }
        public string LicenseClassName { get; set; }
        public int LicenseID { get; set; }
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public DateTime IssueDate { get; set; }
        public int IssueReason { get; set; }
        public string Notes { get; set; }
        public int IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int DriverID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string ImagePath { get; set; }


        public clsDriverLicenseBusiness(string FullName, string LicenseClassName, int LicenseID, string NationalNo, DateTime IssueDate, int IssueReason, string Notes, int IsActive, DateTime ExpirationDate, int DriverID, DateTime DateOfBirth, int Gendor,string ImagePath, int personID)
        {
            this.FullName = FullName;
            this.LicenseClassName = LicenseClassName;
            this.LicenseID = LicenseID;
            this.NationalNo = NationalNo;
            this.IssueDate = IssueDate;
            this.IssueReason = IssueReason;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.ExpirationDate = ExpirationDate;
            this.DriverID = DriverID;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.ImagePath = ImagePath;
            PersonID = personID;
        }

        static public clsDriverLicenseBusiness GetDriverLicenseInfoBy_LocalLicenseAppID(int LocalDrivingLicenseApplicationID)
        {
            clsDriverLicenseData driverLicenseInfo = new clsDriverLicenseData();

            if (clsDriverLicenseData.GetDriverLicenseInfoBy_L_D_L_APP_ID(LocalDrivingLicenseApplicationID, ref driverLicenseInfo))
            {
                return new clsDriverLicenseBusiness(driverLicenseInfo.FullName, driverLicenseInfo.LicenseClassName, driverLicenseInfo.LicenseID, driverLicenseInfo.NationalNo, driverLicenseInfo.IssueDate, driverLicenseInfo.IssueReason,driverLicenseInfo.Notes,driverLicenseInfo.IsActive,driverLicenseInfo.ExpirationDateD,driverLicenseInfo.DriverID,driverLicenseInfo.DateOfBirth,driverLicenseInfo.Gendor,driverLicenseInfo.ImagePath,driverLicenseInfo.PersonID);

            }
            return null;
        }
        static public clsDriverLicenseBusiness GetDriverLicenseInfoBY_LocalLicenseID(int LocalLicenseID)
        {
            clsDriverLicenseData driverLicenseInfo = new clsDriverLicenseData();

            if (clsDriverLicenseData.GetDriverLicenseInfo_LocalLicenseID(LocalLicenseID, ref driverLicenseInfo))
            {
                return new clsDriverLicenseBusiness(driverLicenseInfo.FullName, driverLicenseInfo.LicenseClassName, driverLicenseInfo.LicenseID, driverLicenseInfo.NationalNo, driverLicenseInfo.IssueDate, driverLicenseInfo.IssueReason, driverLicenseInfo.Notes, driverLicenseInfo.IsActive, driverLicenseInfo.ExpirationDateD, driverLicenseInfo.DriverID, driverLicenseInfo.DateOfBirth, driverLicenseInfo.Gendor, driverLicenseInfo.ImagePath, driverLicenseInfo.PersonID);

            }
            return null;
        }

    }
}
