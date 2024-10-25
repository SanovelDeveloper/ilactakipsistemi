using Functions;
using System.Configuration;

namespace DeclarationServices
{
    public class WSConnectionString
    {
       
        public WSConnectionString() {
           
        }
        public string GetTest(string testparam)
        {
            return $"{testparam}: test işlemi başarılı";
        }
        public string GetConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DeclarationServices.Properties.Settings.ITSConnectionString"].ConnectionString;

            return connectionString;
        }
    }
}
