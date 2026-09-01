using Microsoft.Data.SqlClient;
using WelderManagement.Models;
namespace WelderManagement.Repository
{
    public class WelderRepository
    {
        public List<Welder> GetAllWelders()                       // VIEW 
        {
           
            string ConnectionString = @"server= (localdb)\MSSQLLocalDB;
                                       Database = WelderDB;
                                       Trusted_Connection=True;
                                       TrustServerCertificate=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select * from Welder";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Welder> welders = new List<Welder>();

            while (dr.Read())
            {
                Welder w = new Welder();
                w.WelderID = Convert.ToInt32(dr["WelderID"]);
                w.WelderCode = dr["WelderCode"].ToString();
                w.WelderName = dr["WelderName"].ToString(); 
                w.Nationality = dr["Nationality"].ToString();
                w.JoinningDate = Convert.ToDateTime(dr["JoinningDate"]);
                w.PassportNo = dr["PassportNo"].ToString();
                w.SubContractorID = Convert.ToInt32(dr["SubContractorID"]);  
                w.AgencyID = Convert.ToInt32(dr["AgencyID"]); 
                w.WelderQualTest = dr["WelderQualTest"].ToString();

                welders.Add(w);
            } 
            con.Close();
            return welders;
        }
        public void AddWelder(Welder w)                           // ADD WELDER
        {
            string ConnectionString = @"server = (localdb)\MSSQLLocalDB;
                                       DataBase =WelderDB;
                                       Trusted_Connection=True;
                                       TrustServerCertificate=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            string query = @"INSERT INTO  Welder
                            (WelderID,WelderCode,WelderName,Nationality,JoinningDate,PassportNo,SubContractorID,AgencyID,WelderQualTest)
                            VALUES 
                            (@WelderID,@WelderCode,@WelderName,@Nationality,@JoinningDate,@PassportNo,@SubContractorID,@AgencyID,@WelderQualTest)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@WelderID", w.WelderID);
            cmd.Parameters.AddWithValue("@WelderCode", w.WelderCode);
            cmd.Parameters.AddWithValue("@WelderName", w.WelderName);
            cmd.Parameters.AddWithValue("@Nationality", w.Nationality);
            cmd.Parameters.AddWithValue("@JoinningDate", w.JoinningDate);
            cmd.Parameters.AddWithValue("@PassportNo", w.PassportNo);
            cmd.Parameters.AddWithValue("@SubContractorID", w.SubContractorID);
            cmd.Parameters.AddWithValue("@AgencyID", w.AgencyID);
            cmd.Parameters.AddWithValue("@WelderQualTest", w.WelderQualTest);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public Welder GetWelderByID(int WelderID)                   // GET ID FOR UPDATE WELDER
        {
            Welder w = new Welder();

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;  
                                Database=WelderDB;
                                Trusted_Connection=True;
                                TrustServerCertificate=True;";

            SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM Welder WHERE WelderID=@WelderID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@WelderID",WelderID);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                w.WelderID = Convert.ToInt32(dr["WelderID"]);
                w.WelderCode = dr["WelderCode"].ToString();
                w.WelderName = dr["WelderName"].ToString();
                w.Nationality = dr["Nationality"].ToString();
                w.JoinningDate = Convert.ToDateTime(dr["JoinningDate"]);
                w.PassportNo = dr["PassportNo"].ToString();
                w.SubContractorID = Convert.ToInt32(dr["SubContractorID"]);
                w.AgencyID = Convert.ToInt32(dr["AgencyID"]);
                w.WelderQualTest = dr["WelderQualTest"].ToString();
            }

            con.Close();

            return w;
        }

        public void UpdateWelder(Welder w)                                       //UPDATE WELDER 
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;
                                Database=WelderDB;
                                Trusted_Connection=True;
                                TrustServerCertificate=True;";

            SqlConnection con = new SqlConnection(connectionString);

            string query = @"UPDATE Welder
                     SET WelderCode=@WelderCode,
                         WelderName=@WelderName,
                         Nationality=@Nationality,
                         JoinningDate=@JoinningDate,
                         PassportNo=@PassportNo,
                         SubContractorID=@SubContractorID,
                         AgencyID=@AgencyID,
                         WelderQualTest=@WelderQualTest
                     WHERE WelderID=@WelderID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@WelderID", w.WelderID);
            cmd.Parameters.AddWithValue("@WelderCode", w.WelderCode);
            cmd.Parameters.AddWithValue("@WelderName", w.WelderName);
            cmd.Parameters.AddWithValue("@Nationality", w.Nationality);
            cmd.Parameters.AddWithValue("@JoinningDate", w.JoinningDate);
            cmd.Parameters.AddWithValue("@PassportNo", w.PassportNo);
            cmd.Parameters.AddWithValue("@SubContractorID", w.SubContractorID);  
            cmd.Parameters.AddWithValue("@AgencyID", w.AgencyID);
            cmd.Parameters.AddWithValue("@WelderQualTest", w.WelderQualTest);

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public Welder GetDeleteWelderID(int WelderID)                                       //DELETE WELDER
        {
            Welder w = new Welder();
            string ConnectionString = @"server = (localdb)\MSSQLLocalDB;
                                        DataBase = WelderDB;
                                        Trusted_Connection= True;
                                        TrustServerCertificate= True;";
            SqlConnection con = new SqlConnection(ConnectionString);

            string query = "SELECT *  FROM Welder WHERE WelderID =@WelderID;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@WelderID", WelderID);

            con.Open(); 
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                w.WelderID = Convert.ToInt32(dr["WelderID"]);
                w.WelderCode = dr["WelderCode"].ToString();
                w.WelderName = dr["WelderName"].ToString();
                w.Nationality = dr["Nationality"].ToString(); 
                w.JoinningDate = Convert.ToDateTime(dr["JoinningDate"]);
                w.PassportNo = dr["PassportNo"].ToString();
                w.SubContractorID = Convert.ToInt32(dr["SubContractorID"]);
                w.AgencyID = Convert.ToInt32(dr["AgencyID"]);
                w.WelderQualTest = dr["WelderQualTest"].ToString();
            }
            con.Close();
            return w;
        }
        public void DeleteWelder(Welder w )
        {
            string ConnectionString = @"server = (localdb)\MSSQLLocalDB;
                                       DataBase = WelderDB;
                                       Trusted_Connection= True;
                                       TrustServerCertificate= True;";
            SqlConnection con = new SqlConnection(ConnectionString);    

            string query = @"DELETE FROM Welder WHERE WelderID = @WelderID;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@WelderID", w.WelderID);
            cmd.Parameters.AddWithValue("@WelderCode", w.WelderCode);
            cmd.Parameters.AddWithValue("@WelderName", w.WelderName);
            cmd.Parameters.AddWithValue("@Nationality", w.Nationality);
            cmd.Parameters.AddWithValue("@PassportNo", w.PassportNo);
            cmd.Parameters.AddWithValue("@JoinningDate", w.JoinningDate);
            cmd.Parameters.AddWithValue("@SubContractorID", w.SubContractorID);
            cmd.Parameters.AddWithValue("@AgencyID", w.AgencyID);
            cmd.Parameters.AddWithValue("@WelderQualTest", w.WelderQualTest);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}