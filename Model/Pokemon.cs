using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fr.EQL.AI109.TPPokemon.Model
{
    public class Pokemon
    {
        #region CONSTANTES
        public const float TAILLE_MAX = 2.36f;
        #endregion

        #region PROPERTIES
        private int id;
        public string Nom { get; set; } // Property abrégée
        public float? Taille { get; set; }
        public DateTime? DateCreation { get; set; }

        // PROPERTIES (=getter/setter) :
        public int Id
        {
            get { return this.id; }
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Id incorrect");
                }
                else
                {
                    this.id = value;
                }
            }
        }
        #endregion

        #region CONSTRUCTORS
        public Pokemon()
        {
        }

        public Pokemon(string nom, float taille, DateTime dateCreation, int id)
        {
            Nom = nom;
            Taille = taille;
            DateCreation = dateCreation;
            Id = id;
        }
        #endregion

    }
}
