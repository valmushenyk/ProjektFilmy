using ProjektFilmy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjektFilmyWPF
{
    public partial class TwojeFilmyWindow : Window
    {
        public Profil profil;
        private Wypozyczalnia wypozyczalnia;

        // Konstruktor
        public TwojeFilmyWindow(Wypozyczalnia wypozyczalnia, Profil profil)
        {
            InitializeComponent();
            this.profil = profil;
            this.wypozyczalnia = wypozyczalnia;
            txtNazwaUzytkownika.Text = profil.IdUzytkownika;

            ButtonOdswiez_Click(null, null);

        }


        private void OdswiezListeFilmow()
        {
            ListBoxWypozyczone.Items.Clear();

            if (profil?.wypozyczone != null && profil.wypozyczone.Count > 0)
            {
                foreach (var film in profil.wypozyczone.Values)
                {
                    ListBoxWypozyczone.Items.Add($"{film.film.Tytul} ");

                }
            }
            else
            {
                MessageBox.Show("Brak wypożyczonych filmów.");
            }
        }

        private void ButtonOdswiez_Click(object sender, RoutedEventArgs e)
        {
            // Czyści ListBox
            ListBoxWypozyczone.Items.Clear();

            // Dodaje wypożyczone filmy do ListBox
            foreach (var wypozyczonyFilm in profil.wypozyczone.Values)
            {
                ListBoxWypozyczone.Items.Add(wypozyczonyFilm.film.Tytul);
            }
        }
        private void ButtonSprawdzTermin_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxWypozyczone.SelectedItem is string tytulFilmu)
            {
                // Sprawdzamy termin zwrotu filmu
                var termin = profil.GetTerminOddania(tytulFilmu);

                if (termin.HasValue)
                {
                    // Jeśli film jest wypożyczony, pokazujemy datę zwrotu
                    MessageBox.Show($"Film \"{tytulFilmu}\" należy oddać do {termin.Value.ToShortDateString()}.");
                }
                else
                {
                    // Jeśli film nie jest wypożyczony, informujemy użytkownika
                    MessageBox.Show("Film nie jest wypożyczony.");
                }
            }
            else
            {
                // Jeśli nie wybrano filmu z listy
                MessageBox.Show("Proszę wybrać film z listy wypożyczonych.");
            }
        }
        private void ButtonPrzedluz_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxWypozyczone.SelectedItem is string tytulFilmu)
            {
                try
                {
                    // Zapytanie użytkownika o liczbę dni
                    string dniPrzedluzeniaString = Microsoft.VisualBasic.Interaction.InputBox("Podaj liczbę dni, o jakie chcesz przedłużyć wypożyczenie:", "Przedłuż wypożyczenie", "7");
                    int dniPrzedluzenia = int.Parse(dniPrzedluzeniaString);  // Parsowanie wartości

                    // Wywołanie metody przedłużenia wypożyczenia w profilu
                    profil.PrzedluzWaznosc(tytulFilmu, dniPrzedluzenia);

                    // Powiadomienie użytkownika o sukcesie
                    MessageBox.Show($"Wypożyczenie filmu \"{tytulFilmu}\" zostało przedłużone o {dniPrzedluzenia} dni.");

                    // Odświeżenie listy wypożyczonych filmów
                    ButtonOdswiez_Click(null, null);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Proszę podać poprawną liczbę dni.");
                }
                catch (Exception ex)
                {
                    // Obsługa innych błędów
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Proszę wybrać film z listy wypożyczonych.");
            }
        }


        private void ButtonOddaj_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxWypozyczone.SelectedItem is string selectedFilmTitle)
            {

                profil.Oddaj(wypozyczalnia, selectedFilmTitle);
                MessageBox.Show($"Film '{selectedFilmTitle}' został zwrócony.");
                OdswiezListeFilmow();

            }
            else
            {
                MessageBox.Show("Proszę wybrać film z listy.");
            }

        }
        private void btnMovieList_Click(object sender, RoutedEventArgs e)
        {
            PrzegladajFilmyWindow przegladajFilmyWindow = new PrzegladajFilmyWindow(wypozyczalnia, profil);
            przegladajFilmyWindow.Show();
            this.Close();

        }
    }
}
