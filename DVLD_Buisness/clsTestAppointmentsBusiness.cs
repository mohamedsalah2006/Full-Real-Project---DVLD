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
        public int LocalDrivingLicenseID {  get; set; }
        public DateTime AppointmentDate {  get; set; }
        public int PaidFees {  get; set; }
        public int CreatedByUserID {  get; set; }
        public int IsLocked {  get; set; }

        clsTestAppointmentsBusiness( int testAppointmentID, int testTypeID, int localDrivingLicenseID, DateTime appointmentDate, int paidFees, int createdByUserID, int isLocked)
        {
            Mode = enMode.UpdateMode;
            TestAppointmentID = testAppointmentID;
            TestTypeID = testTypeID;
            LocalDrivingLicenseID = localDrivingLicenseID;
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
            this.LocalDrivingLicenseID= -1;
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
            TestAppointment.LocalDrivingLicenseID = this.LocalDrivingLicenseID;
            TestAppointment.CreatedByUserID =this.CreatedByUserID;


            return  clsTestAppointmentsData.AddNewTestAppointment(TestAppointment)!=-1;
        }
        bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsData.UpdateTestAppointment(this.TestAppointmentID,this.AppointmentDate);
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
        public static clsTestAppointmentsBusiness FindTestAppointmentByID(int TestAppointmentID)
        {
            clsTestAppointmentsData TestAppointment = new clsTestAppointmentsData();

            if(clsTestAppointmentsData.FindTestAppointmentByID(TestAppointmentID,ref TestAppointment))
            {
                return new clsTestAppointmentsBusiness(TestAppointmentID, TestAppointment.TestTypeID, TestAppointment.LocalDrivingLicenseID, TestAppointment.AppointmentDate, TestAppointment.PaidFees, TestAppointment.CreatedByUserID, TestAppointment.IsLocked);
            }
            return null;
        }
        static public bool IsPersonHasActiveAppointmentt(int LD_License,int TestTypeID)
        {
            return clsTestAppointmentsData.IsPersonHasActiveTestAppointment(LD_License, TestTypeID);
        }


        static public bool IsFailedInTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestAppointmentsData.IsFailedInTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }

    }
}
