
using System.Data.SqlClient;

namespace DATAACCESS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connexion = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=ApprendreCsharp;Integrated Security=True;");

            try
            {
                connexion.Open();
                Console.WriteLine("Connexion reussie!");

                Console.WriteLine("Votre nom: ");
                string? nom=Console.ReadLine();

                Console.WriteLine("Votre prenom: ");
                string? prenom=Console.ReadLine();

                SqlCommand sqlCommand = connexion.CreateCommand();
                sqlCommand.CommandText = $"INSERT INTO Personnes(Nom, Prenom) VALUES (@Nom,@Prenom)";

                SqlParameter nomParam= new SqlParameter();
                nomParam.DbType = System.Data.DbType.String;
                nomParam.ParameterName = "@Nom";
                nomParam.Value = nom;
                sqlCommand.Parameters.Add(nomParam);

                SqlParameter prenomParam= new SqlParameter();
                prenomParam.DbType=System.Data.DbType.String;
                prenomParam.ParameterName = "@Prenom";
                prenomParam.Value= prenom;
                sqlCommand.Parameters.Add (prenomParam);

                int resultat=sqlCommand.ExecuteNonQuery();

                if (resultat>0)
                {
                    Console.WriteLine("Insertion effectuée avec succes!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connexion.Close();
            }

        }
    }
}
