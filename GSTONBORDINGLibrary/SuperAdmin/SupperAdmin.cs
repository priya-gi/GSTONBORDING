using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTONBORDINGLibrary.SuperAdmin
{
    public class SupperAdmin
    {
        public DateTime CompanyRegDate;

        //----------------dashboard property----------------
        public string TotalEmployees { get; set; }
        public string SelectedCandidate { get; set; }

        public string TotalCompanyRegistered { get; set; }
        public string TotalOnboardingdonecandidate { get; set; }
        public string TotalOnboardingpendingcandidate { get; set; }


        //----------------Registration form property----------------
       

        

   
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public int BusinessTypeID { get; set; }

        public string BusinessTypeName { get; set; }

        public string BusinessAddress { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public string StateName { get; set; }
        public string CountryName { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }
       // public string Zipcode { get; set; }
        public int Zipcode { get; set; }
        public string Phonenumber { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string BusinessRegistrationnumber { get; set; }

        public DateTime CompanyRegistrationDate { get; set; } = DateTime.Now;

        public string OwnerNmae { get; set; }

        public string OwnerPositionName { get; set; }

        public string OwnerMobileNumber { get; set; }

        public string OwnerEmail { get; set; }
        public string AdditionalBusinessOwnerName { get; set; }
        public int PercentageOwnership { get; set; }

        public string AdditionalOwnerPhoneNumber { get; set; }

        public string AdditionalOwnerEmailId { get; set; }

        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }

        public string IFSCCode { get; set; }
        public string BranchNmae { get; set; }

        public string BranchAddress { get; set; }

        public string BranchState { get; set; }

        public string BranchCity { get; set; }

        public string BranchZipcode { get; set; }

        public string UPIId { get; set; }
        public string PANNumber { get; set; }

        public string TANNumber { get; set; }

        public string UdyamAadharNumber { get; set; }

        public string TDSNumber { get; set; }

        

        public List<SupperAdmin> CompanyRegistration { get; set; }

       
    }
}
