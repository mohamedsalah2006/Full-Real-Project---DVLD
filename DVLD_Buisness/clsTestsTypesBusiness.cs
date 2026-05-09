using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsTestsTypesBusiness
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        public enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestDescription { get; set; }
        public float TestFees { get; set; }

        clsTestsTypesBusiness( enTestType testTypeID, string testTypeTitle, string testDescription, float testFees)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestDescription = testDescription;
            TestFees = testFees;

            Mode = enMode.Update;
        }

        public static DataTable GeTAllTestsTypes()
        {
            return clsTestsTypesData.GeTAllTestsTypes();
        }
        bool _EditTestsTypes()
        {
            return clsTestsTypesData.EditTestsTypes(Convert.ToInt32( this.TestTypeID), this.TestTypeTitle, this.TestFees, this.TestDescription);
        }
        bool _AddNewTestType()
        {
            return false;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _EditTestsTypes();

            }

            return false;

        }
        public static clsTestsTypesBusiness Find(enTestType TestTypeID)
        {

            clsTestsTypesData TestType = new clsTestsTypesData();

            if (clsTestsTypesData.GetTestTypeInfoByID((int)TestTypeID, ref TestType))

                return new clsTestsTypesBusiness(TestTypeID, TestType.TestTypeTitle, TestType.TestDescription,TestType.TestFees);
            else
                return null;

        }
    }
}
