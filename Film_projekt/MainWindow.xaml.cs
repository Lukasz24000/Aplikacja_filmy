using System;
using System.Collections.Generic;
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

namespace Film_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Repository _repository;
        public Film _film;
        public MainWindow()
        {
            InitializeComponent();
            _repository = new Repository();
            _film = new Film();
            InitList();
        }

        public void InitList()
        {
            var list = _repository.GetFilmList();
            
            for (int i = 0; i < list.Count; i++)
            {
                Film Movie = new Film();
                Movie = list[i];
                string MovieTytul = Movie.Tytul.ToString();
                cbFilm.Items.Add(MovieTytul);
            }
        }
        private void btDodajFilm_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtTytul.Text) || string.IsNullOrEmpty(txtRok.Text) )
            {
                return;
            }
            _repository.AddMovie(new Film()
            {

                Tytul = txtTytul.Text,
                RezyserId = Convert.ToInt32(txtRezyserId.Text),
                Rok = Convert.ToInt32(txtRok.Text),
                AktorzyId = txtAktorzyId.Text,

            });
        }

        private void btDodajRezysera_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtImieRezysera.Text) || string.IsNullOrEmpty(txtNazwiskoRezysera.Text))
            {
                return;
            }

            _repository.AddDirector(new Rezyser()
            {
                Imie = txtImieRezysera.Text,
                Nazwisko = txtNazwiskoRezysera.Text,
            });
        }

        private void btDodajAktora_Click(object sender, RoutedEventArgs e)
        {
            if ( string.IsNullOrEmpty(txtImieAktora.Text) || string.IsNullOrEmpty(txtNazwiskoAktora.Text))
            {
                return;
            }

            _repository.AddActor(new Aktor()
            {
                Imie = txtImieAktora.Text,
                Nazwisko = txtNazwiskoAktora.Text,
            });
        }

        private void cbFilm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listAktorImie.Items.Clear();
            listAktorNazwisko.Items.Clear();
            string Wybor = cbFilm.SelectedItem.ToString();
            var Movie = _repository.GetFilm(Wybor);
            Rezyser Director = _repository.GetDirector(Movie.RezyserId.ToString());
            List<int> IdAktorow = Movie.AktorzyId.Split(',').Select(int.Parse).ToList();
            for (int i = 0; i < IdAktorow.Count; i++)
            {
                Aktor actor = _repository.GetActor(IdAktorow[i].ToString());
                listAktorImie.Items.Add(actor.Imie);
                listAktorNazwisko.Items.Add(actor.Nazwisko);

            }

                txtTytul1.Content = Movie.Tytul;
            txtRok1.Content = Movie.Rok;
            txtRezyserImie.Content = Director.Imie;
            txtRezyserNazwisko.Content = Director.Nazwisko;

        }
    }
}
