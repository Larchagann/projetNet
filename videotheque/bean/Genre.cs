using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotheque.bean
{
    public class Genre
    {
        private int id;
        private string libelle;

        public Genre(int id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => id; set => id = value; }

        public string Libelle { get => libelle; set => libelle = value; }

        [InverseProperty(nameof(MediaGenre.Genre))]
        public List<MediaGenre> ListMediaGenre { get; set; }
    }
}
