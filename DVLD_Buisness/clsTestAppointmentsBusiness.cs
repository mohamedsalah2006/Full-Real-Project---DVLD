using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
namespace BusinessLayer
{
    public class clsTestAppointmentsBusiness
    {
        public enum enMode { AddMode = 0, UpdateMode = 1 }
        enMode Mode = enMode.AddMode;

        public int TestAppointmentID {  get; set; }
        public int TestTypeID {  get; set; }
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public DateTime AppointmentDate {  get; set; }
        public float PaidFees {  get; set; }
        public int CreatedByUserID {  get; set; }
        public int IsLocked {  get; set; }
        public int RetakeTestApplicationID {  get; set; }
        public clsApplicationsBusiness RetakeTestAppInfo { set; get; }

        public int TestID
        {
            get { return GetTestID(this.TestAppointmentID); }
        }
        clsTestAppointmentsBusiness( int testAppointmentID, int testTypeID, int localDrivingLicenseID, DateTime appointmentDate, float paidFees, int createdByUserID, int isLocked)
        {
            Mode = enMode.UpdateMode;
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseApplicationID = localDrivingLicenseID;
            AppointmentDate = appointmentDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
            IsLocked = isLocked;
        }
       public clsTestAppointmentsBusiness()
        {
            this.Mode = enMode.AddMode;
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.LocalDrivingLicenseApplicationID= -1;
            this.CreatedByUserID= -1;
            this.IsLocked = 0;

        }


        static public DataTable GetTestAppointmentsByTestTypeID(int Local_License,int TestTypeID)
        {
            return clsTestAppointmentsData.GetTestAppointmentsByTestTypeID(Local_License, TestTypeID);
        }
        public bool _AddNewTestAppointment()
        {
            clsTestAppointmentsData TestAppointment = new clsTestAppointmentsData();

            TestAppointment.TestTypeID = this.TestTypeID;
            TestAppointment.PaidFees= this.PaidFees;
            TestAppointment.IsLocked = this.IsLocked;
            TestAppointment.AppointmentDate = this.AppointmentDate;
            TestAppointment.LocalDrivingLicenseID = this.LocalDrivingLicenseApplicationID;
            TestAppointment.CreatedByUserID =this.CreatedByUserID;


            return  clsTestAppointmentsData.AddNewTestAppointment(TestAppointment)!=-1;
        }
        bool _UpdateTestAppointment()
        {
            clsTestAppointmentsData testAppointmentsData = new clsTestAppointmentsData();

            testAppointmentsData.RetakeTestApplicationID = this.RetakeTestApplicationID;
            testAppointmentsData.TestTypeID = this.TestTypeID;
            testAppointmentsData.LocalDrivingLicenseID =this.LocalDrivingLicenseApplicationID;
            testAppointmentsData. AppointmentDate = this.AppointmentDate;
            testAppointmentsData. PaidFees = this.PaidFees;
            testAppointmentsData.CreatedByUserID=this.CreatedByUserID;
            testAppointmentsData.IsLocked =this.IsLocked;

            return clsTestAppointmentsData.UpdateTestAppointment(this.TestAppointmentID, testAppointmentsData);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.UpdateMode:
                    if (_UpdateTestAppointment())
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
        public static clsTestAppointmentsBusiness GetTestAppointmentByID(int TestAppointmentID)
        {
            clsTestAppointmentsData TestAppointment = new clsTestAppointmentsData();

            if(clsTestAppointmentsData.GetTestAppointmentByID(TestAppointmentID,ref TestAppointment))
            {
                return new clsTestAppointmentsBusiness(TestAppointmentID, TestAppointment.TestTypeID, TestAppointment.LocalDrivingLicenseID, TestAppointment.AppointmentDate, TestAppointment.PaidFees, TestAppointment.CreatedByUserID, TestAppointment.IsLocked);
            }
            return null;
        }
        static public bool IsPersonHasActiveAppointment(int LD_License,int TestTypeID)
        {
            return clsTestAppointmentsData.IsPersonHasActiveTestAppointment(LD_License, TestTypeID);
        }
        public static clsTestAppointmentsBusiness GetLastTestAppointment( int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            clsTestAppointmentsData TestAppointment = new clsTestAppointmentsData();

            if (clsTestAppointmentsData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, TestTypeID, ref TestAppointment))
            {
                return new clsTestAppointmentsBusiness(TestAppointment.TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, TestAppointment.AppointmentDate, TestAppointment.PaidFees, TestAppointment.CreatedByUserID, TestAppointment.IsLocked);
            }
            return null;

        }

        

        public static int GetTestID(int TestAppointmentID)
        {
            return clsTestAppointmentsData.GetTestID(TestAppointmentID);
        }
    }
}
