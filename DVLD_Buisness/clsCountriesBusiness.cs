using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsCountriesBusiness
    {
        public int CountryID {  get; set; }
        public string CountryName { get; set; }

        clsCountriesBusiness(int  CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName; 
        }

        public static DataTable GetAllCountries()
        {
            return clsCountrierData.GetAllCountries();
        }
        public static clsCountriesBusiness GetCountryInfoByID(int ID)
        {
            string CountryName = "";

            if(clsCountrierData.GetCountryInfoByID(ID,ref CountryName))
            {
                return new clsCountriesBusiness(ID, CountryName);
            }
            return null;
        }
        public static clsCountriesBusiness GetCountryInfoByName(string Name)
        {
            int countryID = -1;

            if (clsCountrierData.GetCountryInfoByName(Name ,ref countryID))
            {
                return new clsCountriesBusiness(countryID, Name);
            }
            return null;
        }

    }
}
