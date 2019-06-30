using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace videotheque.Views
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class Accueil : INotifyPropertyChanged
    {
        public Accueil()
        {
            DataContext = this;
            InitializeComponent();
        }

        //Pour page des stats en cours des films
        private Page _pageStatFilmEnCours;
        public Page PageStatFilmEnCours
        {
            get { return _pageStatFilmEnCours; }
            set
            {
                if (_pageStatFilmEnCours != value)
                {
                    _pageStatFilmEnCours = value;
                    OnPropertyChanged();
                }
            }
        }

        //Pour page des stats en cours des séries
        private Page _pageStatSerieEnCours;
        public Page PageStatSerieEnCours
        {
            get { return _pageStatSerieEnCours; }
            set
            {
                if (_pageStatSerieEnCours != value)
                {
                    _pageStatSerieEnCours = value;
                    OnPropertyChanged();
                }
            }
        }


        //PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //Evenements
        private void CmbSelectFiltreFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PageStatFilmEnCours = new statsFilmParGenre();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void CmbSelectFiltreSerie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PageStatSerieEnCours = new statsSerieParGenre();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }
    }
}
