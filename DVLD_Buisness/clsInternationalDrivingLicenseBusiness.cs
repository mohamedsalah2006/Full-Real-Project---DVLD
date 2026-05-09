using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsInternationalDrivingLicenseBusiness
    {
        public string FullName { get; set; }
        public int InternationalLicenseID { get; set; }
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public string NationalNo { get; set; }
        public DateTime IssueDate { get; set; }
        public int IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int DriverID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string ImagePath { get; set; }

        clsInternationalDrivingLicenseBusiness(string fullName, int internationalLicenseID, int licenseID, int applicationID, string nationalNo, DateTime issueDate,int isActive, DateTime expirationDate, int driverID, DateTime dateOfBirth, int gendor, string imagePath)
        {
            FullName = fullName;
            InternationalLicenseID = internationalLicenseID;
            LicenseID = licenseID;
            ApplicationID = applicationID;
            NationalNo = nationalNo;
            IssueDate = issueDate;
            IsActive = isActive;
            ExpirationDate = expirationDate;
            DriverID = driverID;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            ImagePath = imagePath;
        }

        static public clsInternationalDrivingLicenseBusiness GetInternationalDrivingLicense(int LocalLicenseID)
        {
            clsInternationalDrivingLicenseData I_D_License = new clsInternationalDrivingLicenseData();

            if(clsInternationalDrivingLicenseData.GetInternationalDrivingLicense(LocalLicenseID,ref I_D_License))
            {
                return new clsInternationalDrivingLicenseBusiness(I_D_License.FullName, I_D_License.InternationalLicenseID, I_D_License.LicenseID, I_D_License.ApplicationID, I_D_License.NationalNo, I_D_License.IssueDate, I_D_License.IsActive, I_D_License.ExpirationDateD, I_D_License.DriverID, I_D_License.DateOfBirth, I_D_License.Gendor, I_D_License.ImagePath);
            }
            return null;

        }

    }
}
