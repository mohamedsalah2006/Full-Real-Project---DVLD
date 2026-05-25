using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsDriverBusiness
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsPeopleBusiness PersonInfo;

        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { get; set; }


        public clsDriverBusiness()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;

        }

        public clsDriverBusiness(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)

        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsPeopleBusiness.FindPeopleByID(PersonID);

            Mode = enMode.Update;
        }


        static public bool IsThePersonADriver(int PersonID)
        {
            return GetDriverInfoByPersonID(PersonID) != null;
        }
        static public clsDriverBusiness GetDriverInfoByPersonID(int PersonID)
        {
            clsDriverData DriverInfo = new clsDriverData();

            if(clsDriverData.GetDriverInfoByPersonID(PersonID,ref DriverInfo))
            {
                return new clsDriverBusiness(DriverInfo.DriverID,DriverInfo.PersonID, DriverInfo.CreatedByUserID, DriverInfo.CreatedDate);
            }
            return null;
        }
        static public clsDriverBusiness GetDriverInfoByDriverID(int PersonID)
        {
            clsDriverData DriverInfo = new clsDriverData();

            if (clsDriverData.GetDriverInfoByDriverID(PersonID, ref DriverInfo))
            {
                return new clsDriverBusiness(DriverInfo.DriverID, DriverInfo.PersonID, DriverInfo.CreatedByUserID, DriverInfo.CreatedDate);
            }
            return null;
        }

        bool _AddDriver()
        {
            clsDriverData DriverInfo = new clsDriverData();

            DriverInfo.PersonID = this.PersonID;
            DriverInfo.CreatedByUserID = this.CreatedByUserID;
            DriverInfo.CreatedDate = this.CreatedDate;
            DriverInfo.DriverID = DriverInfo.AddDriver();

            return DriverID!= -1;
        }
        bool _UpdateDriver()
        {
            clsDriverData DriverInfo = new clsDriverData();

            DriverInfo.PersonID = this.PersonID;
            DriverInfo.CreatedByUserID = this.CreatedByUserID;
            DriverInfo.CreatedDate = this.CreatedDate;

            return DriverInfo.UpdateDriver();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    if (_UpdateDriver())
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
        static public DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }
    }
}
