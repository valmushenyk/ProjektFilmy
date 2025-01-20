using ProjektFilmy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektFilmy
{
    public class Wypozyczalnia
    {

        public string Nazwa { get; set; }
        public ObservableCollection<Film> WszystkieFilmy { get; set; } = new();
        public ObservableCollection<Film> WypozyczoneFilmy { get; set; } = new();

        public Wypozyczalnia() { }
        public Wypozyczalnia(string nazwa)
        {
            Nazwa = nazwa;
        }

        public void WypozyczFilm(Profil profil, Film film)
        {
            if (profil == null)
            {
                throw new ArgumentNullException(nameof(profil), "Profil nie może być nullem.");
            }

            if (film == null)
            {
                throw new ArgumentNullException(nameof(film), "Film nie może być nullem.");
            }

            // Wyszukaj film w wypożyczalni
            var znalezionyFilm = WyszukajFilm(film.Tytul);
            if (znalezionyFilm != null)
            {
                // Jeśli film istnieje w wypożyczalni, dodaj go do profilu
                profil.Wypozycz(this, film.Tytul);

                WypozyczoneFilmy.Add(znalezionyFilm);  // Dodanie filmu do wypożyczonych filmów
            }
            else
            {
                throw new InvalidOperationException("Film nie został znaleziony w wypożyczalni.");
            }
        }



        public void DodajFilm(Film film)
        {
            // Dodajemy film z powrotem do kolekcji dostępnych filmów w wypożyczalni
            if (film != null && !WszystkieFilmy.Contains(film))
            {
                WszystkieFilmy.Add(film);  // Dodajemy film do listy dostępnych filmów
            }
        }

        public void UsunFilm(Film film)
        {
            WszystkieFilmy.Remove(film);
        }


        public Film? WyszukajFilm(string tytul)
        {
            return WszystkieFilmy.FirstOrDefault(f => f.Tytul == tytul);
        }

        // Funkcja do losowania filmu (zlicza sobie filmy i losuje randomowy int, ktory odpowiada filmowi)
        public Film LosujFilm()
        {
            if (WszystkieFilmy.Count == 0)
            {
                throw new InvalidOperationException("Wypożyczalnia jest pusta.");
            }

            Random rand = new Random();
            // Losuje indeks z listy filmów
            int losowyIndeks = rand.Next(WszystkieFilmy.Count);
            return WszystkieFilmy[losowyIndeks];
        }

        public void WyswietlWszystkieFilmy()
        {
            Console.WriteLine($"Filmy dostępne w wypożyczalni \"{Nazwa}\":");
            foreach (var film in WszystkieFilmy)
            {
                Console.WriteLine(film);
            }
        }
        public void ZapiszXml1(string nazwaPliku)
        {
            using StreamWriter sw = new(nazwaPliku);
            XmlSerializer xs = new(typeof(Wypozyczalnia));
            xs.Serialize(sw, this);
        }

        public static Wypozyczalnia? OdczytXml1(string nazwaPliku)
        {
            if (!File.Exists(nazwaPliku)) { return null; }
            using StreamReader sr = new(nazwaPliku);
            XmlSerializer xs = new(typeof(Wypozyczalnia));
            return xs.Deserialize(sr) as Wypozyczalnia;
        }
    }
}


