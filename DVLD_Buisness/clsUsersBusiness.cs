using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using static BusinessLayer.clsPeopleBusiness;

namespace BusinessLayer
{

    public class clsUsersBusiness
    {

        public enum enMode { AddMode = 0, UpdateMode = 1 }
        enMode Mode = enMode.AddMode;

        public int UserID {  get; set; }
        public string UserName {  get; set; }
        public string Password {  get; set; }
        public int PersonID {  get; set; }
        public bool IsActive {  get; set; }

        public clsPeopleBusiness PersonInfo;

        public clsUsersBusiness()
        {
            this.PersonID = 0;
            this.IsActive = true;
            this.UserName = "";
            this.Password = "Password";
            this.UserID = 0;
            Mode = enMode.AddMode;
        }
        clsUsersBusiness(int UserID,string UserName,string Password,int PersonId,bool IsActive)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.PersonID = PersonId;
            this.IsActive = IsActive;
            this.UserID = UserID;
            Mode = enMode.UpdateMode;

            PersonInfo = clsPeopleBusiness.FindPeopleByID(PersonId);
        }
        static public DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        static public clsUsersBusiness FindUserByPersonID(int PersonID)
        {
            clsUserData user = new clsUserData();
            if (clsUserData.GetUserByPersonID(ref user, PersonID))
            {
                return new clsUsersBusiness(user.UserID,user.UserName,user.Password,user.PersonID,user.IsActive);
            }
            return null;
            
        }
        static public clsUsersBusiness FindUserByUserID(int UserID)
        {
            clsUserData user = new clsUserData();
            if (clsUserData.GetUserByUserID(ref user, UserID))
            {
                return new clsUsersBusiness(UserID, user.UserName, user.Password, user.PersonID, user.IsActive);
            }
            return null;

        }
        static public clsUsersBusiness FindByUsernameAndPassword(string UserName, string Password)
        {
            clsUserData user = new clsUserData();
            if (clsUserData.GetUserInfoByUsernameAndPassword(ref user,UserName,Password))
            {
                return new clsUsersBusiness(user.UserID, user.UserName, user.Password, user.PersonID, user.IsActive);
            }
            return null;

        }

        static public bool DeleteUser(int ID)
        {
            return clsUserData.DeleteUser(ID);
        }
        bool _AddNewUser()
        {
            clsUserData user = new clsUserData();

            user.UserName=this.UserName;
            user.Password=this.Password;
            user.PersonID=this.PersonID;
            user.IsActive=this.IsActive;
            user.PersonID = this.PersonID;

            this.UserID = user.AddNewUser();

            return this.UserID != -1;
        }
        bool _UpdateUser()
        {

            clsUserData user = new clsUserData();
            user.UserName=this.UserName;
            user.Password=this.Password;
            user.PersonID=this.PersonID;
            user.IsActive=this.IsActive;


            return user.UpdateUser(this.UserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    if (_AddNewUser())
                    {
                        Mode = enMode.UpdateMode;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.UpdateMode:
                    if (_UpdateUser())
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


        public static bool ISPersonIsUser(int ID)
        {
            return clsUserData.ISPersonIsUser(ID);
        }
        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }

        public static bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }
    }
}
