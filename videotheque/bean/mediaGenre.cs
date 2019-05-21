using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotheque.bean
{
    public class mediaGenre
    {
        private int idGenre;
        private int idMedia;

        public mediaGenre(int idGenre, int idMedia)
        {
            this.idGenre = idGenre;
            this.idMedia = idMedia;
        }

        public int IdGenre { get => idGenre; set => idGenre = value; }
        public int IdMedia { get => idMedia; set => idMedia = value; }
    }
}
