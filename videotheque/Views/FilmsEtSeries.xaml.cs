using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using videotheque.bean;
using videotheque.ViewModels;

namespace videotheque.Views
{
    /// <summary>
    /// Logique d'interaction pour FilmsEtSeries.xaml
    /// </summary>
    public partial class FilmsEtSeries : INotifyPropertyChanged
    {
        public FilmsEtSeries()
        {
            DataContext = this;
            InitializeComponent();
            ListeFilmsEtSeries = new ObservableCollection<Genre>(AjoutMedia.GetAjoutMedia().GetGenre());
        }


        //Pour page des stats en cours des séries
        private ObservableCollection<Genre> _listeFilmsEtSeries;
        public ObservableCollection<Genre> ListeFilmsEtSeries
        {
            get { return _listeFilmsEtSeries; }
            set
            {
                if (_listeFilmsEtSeries != value)
                {
                    _listeFilmsEtSeries = value;
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

    }
}
