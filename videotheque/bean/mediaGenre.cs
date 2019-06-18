using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotheque.bean
{
    public class MediaGenre
    {
        private int idGenre;
        private int idMedia;

        public MediaGenre(int idGenre, int idMedia)
        {
            this.idGenre = idGenre;
            this.idMedia = idMedia;
        }

        public int IdGenre { get => idGenre; set => idGenre = value; }
        public int IdMedia { get => idMedia; set => idMedia = value; }

        [ForeignKey(nameof(IdGenre))]
        public Genre Genre { get; set; }
        [ForeignKey(nameof(IdMedia))]
        public Media Media { get; set; }
    }
}
