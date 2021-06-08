using Fr.EQL.AI109.TPPokemon.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.TPPokemon.DataAccess
{
    public class CategorieDAO : DAO
    {

        public List<Categorie> GetAll()
        {
            List<Categorie> result = new List<Categorie>();

            MySqlCommand cmd = this.CreerCommande();

            cmd.CommandText = "SELECT * FROM categorie";
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                Categorie c = new Categorie();
                c.Id = dr.GetInt32("id");
                c.Libelle = dr.GetString("libelle");
                result.Add(c);
            }
            cmd.Connection.Close();
            return result;
        }

    }
}
