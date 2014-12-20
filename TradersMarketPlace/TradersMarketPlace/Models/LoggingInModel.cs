using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Common;
using Business;

namespace TradersMarketPlace.Models
{
    public class LoggingInModel
    {
        [Required(ErrorMessage = "Username required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; }
    }
}