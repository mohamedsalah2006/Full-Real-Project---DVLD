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

        static public bool TakeTest(int TestAppointmentID, int TestResult, string Notes, int CreatedByUserID)
        {
            return (clsTestData.TakeTest(TestAppointmentID, TestResult, Notes, CreatedByUserID) != -1);
        }
        static public bool IsPassed(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestData.IsPassed(LocalDrivingLicenseApplicationID, TestTypeID);
        }

    }
}
