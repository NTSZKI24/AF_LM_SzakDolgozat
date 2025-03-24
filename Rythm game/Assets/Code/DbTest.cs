using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_LM
{
    internal class DbTest
    {
        static void Main(string[] args)
        {
            MySqlConnection conn = new MySqlConnection {ConnectionString= "server=localhost;port=3306;database=rythmn;uid=root;password=;" };
            conn.Open();
            var DbU = new DbUser(conn);

            var PostUser = DbU.Post(new UserPostModel //Új adat felvitele, Email, name, password, score -> passwordből lesz titkosított hash és salt
            {
                Email = "Placeholder",
                Name = "Placeholder",
                Password = "Placeholder",
                Score = 300
            });
            Console.WriteLine(PostUser);

            var Get1User = DbU.Get1(1); //adott Idjű elemet visszaadja
            if(Get1User != null) Console.WriteLine(Get1User.Name);

            var Users = DbU.Get(); //visszaadja az összes elemet
            foreach (var user in Users) 
            {
                Console.WriteLine(user.Name);
            }

            //DbU.Delete(); //kitörli az adott Id-jű elemet

            DbU.Update(1,new UserPostModel() //Id alapján frissíti az adatait az adott felhasználónak
            {
                Email= "Placeholder",
                Name= "Placeholder",
                Password= "Placeholder",
                Score=3
            });

            if (DbU.Authenticate("Placeholder", "Placeholder")) //Vizsgálja hogy megeggyeznek-e a belépési adatok
            {
                Console.WriteLine("Sikeres belépés!");
            }
            else
            {
                Console.WriteLine("Sikertelen belépés!");
            }
            Console.ReadKey();
        }
    }
}
