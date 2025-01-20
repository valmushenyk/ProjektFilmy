using ProjektFilmy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektFilmy
{

    // tworzymu klase, by zserializowac slownik
    public class WypozyczoneFilmEntry
    {
        [XmlElement("Tytul")]
        public string Tytul { get; set; }

        [XmlElement("Film")]
        public Film Film { get; set; }

        [XmlElement("DataWypozyczenia")]
        public DateTime DataWypozyczenia { get; set; }

        [XmlElement("KiedyOddac")]
        public DateTime KiedyOddac { get; set; }

        public WypozyczoneFilmEntry() { }

        public WypozyczoneFilmEntry(string tytul, Film film, DateTime dataWypozyczenia, DateTime kiedyOddac)
        {
            Tytul = tytul;
            Film = film;
            DataWypozyczenia = dataWypozyczenia;
            KiedyOddac = kiedyOddac;
        }
    }
    [XmlRoot("Profil")]  // Make the class serializable

    public class Profil
    {
        [XmlElement("IdUzytkownika")]
        public string IdUzytkownika { get; set; }

        [XmlIgnore]
        public DateTime kiedyOddac { get; set; }

        // tworzymy liste zserializowanego slownika
        [XmlArray("WypozyczoneFilmy")]
        [XmlArrayItem("WypozyczonyFilm")]
        public List<WypozyczoneFilmEntry> WypozyczoneList
        {
            get => wypozyczone.Select(entry => new WypozyczoneFilmEntry(entry.Key, entry.Value.film, entry.Value.dataWypozyczenia, entry.Value.film.DataOddania)).ToList();
            set => wypozyczone = value.ToDictionary(entry => entry.Tytul, entry => (entry.Film, entry.DataWypozyczenia));
        }

        [XmlIgnore]

        public Dictionary<string, (Film film, DateTime dataWypozyczenia)> wypozyczone;

        public Profil() { }
        public Profil(string IdUzytkownika)
        {
            this.IdUzytkownika = IdUzytkownika;
            wypozyczone = new();
        }

        public void Wypozycz(Wypozyczalnia wypozyczalnia, string tytul)
        {
            var f = wypozyczalnia.WyszukajFilm(tytul);  // Wyszukaj film w wypożyczalni
            if (f != null)
            {
                // Sprawdzamy, czy film już jest wypożyczony
                if (!wypozyczone.ContainsKey(tytul))
                {
                    // Dodaj film do wypożyczonych w profilu
                    wypozyczone.Add(tytul, (f, DateTime.Now));

                    // Ustaw datę oddania filmu
                    kiedyOddac = DateTime.Now.AddDays(f.dniWypozyczenia());
                    f.DataOddania = kiedyOddac;

                    Console.WriteLine($"Film \"{f.Tytul}\" został wypożyczony. Termin zwrotu: {kiedyOddac.ToString()}.");
                }
                else
                {
                    Console.WriteLine($"Film \"{tytul}\" jest już wypożyczony.");
                }
            }
            else
            {
                Console.WriteLine("Film nie został znaleziony w wypożyczalni.");
            }
        }


        public void Oddaj(Wypozyczalnia wypozyczalnia, string tytul)
        {
            // Sprawdzenie, czy film jest wypożyczony
            if (wypozyczone.ContainsKey(tytul))
            {
                var film = wypozyczone[tytul];

                // Sprawdzamy, czy film nie jest null
                if (film.film != null)
                {
                    // Dodajemy film z powrotem do wypożyczalni
                    wypozyczalnia.DodajFilm(film.film);

                    // Usuwamy film z wypożyczonych
                    wypozyczone.Remove(tytul);

                    // Zwracamy informację o sukcesie
                    Console.WriteLine($"Film \"{film.film.Tytul}\" został oddany do wypożyczalni.");
                }
                else
                {
                    // Obsługuje przypadek, gdy film w profilu jest null
                    throw new InvalidOperationException($"Film \"{tytul}\" nie istnieje w wypożyczonym zbiorze.");
                }
            }
            else
            {
                // Obsługuje przypadek, gdy film nie jest wypożyczony
                throw new InvalidOperationException($"Film \"{tytul}\" nie jest wypożyczony.");
            }
        }


        public void PrzedluzWaznosc(string tytul, int dni)
        {
            if (wypozyczone.ContainsKey(tytul))
            {
                var (film, dataWypozyczenia) = wypozyczone[tytul];

                if ((DateTime.Now - dataWypozyczenia).TotalDays > 90)
                {
                    throw new ZbytDlugoException("Brak dalszej możliwości przedłużania.");
                }
                else
                {
                    // Przedłużenie daty oddania filmu
                    kiedyOddac = kiedyOddac.AddDays(dni);
                    film.DataOddania = kiedyOddac;

                    Console.WriteLine($"Wypożyczenie filmu \"{film.Tytul}\" zostało przedłużone do: {kiedyOddac.ToString()}.");
                }
            }
            else
            {
                throw new InvalidOperationException("Film nie został wypożyczony.");
            }
        }
        public DateTime? GetTerminOddania(string tytul)
        {
            if (wypozyczone.ContainsKey(tytul))
            {
                var film = wypozyczone[tytul].film;
                return film.DataOddania;  // Zwraca datę zwrotu
            }
            else
            {
                return null;  // Jeśli film nie jest wypożyczony
            }
        }
        public void WyswietlWypozyczone()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine($"Wypożyczone filmy użytkownika \"{IdUzytkownika}\":");
            foreach (var f in wypozyczone.Values)
            {
                sb.AppendLine($"Tytuł: {f.film.Tytul}, data oddania: {f.film.DataOddania}");
            }
            Console.WriteLine(sb.ToString());
        }


        internal class ZbytDlugoException : Exception
        {
            public ZbytDlugoException() { }
            public ZbytDlugoException(string message) : base(message) { }
            public ZbytDlugoException(string message, Exception innerException) : base(message, innerException) { }
        }

    }
}
