using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsTestBusiness
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public bool TestResult { get; set; }
        public clsTestAppointmentsBusiness TestAppointmentInfo {  get; set; }


        public clsTestBusiness()

        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;


        }

        public clsTestBusiness(int TestID, int TestAppointmentID,
            bool TestResult, string Notes, int CreatedByUserID)

        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointmentsBusiness.GetTestAppointmentByID(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

        }

        public bool TakeTest()
        {
            TestID=clsTestData.TakeTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
            return TestID != -1;
        }
        public static clsTestBusiness Find(int TestID)
        {
            clsTestData TestInfo = new clsTestData();
            if(clsTestData.GetTestInfo(TestID,ref TestInfo))
            {
                return new clsTestBusiness(TestInfo.TestID, TestInfo.TestAppointmentID, TestInfo.TestResult, TestInfo.Notes, TestInfo.CreatedByUserID);
            }
            else
            {
                return null;
            }
        }
        static public bool DidThePersonPassInThisTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestData.DidThePersonPassInThisTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        static public int GetPassedTestCount(int LocalDrivingLicenseAppID)
        {
            return clsTestData.GetPassedTestCount(LocalDrivingLicenseAppID);    
        }
        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }

    }
}
