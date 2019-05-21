using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotheque.bean
{
    public class Media
    {
        private int id;
        private int note;
        private int ageMinimum;
        private string titre;
        private string commentaire;
        private string synopsis;
        private string image;
        private Boolean vu;
        private Boolean supportPhysique;
        private Boolean supportNumerique;
        private enum type { Film, Série };
        private enum langueVo { Anglais, Français, Japonais, Allemand };
        private enum langueMedia { Anglais, Français, Japonais, Allemand };
        private enum sousTitres { Anglais, Français, Japonais, Allemand };
        private TimeSpan duree;
        private DateTime dateSortie;


        public Media(int id, int note, int ageMinimum, string titre, string commentaire, 
            string synopsis, string image, bool vu, bool supportPhysique, 
            bool supportNumerique, TimeSpan duree, DateTime dateSortie)
        {
            this.id = id;
            this.note = note;
            this.ageMinimum = ageMinimum;
            this.titre = titre;
            this.commentaire = commentaire;
            this.synopsis = synopsis;
            this.image = image;
            this.vu = vu;
            this.supportPhysique = supportPhysique;
            this.supportNumerique = supportNumerique;
            this.duree = duree;
            this.dateSortie = dateSortie;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => id; set => id = value; }

        public int Note { get => note; set => note = value; }

        public int AgeMinimum { get => ageMinimum; set => ageMinimum = value; }

        public string Titre { get => titre; set => titre = value; }

        public string Commentaire { get => commentaire; set => commentaire = value; }

        public string Synopsis { get => synopsis; set => synopsis = value; }

        public string Image { get => image; set => image = value; }

        public bool Vu { get => vu; set => vu = value; }

        public bool SupportPhysique { get => supportPhysique; set => supportPhysique = value; }

        public bool SupportNumerique { get => supportNumerique; set => supportNumerique = value; }

        public TimeSpan Duree { get => duree; set => duree = value; }

        public DateTime DateSortie { get => dateSortie; set => dateSortie = value; }

    }
}
