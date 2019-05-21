using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotheque.bean
{
    public class Episode
    {
        private int id;
        private int idMedia;
        private int numSaison;
        private int numEpisode;
        private TimeSpan duree;
        private string titre;
        private string description;
        private DateTime dateDiffusion;

        public Episode(int id, int idMedia, int numSaison, int numEpisode, TimeSpan duree, 
            string titre, string description, DateTime dateDiffusion)
        {
            this.id = id;
            this.idMedia = idMedia;
            this.numSaison = numSaison;
            this.numEpisode = numEpisode;
            this.duree = duree;
            this.titre = titre;
            this.description = description;
            this.dateDiffusion = dateDiffusion;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => id; set => id = value; }

        public int IdMedia { get => idMedia; set => idMedia = value; }

        public int NumSaison { get => numSaison; set => numSaison = value; }

        public int NumEpisode { get => numEpisode; set => numEpisode = value; }

        public TimeSpan Duree { get => duree; set => duree = value; }

        public string Titre { get => titre; set => titre = value; }

        public string Description { get => description; set => description = value; }

        public DateTime DateDiffusion { get => dateDiffusion; set => dateDiffusion = value; }

        [ForeignKey(nameof(IdMedia))]
        public Media Media { get; set; }
    }
}
