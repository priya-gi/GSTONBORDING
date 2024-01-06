using GSTONBORDINGLibrary.SuperAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace GSTONBORDING.Controllers.SuperAdmin
{
    public class SuperAdminController : Controller
    {
        BALSuperAdmin adm = new BALSuperAdmin();
        SupperAdmin supadm = new SupperAdmin();
        // GET: SuperAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SuperAdminDashboard()
        {
            return View();
        }




        //******* company regitration Code *******//
        //[HttpPost]
        //public async Task<ActionResult> CompanyRegistration(SupperAdmin ad)
        //{
        //    DataSet ds = new DataSet();

        //    ds = adm.CompanyCode();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        supadm.CompanyId = Convert.ToInt32(dr["Id"].ToString());
        //    }
        //    int cn = supadm.CompanyId + 1;
        //    string fp1 = "COR0";
        //    string code = cn + supadm.CompanyCode;
        //    string fno = fp1 + string.Format("{0:0000}", code);
        //    ViewBag.ComapnyRegistration = fno;
        //    return await Task.Run(() => View());

        //    // return View();
        //}
        //-----country bind---------------

        public JsonResult CountryBind()
        {
            DataSet ds = new DataSet();
            ds = adm.Get_Country();
            List<SelectListItem> countrylist = new List<SelectListItem>();
            if (ds.Tables[0].Rows.Count > 0)

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    countrylist.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["CountryID"].ToString() });

                }
            ViewBag.country = countrylist;
            return Json(countrylist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StateBind(int Countryid)
        {

            DataSet ds = new DataSet();
            ds = adm.Get_State(Countryid);
            List<SelectListItem> statelist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                statelist.Add(new SelectListItem { Text = dr["StateName"].ToString(), Value = dr["StateID"].ToString() });
            }
            ViewBag.StateName = statelist;
            return Json(statelist, JsonRequestBehavior.AllowGet);

        }
        public JsonResult CityBind(int stateid)
        {

            DataSet ds = new DataSet();
            ds = adm.Get_City(stateid);
            List<SelectListItem> citylist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                citylist.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["CityId"].ToString() });
            }
            ViewBag.cityname = citylist;
            return Json(citylist, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCompanyList()
        {
            SupperAdmin Obju = new SupperAdmin();
            BALSuperAdmin Obj = new BALSuperAdmin();
            DataSet ds = new DataSet();
            ds = Obj.CompanyList();
            List<SupperAdmin> lstUser = new List<SupperAdmin>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SupperAdmin supadmin = new SupperAdmin();
                supadmin.CompanyCode = ds.Tables[0].Rows[i]["CompanyCode"].ToString();
                supadmin.CompanyName = ds.Tables[0].Rows[i]["CompanyName"].ToString();


                supadmin.OwnerNmae = ds.Tables[0].Rows[i]["OwnerNmae"].ToString();
                supadmin.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                supadmin.OwnerMobileNumber = ds.Tables[0].Rows[i]["OwnerMobileNumber"].ToString();

                //supadmin.NoOfEmployee = Convert.ToInt32(ds.Tables[0].Rows[i]["NoOfEmployee"].ToString());


                supadmin.BusinessRegistrationnumber = ds.Tables[0].Rows[i]["BusinessRegistrationnumber"].ToString();

                lstUser.Add(supadmin);
            }
            //Obju.SupperAdminList2 = lstUser;
            Obju.CompanyRegistration = lstUser;
            return View(Obju);

        }

        //-------------company details-----------------------


        [HttpGet]

        public ActionResult CompanyDetails(string id)
        {
            SupperAdmin objadm = new SupperAdmin();
            BALSuperAdmin Obj = new BALSuperAdmin();
            objadm.CompanyCode = id;
            DataTable dt = new DataTable();
            dt = Obj.CompanyBind(objadm.CompanyCode);

            foreach (DataRow row in dt.Rows)
            {
                SupperAdmin admin = new SupperAdmin();
                ViewBag.CompanyName = Convert.ToString(row["CompanyName"]);
                ViewBag.BusinessTypeID = Convert.ToInt32(row["BusinessTypeID"]);
                ViewBag.BusinessTypeName = Convert.ToString(row["BusinessTypeName"]);
                ViewBag.BusinessTypeName = Convert.ToString(row["BusinessTypeName"]);
               // ViewBag.BusinessAddress = Convert.ToString(row["BusinessAddress"]);



                ViewBag.CountryId = Convert.ToInt32(row["CountryId"].ToString());
                ViewBag.StateId = Convert.ToInt32(row["StateId"]);
               // ViewBag.CountryName = Convert.ToString(row["CountryName"]);
               // ViewBag.StateName = Convert.ToString(row["StateName"]);

               // ViewBag.CityName = Convert.ToString(row["CityName"]);
                ViewBag.CityId = Convert.ToInt32(row["CityId"].ToString());
                ViewBag.Zipcode = Convert.ToInt32(row["ZipCode"].ToString());
                ViewBag.Phonenumber = row["Phonenumber"].ToString();
                ViewBag.Email = row["Email"].ToString();
                ViewBag.Website = row["Website"].ToString();
                ViewBag. BusinessRegistrationnumber = row["BusinessRegistrationnumber"].ToString();
                ViewBag.OwnerNmae = Convert.ToString(row["OwnerNmae"]);
                ViewBag.OwnerPositionName = row["OwnerPositionName"].ToString();
                ViewBag.OwnerMobileNumber = row["OwnerMobileNumber"].ToString();
                ViewBag.OwnerEmail = row["OwnerEmail"].ToString();
                ViewBag.AdditionalBusinessOwnerName = Convert.ToString(row["AdditionalBusinessOwnerName"]);
                ViewBag.PercentageOwnership = Convert.ToInt32(row["PercentageOwnership"].ToString());

                ViewBag.AdditionalOwnerPhoneNumber = row["AdditionalOwnerPhoneNumber"].ToString();
                ViewBag.AdditionalOwnerEmailId = row["AdditionalOwnerEmailId"].ToString();
                ViewBag.BankName = row["BankName"].ToString();

                ViewBag.AccountNumber = row["AccountNumber"].ToString();

                ViewBag.IFSCCode = row["IFSCCode"].ToString();


                ViewBag.AccountHolderName = row["AccountHolderName"].ToString();
                ViewBag.BranchNmae = row["BranchNmae"].ToString();

                ViewBag.BranchAddress = row["BranchAddress"].ToString();
                ViewBag.BranchState = row["BranchState"].ToString();
                ViewBag.BranchCity = row["BranchCity"].ToString();
                ViewBag.BranchZipcode = row["BranchZipcode"].ToString();
                ViewBag.UPIId = row["UPIId"].ToString();
                ViewBag.PANNumber = row["PANNumber"].ToString();

                ViewBag.TANNumber = row["TANNumber"].ToString();
                ViewBag.UdyamAadharNumber = row["UdyamAadharNumber"].ToString();
                ViewBag.TDSNumber = row["TDSNumber"].ToString();
                ViewBag.CompanyRegistrationDate = Convert.ToDateTime(row["CompanyRegistrationDate"].ToString());

            }

            return View(objadm);

        }
        [HttpGet]
        public ActionResult Company()
        {
            CountryBind();

            return View();
        }
        [HttpPost]
        public ActionResult Company(SupperAdmin objU)
        {


            DataSet ds = new DataSet();
            ds = adm.CompanyCode();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                objU.CompanyId = Convert.ToInt32(dr["id"].ToString());

            }
            int Pn = objU.CompanyId + 1;
            string fp1 = "C00";
            string code = Pn + objU.CompanyCode;
            string Fno = fp1 + string.Format("{0:0000}", code);
             int CityId = Convert.ToInt32(objU.CityId.ToString());
            //int industry = Convert.ToInt32(objU.CompanyId.ToString());

            adm.SaveUser(Fno, objU.CompanyName, objU.BusinessTypeID, objU.BusinessTypeName, objU.BusinessAddress, objU.CountryId, objU.StateId, objU.CityId,
                objU.Zipcode, objU.Phonenumber, objU.Email, objU.Website, objU.BusinessRegistrationnumber, objU.OwnerNmae, objU.OwnerPositionName, objU.OwnerMobileNumber, objU.OwnerEmail,
                objU.AdditionalBusinessOwnerName, objU.PercentageOwnership, objU.AdditionalOwnerPhoneNumber, objU.AdditionalOwnerEmailId, objU.BankName, objU.AccountHolderName, objU.AccountNumber, objU.IFSCCode,
                objU.BranchNmae, objU.BranchAddress, objU.BranchState, objU.BranchCity, objU.BranchZipcode, objU.UPIId, objU.PANNumber,
                objU.TANNumber, objU.UdyamAadharNumber, objU.TDSNumber, objU.CompanyRegistrationDate);

            ViewBag.massage = "Save Success";
            return RedirectToAction("GetCompanyList");
        }

        [HttpGet]
        public ActionResult CompanyRegistration()
        {
            CountryBind();

            return View();
        }


        [HttpPost]
        public ActionResult CompanyRegistration(SupperAdmin objU)
        {
            //Status();
            //IndustryBind();
            CountryBind();
            //SupperAdmin objadm = new SupperAdmin();
            //BALSuperAdmin Obj = new BALSuperAdmin();
            DataSet ds = new DataSet();
            ds = adm.CompanyCode();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                objU.CompanyId = Convert.ToInt32(dr["id"].ToString());

            }
            int Pn = objU.CompanyId + 1;
            string fp1 = "C00";
            string code = Pn + objU.CompanyCode;
            String Fno = fp1 + string.Format("{0:0000}", code);
         // int city = Convert.ToInt32(objU.CityId.ToString());
          // int industry = Convert.ToInt32(objU.CompanyId.ToString());

            adm.SaveUser(objU.CompanyCode, objU.CompanyName, objU.BusinessTypeID, objU.BusinessTypeName, objU.BusinessAddress, objU.CountryId, objU.StateId, objU.CityId,
                objU.Zipcode, objU.Phonenumber, objU.Email, objU.Website, objU.BusinessRegistrationnumber, objU.OwnerNmae, objU.OwnerPositionName, objU.OwnerMobileNumber, objU.OwnerEmail,
                objU.AdditionalBusinessOwnerName, objU.PercentageOwnership, objU.AdditionalOwnerPhoneNumber, objU.AdditionalOwnerEmailId, objU.BankName, objU.AccountHolderName, objU.AccountNumber, objU.IFSCCode,
                objU.BranchNmae, objU.BranchAddress, objU.BranchState, objU.BranchCity, objU.BranchZipcode, objU.UPIId, objU.PANNumber,
                objU.TANNumber, objU.UdyamAadharNumber, objU.TDSNumber, objU.CompanyRegistrationDate);

            ViewBag.massage = "Save Success";
            return RedirectToAction("GetCompanyList");

        }

        //----------company edit-----------




        [HttpGet]

        public ActionResult CompanyEdit(string id)
        {

            //Status();
            //IndustryBind();
            CountryBind();

            //SupperAdmin objadm = new SupperAdmin();
            //objadm.CompanyCode = id;
            //SqlDataReader dr2;
            //dr2 = supadm.CompanyBind(objadm.CompanyCode);

            SupperAdmin objadm = new SupperAdmin();
            BALSuperAdmin Obj = new BALSuperAdmin();
            objadm.CompanyCode = id;
            DataTable dt = new DataTable();
            dt = Obj.CompanyBind(objadm.CompanyCode);


            foreach (DataRow row in dt.Rows)
            {
                SupperAdmin admin = new SupperAdmin();
                ViewBag.CompanyName = Convert.ToString(row["CompanyName"]);
                ViewBag.BusinessTypeID = Convert.ToInt32(row["BusinessTypeID"]);
                ViewBag.BusinessTypeName = Convert.ToString(row["BusinessTypeName"]);

                ViewBag.BusinessAddress = Convert.ToString(row["BusinessAddress"]);



                ViewBag.CountryId = Convert.ToInt32(row["CountryId"].ToString());
                 ViewBag.StateId = Convert.ToInt32(row["StateId"]);
               // ViewBag.StateId = row["StateId"].ToString();
                //ViewBag.CountryName = Convert.ToString(row["CountryName"]);
                //ViewBag.StateName = Convert.ToString(row["StateName"]);
                ViewBag.CityId = Convert.ToInt32(row["CityId"].ToString());

               // ViewBag.CityName = Convert.ToString(row["CityName"]);
                ViewBag.CityId = Convert.ToInt32(row["CityId"].ToString());
                ViewBag.Zipcode = Convert.ToInt32(row["ZipCode"].ToString());
                ViewBag.Phonenumber = row["Phonenumber"].ToString();
                ViewBag.Email = row["Email"].ToString();
                ViewBag.Website = row["Website"].ToString();
                ViewBag.BusinessRegistrationnumber = row["BusinessRegistrationnumber"].ToString();
                ViewBag.OwnerNmae = Convert.ToString(row["OwnerNmae"]);
                ViewBag.OwnerPositionName = row["OwnerPositionName"].ToString();
                ViewBag.OwnerMobileNumber = row["OwnerMobileNumber"].ToString();
                ViewBag.OwnerEmail = row["OwnerEmail"].ToString();
                ViewBag.AdditionalBusinessOwnerName = Convert.ToString(row["AdditionalBusinessOwnerName"]);
                ViewBag.PercentageOwnership = Convert.ToInt32(row["PercentageOwnership"].ToString());

                ViewBag.AdditionalOwnerPhoneNumber = row["AdditionalOwnerPhoneNumber"].ToString();
                ViewBag.AdditionalOwnerEmailId = row["AdditionalOwnerEmailId"].ToString();
                ViewBag.BankName = row["BankName"].ToString();

                ViewBag.AccountNumber = row["AccountNumber"].ToString();

                ViewBag.IFSCCode = row["IFSCCode"].ToString();


                ViewBag.AccountHolderName = row["AccountHolderName"].ToString();
                ViewBag.BranchNmae = row["BranchNmae"].ToString();

                ViewBag.BranchAddress = row["BranchAddress"].ToString();
                ViewBag.BranchState = row["BranchState"].ToString();
                ViewBag.BranchCity = row["BranchCity"].ToString();
                ViewBag.BranchZipcode = row["BranchZipcode"].ToString();
                ViewBag.UPIId = row["UPIId"].ToString();
                ViewBag.PANNumber = row["PANNumber"].ToString();

                ViewBag.TANNumber = row["TANNumber"].ToString();
                ViewBag.UdyamAadharNumber = row["UdyamAadharNumber"].ToString();
                ViewBag.TDSNumber = row["TDSNumber"].ToString();
                ViewBag.CompanyRegistrationDate = Convert.ToDateTime(row["CompanyRegistrationDate"].ToString());



            }
            return View(objadm);

        }
        //------------company update------------------------
        [HttpPost]
        public ActionResult CompanyEdit()
        {

            SupperAdmin objU = new SupperAdmin();
            BALSuperAdmin ba = new BALSuperAdmin();
                if (objU.CityId != 0)
                {
               // int StateId = Convert.ToInt32(objU.CityId.ToString());
                int city = Convert.ToInt32(objU.CityId.ToString());
                // int industry = Convert.ToInt32(objU.IndustryId.ToString());
                ba.CompanyUpdate(objU);

           

        //        BALSuperAdmin.UpdateCompany(objU.CompanyId, objU.CompanyCode, objU.CompanyName, objU.BusinessTypeID, objU.BusinessTypeName, objU.BusinessAddress,objU.CountryId, objU.CountryName, objU.StateId,
        //     objU.StateName, objU.CityId, objU.CityName, objU.Zipcode, objU.Phonenumber, objU.Email, objU.Website,
        //objU.BusinessRegistrationnumber, objU.OwnerNmae, objU.OwnerPositionName, objU.OwnerMobileNumber, objU.OwnerEmail, objU.AdditionalBusinessOwnerName, objU.PercentageOwnership, objU.AdditionalOwnerPhoneNumber,
        //objU.AdditionalOwnerEmailId, objU.BankName, objU.AccountHolderName, objU.AccountNumber, objU.IFSCCode, objU.BranchNmae, objU.BranchAddress,
        //objU.BranchState, objU.BranchCity, objU.BranchZipcode, objU.UPIId, objU.PANNumber, objU.TANNumber, objU.UdyamAadharNumber, objU.TDSNumber, objU.CompanyRegistrationDate);
                }
                else
                {

                    string city1 = Request.Form["cityid"];
                    int City = Convert.ToInt32(city1);
                int city = Convert.ToInt32(objU.CityId.ToString());
                //int industry = Convert.ToInt32(objU.IndustryId.ToString());
                ba.CompanyUpdate(objU);
                //    BALSuperAdmin.CompanyUpdate(objU.CompanyCode,objU.CompanyName, objU.BusinessTypeID, objU.BusinessTypeName, objU.BusinessAddress,
                //objU.CountryId, objU.CountryName, objU.StateId,objU.StateName, city, objU.CityName, objU.Zipcode, objU.Phonenumber, objU.Email, objU.Website,
                //objU.BusinessRegistrationnumber, objU.OwnerNmae, objU.OwnerPositionName, objU.OwnerMobileNumber, objU.OwnerEmail, objU.AdditionalBusinessOwnerName, objU.PercentageOwnership, objU.AdditionalOwnerPhoneNumber,
                //objU.AdditionalOwnerEmailId, objU.BankName, objU.AccountHolderName, objU.AccountNumber, objU.IFSCCode, objU.BranchNmae, objU.BranchAddress,
                //objU.BranchState, objU.BranchCity, objU.BranchZipcode, objU.UPIId, objU.PANNumber, objU.TANNumber, objU.UdyamAadharNumber, objU.TDSNumber, objU.CompanyRegistrationDate);
            }



        
            //else
            //{
            //    string Logo = Request.Form["Logo"];

            //    if (objU.CityId != 0)
            //    {


            //        int city = Convert.ToInt32(objU.CityId.ToString());
            //        int industry = Convert.ToInt32(objU.IndustryId.ToString());

            //        BALSuperAdmin.UpdateCompany(objU.CompanyCode, objU.CompanyName, objU.OwnerName, objU.CompanyAddress, city, objU.ZipCode, objU.Email1,
            //            objU.Email2, objU.Email3, objU.Email4, objU.CompanyPerfix, objU.HeaderFilePath, objU.FooterFilePath, objU.WhatsAppNo,
            //            objU.Website, objU.NoOfEmployee, Logo/*objU.CompanyLogo*/, objU.GSTNo, objU.IndustryId, objU.CompanyDescription, objU.CompanyRegDate,
            //            objU.CompanyStatusId);
            //    }
                



            return RedirectToAction("GetCompanyList");
        }


    }


}