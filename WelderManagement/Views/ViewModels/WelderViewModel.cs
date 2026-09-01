namespace WelderManagement.Views.ViewModels
{
    public class WelderViewModel
    {
        public int WelderID { get; set; }
        public string WelderCode { get; set; }
        public string WelderName { get; set; }
        public string Nationality { get; set; }
        public DateTime JoinningDate { get; set; }
        public string PassportNo { get; set; }
        public int SubContractorID { get; set; }
        public int AgencyID { get; set; }
        public string WelderQualTest { get; set; }

        List<WelderQualificationViewModel> Qualifications { get; set; }
    }

    public class WelderQualificationViewModel
    {


    }
}
