using ProjektFilmy;
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
using System.Windows.Shapes;
#nullable disable
namespace ProjektFilmyWPF
{
    public partial class PrzegladajFilmyWindow : Window
    {
        private Wypozyczalnia wypozyczalnia;
        private Profil profil;

        public PrzegladajFilmyWindow(Wypozyczalnia wypozyczalnia, Profil profil)
        {
            InitializeComponent();
            this.wypozyczalnia = wypozyczalnia;
            this.profil = profil;
            ButtonOdswiez_Click(null, null);
        }

        private void ButtonWyszukaj_Click(object sender, RoutedEventArgs e)
        {
            string tytul = Microsoft.VisualBasic.Interaction.InputBox("Podaj tytuł filmu:", "Wyszukaj Film");
            Film film = wypozyczalnia.WyszukajFilm(tytul);
            ListBoxFilmy.Items.Clear();
            if (film != null)
            {
                ListBoxFilmy.Items.Add(film);
            }
            else
            {
                MessageBox.Show("Nie znaleziono filmu.");
            }
        }

        private void ButtonWyswietlWszystkie_Click(object sender, RoutedEventArgs e)
        {
            ListBoxFilmy.Items.Clear();
            // Sprawdzenie, czy wypożyczalnia jest dostępna
            if (wypozyczalnia != null && wypozyczalnia.WszystkieFilmy.Count > 0)
            {
                foreach (var film in wypozyczalnia.WszystkieFilmy)
                {
                    ListBoxFilmy.Items.Add(film);  // Dodanie filmu do ListBoxa
                }
            }
            else
            {
                MessageBox.Show("Brak filmów do wyświetlenia.");
            }
        }


        private void ButtonLosuj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Losowanie filmu z wypożyczalni
                Film losowanyFilm = wypozyczalnia.LosujFilm();

                // Wyświetlenie okna dialogowego z informacjami o wylosowanym filmie
                string message = $"Wylosowany film: {losowanyFilm.Tytul}\n" +
                                 $"Reżyser: {losowanyFilm.Rezyser}\n" +
                                 $"Rok wydania: {losowanyFilm.DataWydania}\n\n" +
                                 "Czy chcesz wypożyczyć ten film?";

                MessageBoxResult result = MessageBox.Show(message, "Wypożyczenie filmu", MessageBoxButton.YesNo);

                // Jeśli użytkownik zdecyduje się wypożyczyć film, dodajemy go do jego profilu
                if (result == MessageBoxResult.Yes)
                {
                    profil.Wypozycz(wypozyczalnia, losowanyFilm.Tytul);
                    MessageBox.Show($"Film \"{losowanyFilm.Tytul}\" został wypożyczony.");
                }
                else
                {
                    MessageBox.Show("Nie wypożyczyłeś filmu.");
                }
            }
            catch (InvalidOperationException)
            {
                // Obsługa przypadku, gdy wypożyczalnia jest pusta
                MessageBox.Show("Wypożyczalnia jest pusta. Nie można wylosować filmu.");
            }
        }

        private void ButtonWypozycz_Click(object sender, RoutedEventArgs e)
        {
            // Sprawdź, czy użytkownik wybrał film z listy
            if (ListBoxFilmy.SelectedItem is Film zaznaczonyFilm)
            {
                try
                {
                    // Wywołanie metody Wypozycz na obiekcie Profil
                    profil.Wypozycz(wypozyczalnia, zaznaczonyFilm.Tytul);

                    // Wyświetlenie komunikatu informującego o sukcesie
                    MessageBox.Show($"Film \"{zaznaczonyFilm.Tytul}\" został wypożyczony przez użytkownika {profil.IdUzytkownika}.");

                    // Odświeżenie listy wypożyczonych filmów
                    ButtonOdswiez_Click(null, null); // Wywołanie metody odświeżającej listę
                }
                catch (Exception ex)
                {
                    // Obsługa wyjątków
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                }
            }
            else
            {
                // Jeśli nie wybrano żadnego filmu, wyświetl komunikat
                MessageBox.Show("Proszę zaznaczyć film, który chcesz wypożyczyć.");
            }
        }


        private void ButtonOdswiez_Click(object sender, RoutedEventArgs e)
        {
            ListBoxFilmy.Items.Clear();

            // Dodajemy dostępne filmy
            foreach (var film in wypozyczalnia.WszystkieFilmy)
            {
                ListBoxFilmy.Items.Add(film);
            }
        }
        private void ButtonOdswiez1_Click(object sender, RoutedEventArgs e)
        {
            // Odświeżamy listy filmów na ekranie
            ListBoxFilmy.Items.Clear();

            // Dodajemy dostępne filmy
            foreach (var film in wypozyczalnia.WszystkieFilmy)
            {
                ListBoxFilmy.Items.Add(film);
            }



        }
        private void btnUserProfile_Click(object sender, RoutedEventArgs e)
        {
            TwojeFilmyWindow twojeFilmyWindow = new TwojeFilmyWindow(wypozyczalnia, profil);
            twojeFilmyWindow.Show();

        }
    }
}
