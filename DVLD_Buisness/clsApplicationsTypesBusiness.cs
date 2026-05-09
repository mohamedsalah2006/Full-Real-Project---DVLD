using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsApplicationsTypesBusiness
    {
        enum enMode { Add,Update}
        enMode Mode;
        public int ID { set; get; }
        public string Title { set; get; }
        public int Fees { set; get; }

        clsApplicationsTypesBusiness(int ID, string Title, int Fees)
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
            Mode = enMode.Update;
        }
        clsApplicationsTypesBusiness()
        {
            this.ID = 0;
            this.Title = "";
            this.Fees = 0;
            Mode = enMode.Add;
        }

        public static DataTable GeT_All_Applications_Types()
        {
            return clsApplicationsTypesData.GeT_All_Applications_Types();
        }
         bool _EditApplicationsTypes()
        {
            return clsApplicationsTypesData.EditApplicationsTypes(this.ID, this.Title, this.Fees);
        }
        bool _AddNewApplicationsTypes()
        {
            return false;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewApplicationsTypes())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _EditApplicationsTypes();

            }

            return false;
        }
        static public clsApplicationsTypesBusiness GetApplicationTypeInfoByID(int id)
        {
            clsApplicationsTypesData applicationsTypesData = new clsApplicationsTypesData();
            if (clsApplicationsTypesData.GetApplicationTypeInfoByID(id,ref applicationsTypesData))
            {
                return new clsApplicationsTypesBusiness(applicationsTypesData.ID, applicationsTypesData.Title, applicationsTypesData.Fees);
            }
            return null;
        }
        
    }
}
