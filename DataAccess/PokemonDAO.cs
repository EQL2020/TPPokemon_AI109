using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fr.EQL.AI109.TPPokemon.Model;
using MySql.Data.MySqlClient;

namespace Fr.EQL.AI109.TPPokemon.DataAccess
{
    public class PokemonDAO : DAO
    {
        public void Create(Pokemon p)
        {
            #region exemple injection sql
            // INJECTION SQL :
            // p.Nom >> plop', 3.89, '2000-01-01'); DELETE FROM pokemon; --
            //INSERT INTO pokemon (nom, taille, date_creation) values ('plop', 3.89, '2000-01-01'); DROP TABLE pokemon; --', 1.23, '2020-05-27')

            // p.Nom >> pikachu
            //INSERT INTO pokemon (nom, taille, date_creation)                  values ('   pikachu   ',      1.23      , '       2020-05-27')
            //cmd.CommandText = "INSERT INTO pokemon (nom, taille, date_creation) values ('" + p.Nom + "'," + p.Taille + ", '" + p.DateCreation.Year + "-" + p.DateCreation.Month + "-" + p.DateCreation.Day + "')";
            #endregion

            MySqlCommand cmd = CreerCommande();
            
            #region configuration de la commande
            cmd.CommandText = "INSERT INTO pokemon (nom, taille, date_creation, id_categorie) values (@nom, @taille, @dateCreation, @idCategorie)";
            cmd.Parameters.Add(new MySqlParameter("@nom", p.Nom));
            cmd.Parameters.Add(new MySqlParameter("@taille", p.Taille));
            cmd.Parameters.Add(new MySqlParameter("@dateCreation", p.DateCreation));
            cmd.Parameters.Add(new MySqlParameter("@idCategorie", p.IdCategorie));
            #endregion

            cmd.Connection.Open();
            cmd.ExecuteNonQuery(); // pour les commandes INSERT, UPDATE et DELETE
            cmd.Connection.Close();
        }

        public List<Pokemon> GetAll()
        {
            List<Pokemon> result = new List<Pokemon>();

            MySqlCommand cmd = CreerCommande();
            
            cmd.CommandText = "SELECT * FROM pokemon";
            
            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader(); 

            while(dr.Read())
            {
                Pokemon p = DataReaderToPokemon(dr);

                result.Add(p);
            }

            cmd.Connection.Close();

            return result;
        }

        public List<Pokemon> GetByIdDresseur(int idDresseur)
        {
            // SELECT * FROM pokemon where id_dresseur = @idDresseur
            return null;
        }

        public Pokemon GetById(int id)
        {
            Pokemon result = null;

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT * 
                                FROM pokemon 
                                WHERE id = @id";

            cmd.Parameters.Add(new MySqlParameter("@id", id));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                result = DataReaderToPokemon(dr);
            }

            cmd.Connection.Close();

            return result;
        }

        public List<Pokemon> GetByDateCreationMinimum(DateTime dateMinimum)
        {
            List<Pokemon> result = new List<Pokemon>();

            MySqlCommand cmd = CreerCommande();

            cmd.CommandText = @"SELECT * FROM pokemon
                                WHERE date_creation > @dateMin";

            cmd.Parameters.Add(new MySqlParameter("@dateMin", dateMinimum));

            cmd.Connection.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Pokemon p = DataReaderToPokemon(dr);

                result.Add(p);
            }

            cmd.Connection.Close();

            return result;
        }


        private Pokemon DataReaderToPokemon(MySqlDataReader dr)
        {
            Pokemon result = new Pokemon();

            result.Id = dr.GetInt32("id");
            result.Nom = dr.GetString("nom");
            result.Taille = dr.GetFloat("taille");
            if (!dr.IsDBNull(dr.GetOrdinal("date_creation")))
            {
                result.DateCreation = dr.GetDateTime("date_creation");
            }

            if (!dr.IsDBNull(dr.GetOrdinal("id_dresseur")))
            {
                result.IdDresseur = dr.GetInt32("id_dresseur");
            }

            if (!dr.IsDBNull(dr.GetOrdinal("id_categorie")))
            {
                result.IdCategorie = dr.GetInt32("id_categorie");
            }

            return result;
        }

    }
}
