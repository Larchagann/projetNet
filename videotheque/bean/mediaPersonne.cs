using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotheque.bean
{
    public class MediaPersonne
    {
        private int id;
        private int idPersonne;
        private int idMedia;
        private enum fonction { acteur, directeur, realisateur, producteur, musique };
        private string role;
        private string photo;


        public MediaPersonne(int id, int idPersonne, int idMedia, string role, string photo)
        {
            this.id = id;
            this.idPersonne = idPersonne;
            this.idMedia = idMedia;
            this.role = role;
            this.photo = photo;
        }

        public int Id { get => id; set => id = value; }
        public int IdPersonne { get => idPersonne; set => idPersonne = value; }
        public int IdMedia { get => idMedia; set => idMedia = value; }
        public string Role { get => role; set => role = value; }
        public string Photo { get => photo; set => photo = value; }

        [ForeignKey(nameof(IdMedia))]
        public Media Media { get; set; }
        [ForeignKey(nameof(IdPersonne))]
        public Personne Personne { get; set; }
    }
}
