using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace DataAccessLayer
{
    public class Baglanti
    {
        public static SqlConnection bgl = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\erdem\\Desktop\\Görsel Programlama Proje\\HastaneOtomasyon\\HastaneOtomasyonu.mdf\";Integrated Security=True");
    }
}
