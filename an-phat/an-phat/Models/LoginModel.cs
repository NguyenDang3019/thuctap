
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace an_phat.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Email { get; set; }
        [Required (ErrorMessage = "Vui lòng nhập Password")]
        public String UserPassword { get; set; }

    }
    
}