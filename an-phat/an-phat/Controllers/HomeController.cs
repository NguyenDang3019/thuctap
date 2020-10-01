
using an_phat.Models;
using DataAccess.Framework;
using DataAccess.Framework.Entity;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using WebMatrix.WebData;

namespace an_phat.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Login()
        {

            return View();

        }



        [HttpPost]
        public ActionResult Login(LoginModel loginModel)

        {


            if (ModelState.IsValid)

            {

                bool isAuthenticated = WebSecurity.Login(loginModel.Email, loginModel.UserPassword);
                if (isAuthenticated)
                {
                    string[] userAdmin = Roles.FindUsersInRole("Admin", loginModel.Email);
                    string[] userUser = Roles.FindUsersInRole("User", loginModel.Email);

                    if (userAdmin.Length == 1)
                    {
                        ModelState.AddModelError("", "Admin :))");
                    }
                    else
                    {
                            Response.Redirect("/Home/Index");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email hoặc Password không tồn tại.");
                }


            }
            return View(loginModel);
        }




        [HttpGet]

        public ActionResult Register()
        {
            RegistrationModel user = new RegistrationModel();
            setViewBag(user);
            return View(user);

        }

        public void setViewBag(RegistrationModel model)
        {
            using (var dbContext = new AnPhatDBContext())
            {

                IEnumerable<District> districts = dbContext.Districts.ToList();
                model.DistrictLlist = new SelectList(districts, "ID", "NameDistrict");

            }
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {

                bool isUserExits = WebSecurity.UserExists(model.UserEmail);
                if (isUserExits)
                {
                    ModelState.AddModelError("UserEmail", "Email đăng nhập đã tồn tại");


                }
                else
                {

                    WebSecurity.CreateUserAndAccount(model.UserEmail, model.UserPassword,
                        new
                        {
                            ID = model.setID(),
                            UserName = model.UserName,
                            DistrictID = model.DistrictID,
                            Gender = model.Gender,
                            PhoneNumber = Int64.Parse(model.PhoneNumber),
                            UserAddress = model.Address
                        }
                         );
                    Roles.AddUserToRole(model.UserEmail,"User");
                    Response.Redirect("/Home/Index");
                    //Roles.AddUsersToRole();
                }
            }
            else
            {

                setViewBag(model);
                return View(model);
            }
            return View(model);

        }
    }
}

//[HttpPost]
//public ActionResult Register(RegistrationModel model)
//{


//    if (ModelState.IsValid)
//    {
//        // create company and attempt to register the user
//        try
//        {
//            websecurity.createuserandaccount(user.username,
//                                               user.userpassword,
//                                                propertyvalues: new
//                                                {
//                                                    email = user.useremail,

//                                                    phonenumber = user.useremail,


//                                                    //                                            });

//                                                    db.users.add(user.);

//            var newuser = db.userprofiles.firstordefault(u => u.username == addcompanyviewmodel.user.username);
//            if (newuser != null)
//            {
//                newuser.companyicanedit = addcompanyviewmodel.company;
//                db.entry(newuser).state = entitystate.modified;
//                db.savechanges();
//                return redirecttoaction("index");
//            }
//            else
//            {
//                modelstate.addmodelerror("", "new user wasn't added");
//            }
//        }
//        catch (MembershipCreateUserException e)
//        {
//            ModelState.AddModelError("", mywebsite.controllers.accountcontroller.errorcodetostring(e.statuscode));
//        }

//    }


//    return View(model);
//}

