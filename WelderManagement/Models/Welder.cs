namespace WelderManagement.Models
{
    public class Welder
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
    }
}
 