using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotheque.bean
{
    public class Personne
    {
        private int id;
        private enum civilite { Monsieur, Madame};
        private string nom;
        private string prenom;
        private string nationalite;
        private string photo;
        private DateTime dateNaissance;


        public Personne(int id, string nom, string prenom, string nationalite, string photo, DateTime dateNaissance)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.nationalite = nationalite;
            this.photo = photo;
            this.dateNaissance = dateNaissance;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => id; set => id = value; }

        public string Nom { get => nom; set => nom = value; }

        public string Prenom { get => prenom; set => prenom = value; }

        public string Nationalite { get => nationalite; set => nationalite = value; }

        public string Photo { get => photo; set => photo = value; }

        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
    }
}
