
using DataAccess.Framework;
using DataAccess.Framework.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace an_phat.Models
{
    public class RegistrationModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Họ và tên")]
        public String UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Email không đúng định dạng")]
        public String UserEmail { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Password")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$",
            ErrorMessage = "Password không đúng định dạng")]
        public String UserPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại Password")]
        [System.ComponentModel.DataAnnotations.Compare("UserPassword", 
            ErrorMessage = "Nhập lại mật khẩu không trùng khớp")]
        public String ConfirmPassword { get; set; }

        public String Address { get; set; }
        [RegularExpression("^(09|03|07|08|05)+([0-9]{8})$",
            ErrorMessage = "Số điện thoại không đúng định dạng")]
        public String PhoneNumber { get; set; }

        public Boolean Gender { get; set; }
       
        public int DistrictID { get; set; }

        public IEnumerable<SelectListItem> DistrictLlist { get; set; }

        public int setID()
        {
            using (AnPhatDBContext db = new AnPhatDBContext())
            {
                IEnumerable<User> users = db.Users.ToList();
                if(users.Count() ==0)
                { ID = 0; }
                else
                {
                    ID = users.Count();
                }
                return ID;
            }
           
        }
       
        
    }
}