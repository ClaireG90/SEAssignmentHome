using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Common;
using Business;
using System.Web.Mvc;

namespace TradersMarketPlace.Models
{
    public class RegistrationModel
    {
        [Required]
        public User user { get; set; }

        public SelectList TownList { get; set; }
        public SelectList CountryList { get; set; }
        public SelectList RolesList { get; set; }
        public virtual Account myAccount { get; set; }
        public List<UserType> myRole { get; set; }



        public Town myTown { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage="Surname is required.")]
        public string Surname {get;set;}
        
        [Required (ErrorMessage = "Email is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email {get;set;}

        [Required(ErrorMessage ="Residance number is required.")]
        public int HouseNumber {get;set;}
        
        [Required(ErrorMessage = "Street name is required.")]
        public string StreetName {get;set;}

        [Required]
        public List<UserType> roles { get; set; }

        [Required(ErrorMessage = "Username required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; }

        public RegistrationModel()
        {
            List<bool> myList = new List<bool>();
            myList.Add(true);
            myList.Add(false);

            RolesList = new SelectList(new BAUserType().GetRoles(), "ID", "UserType1");
            TownList = new SelectList(new BATown().GetTowns(), "ID", "Town1");
            CountryList = new SelectList(new BACountry().GetCountries(), "ID", "Country1");
        }
    }
}