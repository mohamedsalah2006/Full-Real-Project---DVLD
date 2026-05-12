using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccessLayer;

namespace BusinessLayer
{
    
    public class clsPeopleBusiness
    {

        public enum enMode { AddMode = 0, UpdateMode = 1 }
        enMode Mode = enMode.AddMode;


        public int PersonID             {get;set;}  
        public string NationalNo        {get;set;}  
        public string FirstName         {get;set;}  
        public string SecondName        {get;set;}  
        public string ThirdName         {get;set;}  
        public string LastName          {get;set;}  
        public DateTime DateOfBirth     {get;set;}  
        public int Gendor               {get;set;}  
        public string Address           {get;set;}  
        public string Phone             {get;set;}  
        public string Email             {get;set;}  
        public int NationalityCountryID {get;set;}  
        public string ImagePath         { get; set; }
        public clsCountriesBusiness CountryInfo { get;set;}
        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }


        public clsPeopleBusiness()
        {
            this.PersonID= -1;
            this.NationalNo = "";
            this.Gendor = -1;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            

            Mode = enMode.AddMode;
        }
        private clsPeopleBusiness(int ID,string NationalNo, string FirstName,string SecondName,string ThirdName, string LastName,
           string Email, string Phone, string Address,int Gendor, DateTime DateOfBirth, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.Gendor= Gendor;
            this.CountryInfo = clsCountriesBusiness.GetCountryInfoByID(NationalityCountryID);
            this.Mode = enMode.UpdateMode;
        }
        
        
        public static DataTable GetAllPeople()
        {
            return clsPeopleData.GetAllPeople();
        }
        public static clsPeopleBusiness FindPeopleByID(int id)
        {
            clsPeopleData people = new clsPeopleData();

            if(clsPeopleData.FindPeopleByID(id,ref people))
            {
                return new clsPeopleBusiness(id, people.NationalNo, people.FirstName, people.SecondName, people.ThirdName, people.LastName, people.Email, people.Phone, people.Address, people.Gendor, people.DateOfBirth, people.NationalityCountryID, people.ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPeopleBusiness FindPeopleByNationalNo(string NationalNo)
        {
            clsPeopleData people = new clsPeopleData();

            if (clsPeopleData.FindPeopleByNationalNo(NationalNo, ref people))
            {
                return new clsPeopleBusiness(people.PersonID , people.NationalNo, people.FirstName, people.SecondName, people.ThirdName, people.LastName, people.Email, people.Phone, people.Address, people.Gendor, people.DateOfBirth, people.NationalityCountryID, people.ImagePath);
            }
            else
            {
                return null;
            }
        }
        bool _UpdatePerson()
        {

            clsPeopleData people = new clsPeopleData();

            people.FirstName = this.FirstName;
            people.SecondName = this.SecondName;
            people.ThirdName = this.ThirdName;
            people.LastName = this.LastName;
            people.Email = this.Email;
            people.DateOfBirth = this.DateOfBirth;
            people.Gendor = this.Gendor;
            people.Address = this.Address;
            people.Phone = this.Phone;
            people.NationalityCountryID = this.NationalityCountryID;
            people.ImagePath = this.ImagePath;
            people.NationalNo = this.NationalNo;

            return clsPeopleData.UpdatePerson(this.PersonID, people);

        }
        bool _Add_New_Person()
        {
            clsPeopleData people = new clsPeopleData();

            
            
            people.FirstName = this.FirstName;
            people.SecondName = this.SecondName;
            people.ThirdName = this.ThirdName;
            people.LastName = this.LastName;
            people.Email = this.Email;
            people.DateOfBirth = this.DateOfBirth;
            people.Gendor = this.Gendor;
            people.Address=this.Address;
            people.Phone = this.Phone;
            people.NationalityCountryID = this.NationalityCountryID;
            people.ImagePath = this.ImagePath;
            people.NationalNo = this.NationalNo;

            this.PersonID = people.AddNewPeople();

            return this.PersonID != -1;

            
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_Add_New_Person())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.UpdateMode:
                    if (_UpdatePerson())
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
       static public bool DeletePerson(int ID)
        {
            return clsPeopleData.DeletePeople(ID);
        }


        public static bool IsPersonExist(int ID)
        {
            return clsPeopleData.IsPersonExist(ID);
        }

        public static bool IsPersonExist(string NationlNo)
        {
            return clsPeopleData.IsPersonExist(NationlNo);
        }


    }
}
