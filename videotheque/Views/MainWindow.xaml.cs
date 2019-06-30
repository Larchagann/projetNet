using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using videotheque.Views;
using System.Runtime.CompilerServices;

namespace videotheque
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            PageEnCours = new Accueil();
        }

        //Pour page des stats en cours des séries
        private Page _pageEnCours;
        public Page PageEnCours
        {
            get { return _pageEnCours; }
            set
            {
                if (_pageEnCours != value)
                {
                    _pageEnCours = value;
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
        private void BoutonVoirFilmSerie_Click(object sender, RoutedEventArgs e)
        {
            PageEnCours = new FilmsEtSeries();
            boutonVoirFilmSerie.Visibility = Visibility.Hidden;
        }
    }
}
