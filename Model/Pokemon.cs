using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace des annotations de validation de modèle :
using System.ComponentModel.DataAnnotations;

namespace Fr.EQL.AI109.TPPokemon.Model
{
    public class PokemonDateCreationAttribute : RangeAttribute
    {
        // Définition d'un Attribute personnalisé :
        public PokemonDateCreationAttribute()
          : base(typeof(DateTime),
                  DateTime.Now.AddMonths(-6).ToShortDateString(),
                  DateTime.Now.AddMonths(3).ToShortDateString())
        {
            ErrorMessage = string.Format("La date de création doit être comprise entre le {0} et le {1}",
                    DateTime.Now.AddMonths(-6).ToShortDateString(),
                  DateTime.Now.AddMonths(3).ToShortDateString());
        }
    }

    public class Pokemon
    {
        #region CONSTANTES
        public const float TAILLE_MIN = 0.1f;
        public const float TAILLE_MAX = 2.36f;

        #endregion

        #region PROPERTIES
        
        public int? Id { get; set; }

        [Required(ErrorMessage = "Vous devez donner un nom")] // obligatoire
        [MinLength(3, ErrorMessage = "Le nom doit faire au moins 3 caractères")] // au moins 3 caractères
        [RegularExpression("^[A-Z][a-z]{2}[a-z]*$", 
                ErrorMessage = "Le nom doit commencer par une Majuscule et ne contenir que des lettres")]
        public string Nom { get; set; } // Property abrégée
        
        [Required(ErrorMessage = "Taille obligatoire")]
        [Range(TAILLE_MIN, TAILLE_MAX, 
                ErrorMessage = "Taille en dehors des limites")] // compris entre min et max
        public float? Taille { get; set; }

        // Utilisation de l'attribute personnalisé :
        [PokemonDateCreation]
        public DateTime? DateCreation { get; set; }

        public int? IdDresseur { get; set; }

        public int? IdCategorie { get; set; }

        public List<Pouvoir> Pouvoirs { get; set; }

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


/*

public class A
{
    public A(string s) {
        ...    
    }
}

public class B : A
{
    public B() 
        : base("toto") // appel au constructeur de A
    {
        
    }

}    
 */