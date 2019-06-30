using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videotheque.bean;
using videotheque.dataAccess;

namespace videotheque.ViewModels
{
    class GestionMedia
    {

        private static GestionMedia _instance;
        private VideothequeDbContext context;
        public GestionMedia()
        {
            getContext();
            addGenre();
            addMedia();
            addMediaGenre();
        }

        private async void getContext()
        {
            context = await dataAccess.VideothequeDbContext.GetCurrent();
        }

        public static GestionMedia GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GestionMedia();
            }
            return _instance;
        }

        public async void addGenre()
        {
            var gen1 = context.Genres.SingleOrDefault(f => f.Id == 1);
            if (gen1 == null)
            {
                Genre g1 = new Genre(1, "Action");
                context.Genres.Add(g1);
            }
            var gen2 = context.Genres.SingleOrDefault(f => f.Id == 2);
            if (gen2 == null)
            {
                Genre g2 = new Genre(2, "Comédie");
                context.Genres.Add(g2);
            }
            var gen3 = context.Genres.SingleOrDefault(f => f.Id == 3);
            if (gen3 == null)
            {
                Genre g3 = new Genre(3, "Animé");
                context.Genres.Add(g3);
            }
            await context.SaveChangesAsync();
        }


        public async void addMedia()
        {
            var med1 = context.Media.SingleOrDefault(f => f.Id == 3);
            if (med1 == null)
            {
                context.Media.Add(new Media(1, 14, 12, "Jhon Wick", "", "", "", true, false, true, new TimeSpan(), new DateTime(2014, 10, 29)));
            }
            var med2 = context.Media.SingleOrDefault(f => f.Id == 3);
            if (med2 == null)
            {
                context.Media.Add(new Media(2, 10, 3, "Le roi lion", "", "", "", false, false, true, new TimeSpan(), new DateTime(2001, 12, 5)));
            }
            var med3 = context.Media.SingleOrDefault(f => f.Id == 3);
            if (med3 == null)
            {
                context.Media.Add(new Media(3, 14, 12, "Camping Paradis", "", "", "", false, true, true, new TimeSpan(), new DateTime(2006, 11, 21)));
            }
            await context.SaveChangesAsync();
        }

        public async void addMediaGenre()
        {
            var mg1 = context.MediaGenre.SingleOrDefault(f => f.IdMedia == 1 );
            if (mg1 == null)
            {
                context.Add(new MediaGenre(1, 1));
            }
            var mg2 = context.MediaGenre.SingleOrDefault(f => f.IdMedia == 2);
            if (mg2 == null)
            {
                context.Add(new MediaGenre(3, 2));
            }
            var mg3 = context.MediaGenre.SingleOrDefault(f => f.IdMedia == 3);
            if (mg3 == null)
            {
                context.Add(new MediaGenre(2, 3));
            }
            await context.SaveChangesAsync();
        }





        public List<Media> GetMedia()
        {
            return context.Media.ToList();
        }

        public List<Media> GetMediaAction()
        {
            return context.Media.Where((g) => g.Titre.Equals("Jhon Wick")).ToList();
        }

        public List<Media> GetMediaComedie()
        {
            return context.Media.Where((g) => g.Titre.Equals("Camping Paradis")).ToList();
        }

        public List<Media> GetMediaAnime()
        {
            return context.Media.Where((g) => g.Titre.Equals("Le roi lion")).ToList();
        }
    }
}
