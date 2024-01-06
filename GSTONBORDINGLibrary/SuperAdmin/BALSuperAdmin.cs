using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTONBORDINGLibrary.SuperAdmin
{
    public class BALSuperAdmin
    {
        static string CS = ConfigurationManager.ConnectionStrings["GSTONBoarding"].ConnectionString;
        SqlConnection con = new SqlConnection(CS);

        public void ManageConnection()
        {
            if (con.State == ConnectionState.Closed)
            {

                con.Open();
            }
            else
            {
                con.Close();
            }

        }
   

        public DataSet CompanyCode()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "BindCompanycode");
            SqlDataAdapter adpt = new SqlDataAdapter();
            // DataTable dt = new DataTable();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();

            adpt.Fill(ds);
            return ds;

        }

      
         
        //********************project in progress count monthly********************************
        public DataSet TotalEmployees()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "TotalEmployees");
            
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();

            adpt.Fill(ds);
            return ds;
            //
        }

        //public DataSet SelectedCandidate()
        //{
        //    ManageConnection();
        //    SqlCommand cmd = new SqlCommand("SuperAdmin", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@flag", "SelectedCandidate");
           
        //    SqlDataAdapter adpt = new SqlDataAdapter();
        //    adpt.SelectCommand = cmd;
        //    DataSet ds = new DataSet();

        //    adpt.Fill(ds);
        //    return ds;
        //    //
        //}

        public DataSet TotalCompanyRegistered()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "TotalCompanyRegistered");
           
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();

            adpt.Fill(ds);
            return ds;
            //
        }

        public DataSet TotalOnboardingdonecandidate()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "TotalOnboardingdonecandidate");
            
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();

            adpt.Fill(ds);
            return ds;
            //
        }

        public DataSet TotalOnboardingpendingcandidate()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "TotalOnboardingdonecandidate");
            //cmd.Parameters.AddWithValue("@statusid", StatusId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();

            adpt.Fill(ds);
            return ds;
            //
        }

        //----------------companyregistration fun-------------------


        public void SaveUser(string companycode, string CompanyName, int BusinessTypeID, string BusinessTypeName, string BusinessAddress,
            int CountryID,  int StateID, int CityId, int ZipCode, string Phonenumber, string Email, string Website,
             string BusinessRegistrationnumber, string OwnerName, string OwnerPositionName, string OwnerMobileNumber, string OwnerEmail, string AdditionalBusinessOwnerName, int PercentageOwnership, string AdditionalOwnerPhoneNumber, 
             string AdditionalOwnerEmailId, string BankName, string AccountHolderName, string AccountNumber, string IFSCCode, string BranchNmae, string BranchAddress,
             string BranchState, string BranchCity, string BranchZipcode, string UPIId, string PANNumber, string TANNumber, string UdyamAadharNumber, string TDSNumber, DateTime companyRegistrationDate)
        {
            con.Close();
           ManageConnection();

         

            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SaveCompany");
            cmd.Parameters.AddWithValue("@companycode", companycode);
            cmd.Parameters.AddWithValue("@companyname", CompanyName);
            cmd.Parameters.AddWithValue("@businesstypeid", BusinessTypeID);
            cmd.Parameters.AddWithValue("@businesstypename", BusinessTypeName);
       
            cmd.Parameters.AddWithValue("@Businessaddress", BusinessAddress);
            cmd.Parameters.AddWithValue("@countryid", CountryID);
  
            cmd.Parameters.AddWithValue("@stateid", StateID);

            cmd.Parameters.AddWithValue("@cityid", CityId);
           
            cmd.Parameters.AddWithValue("@zipcode", ZipCode);
            cmd.Parameters.AddWithValue("@phonenumber", Phonenumber);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@website", Website);
            cmd.Parameters.AddWithValue("@businessregistrationnumber", BusinessRegistrationnumber);
            cmd.Parameters.AddWithValue("@ownernmae", OwnerName);
            cmd.Parameters.AddWithValue("@ownerpositionname", OwnerPositionName);
            cmd.Parameters.AddWithValue("@ownermobilenumber", OwnerMobileNumber);
            cmd.Parameters.AddWithValue("@owneremail", OwnerEmail);
            cmd.Parameters.AddWithValue("@additionalbusinessownerName", AdditionalBusinessOwnerName);
            cmd.Parameters.AddWithValue("@percentageownership", PercentageOwnership);
            cmd.Parameters.AddWithValue("@additionalownerphonenumber", AdditionalOwnerPhoneNumber);
            cmd.Parameters.AddWithValue("@additionalowneremailid", AdditionalOwnerEmailId);
            cmd.Parameters.AddWithValue("@bankname", BankName);
            cmd.Parameters.AddWithValue("@accountholdername", AccountHolderName);
            cmd.Parameters.AddWithValue("@accountnumber", AccountNumber);
            cmd.Parameters.AddWithValue("@ifsccode", IFSCCode);
            cmd.Parameters.AddWithValue("@branchnmae", BranchNmae);
            cmd.Parameters.AddWithValue("@branchaddress", BranchAddress);
            cmd.Parameters.AddWithValue("@branchstate", BranchState);
            cmd.Parameters.AddWithValue("@branchcity", BranchCity);
            cmd.Parameters.AddWithValue("@branchzipcode", BranchZipcode);
            cmd.Parameters.AddWithValue("@upiid", UPIId);
            cmd.Parameters.AddWithValue("@pannumber", PANNumber);
            cmd.Parameters.AddWithValue("@tannumber", TANNumber);

            cmd.Parameters.AddWithValue("@udyamaadharnumber", UdyamAadharNumber);
            cmd.Parameters.AddWithValue("@tdsnumber", TDSNumber);

            cmd.ExecuteNonQuery();

           
        }


        //--------country,state,city------------------


        public DataSet Get_Country()
        {
            ManageConnection();
            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetCountry");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            //adpt.SelectCommand(cmd);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }



        public DataSet Get_State(int countryId)
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetState");
            cmd.Parameters.AddWithValue("@countryId", countryId);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
         
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }
        public DataSet Get_City(int StateId)
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetCity");
            cmd.Parameters.AddWithValue("@StateId", StateId);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            //adpt.SelectCommand(cmd);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;
        }


       // ------companylist----------

        public DataSet CompanyList()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetCompanyList");
            SqlDataAdapter adpt = new SqlDataAdapter();
            // DataTable dt = new DataTable();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

        }

        public DataTable CompanyBind(string id)
        {

            ManageConnection();
            
            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetDetails");
            cmd.Parameters.AddWithValue("@Companycode", id);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;

        }



        //------------------update company-------------------



        public void CompanyUpdate(SupperAdmin sa)
        {
            ManageConnection();

            SqlCommand cmd = new SqlCommand("SuperAdmin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "UpdateCompany");
            //cmd.Parameters.AddWithValue("@companyid", CompanyId);
            cmd.Parameters.AddWithValue("@companycode", sa.CompanyCode);
            cmd.Parameters.AddWithValue("@companyname", sa.CompanyName);
            cmd.Parameters.AddWithValue("@businesstypeid", sa.BusinessTypeID);
            cmd.Parameters.AddWithValue("@businesstypename",sa. BusinessTypeName);
            cmd.Parameters.AddWithValue("@Businessaddress", sa.BusinessAddress);
            //cmd.Parameters.AddWithValue("@Businessaddress", sa.BusinessAddress);
            cmd.Parameters.AddWithValue("@countryid", sa.CountryId);
            //cmd.Parameters.AddWithValue("@countryname", sa.CountryName);
            cmd.Parameters.AddWithValue("@stateid", sa.StateId);
           // cmd.Parameters.AddWithValue("@statename", sa.StateName);
            cmd.Parameters.AddWithValue("@cityid", sa.CityId);
            //cmd.Parameters.AddWithValue("@cityname", sa.CityName);
            cmd.Parameters.AddWithValue("@zipcode", sa.Zipcode);
            cmd.Parameters.AddWithValue("@phonenumber", sa.Phonenumber);
            cmd.Parameters.AddWithValue("@email", sa.Email);
            cmd.Parameters.AddWithValue("@website", sa.Website);
            cmd.Parameters.AddWithValue("@businessregistrationnumber", sa.BusinessRegistrationnumber);
            cmd.Parameters.AddWithValue("@ownernmae", sa.OwnerNmae);
            cmd.Parameters.AddWithValue("@ownerpositionname", sa.OwnerPositionName);
            cmd.Parameters.AddWithValue("@ownermobilenumber", sa.OwnerMobileNumber);
            cmd.Parameters.AddWithValue("@owneremail", sa.OwnerEmail);
            cmd.Parameters.AddWithValue("@additionalbusinessownerName", sa.AdditionalBusinessOwnerName);
            cmd.Parameters.AddWithValue("@percentageownership", sa.PercentageOwnership);
            cmd.Parameters.AddWithValue("@additionalownerphonenumber", sa.AdditionalOwnerPhoneNumber);
            cmd.Parameters.AddWithValue("@additionalowneremailid", sa.AdditionalOwnerEmailId);
            cmd.Parameters.AddWithValue("@bankname", sa.BankName);
            cmd.Parameters.AddWithValue("@accountholdername", sa.AccountHolderName);
            cmd.Parameters.AddWithValue("@accountnumber", sa.AccountNumber);
            cmd.Parameters.AddWithValue("@ifsccode", sa.IFSCCode);
            cmd.Parameters.AddWithValue("@branchnmae", sa.BranchNmae);
            cmd.Parameters.AddWithValue("@branchaddress", sa.BranchAddress);
            cmd.Parameters.AddWithValue("@branchstate",  sa.BranchState);
            cmd.Parameters.AddWithValue("@branchcity", sa.BranchCity);
            cmd.Parameters.AddWithValue("@branchzipcode", sa.BranchZipcode);
            cmd.Parameters.AddWithValue("@upiid", sa.UPIId);
            cmd.Parameters.AddWithValue("@pannumber", sa.PANNumber);
            cmd.Parameters.AddWithValue("@tannumber", sa.TANNumber);

            cmd.Parameters.AddWithValue("@udyamaadharnumber", sa.UdyamAadharNumber);
            cmd.Parameters.AddWithValue("@tdsnumber", sa.TDSNumber);
           // cmd.Parameters.AddWithValue("@companyregistrationdate", sa.CompanyRegistrationDate);


            cmd.ExecuteNonQuery();


        }

        //-----------delete company--------------

        public void Delete(int Companycode)
        {
            con.Close();
            con.Open();
            SqlCommand cmd = new SqlCommand("Admin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DeleteCompanycode");
            cmd.Parameters.AddWithValue("@leavestructureid", Companycode);
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
