using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videotheque.bean;
using videotheque.dataAccess;

namespace videotheque.ViewModels
{
    class AjoutMedia
    {

        private static AjoutMedia _instance;
        private VideothequeDbContext context;
        public AjoutMedia()
        {
            getInstance();
            //addMedia();
        }

        private async void getInstance()
        {
            context = await dataAccess.VideothequeDbContext.GetCurrent();
        }

        public static AjoutMedia GetAjoutMedia()
        {
            if (_instance == null)
            {
                _instance = new AjoutMedia();
            }
            return _instance;
        }

        public async void addMedia()
        {
            Genre g = new Genre(1, "Action");
            context.Genres.Add(g);
            await context.SaveChangesAsync();
        }

        public List<Genre> GetGenre()
        {
            return context.Genres.OrderBy(g => g.Libelle).ToList();
        }

    }
}
