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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjektFilmyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private Wypozyczalnia wypozyczalnia;
        private Profil profil;

        public MainWindow()
        {
            wypozyczalnia = new Wypozyczalnia("Super Wypożyczalna");
            profil = new Profil("AgataNowak55");
            InitializeComponent();

            valuesFilmy();
            txtNazwaWypozyczalniaFilmow.Text = wypozyczalnia.Nazwa;


        }


        private void btnMovieList_Click(object sender, RoutedEventArgs e)
        {
            PrzegladajFilmyWindow przegladajFilmyWindow = new PrzegladajFilmyWindow(wypozyczalnia, profil);
            przegladajFilmyWindow.Show();
            this.Close();

        }

        void valuesFilmy()
        {
            #region filmyhistoryczne
            Historyczny h1 = new("Lista Schindlera", "Steven Spielberg", "1993");
            Historyczny h2 = new("Gladiator", "Ridley Scott", "2000");
            Historyczny h3 = new("Apokalipsa", "Francis Ford Coppola", "1979");
            Historyczny h4 = new("Zniewolony. 12 Years a Slave", "Steve McQueen", "2013");
            Historyczny h5 = new("Bitwa o Midway", "Roland Emmerich", "2019");
            Historyczny h6 = new("Przełęcz ocalonych", "Mel Gibson", "2017");
            Historyczny h7 = new("Wielki Gatsby", "Baz Luhrmann", "2013");
            Historyczny h8 = new("Czarna książka", "Paul Verhoeven", "2006");
            Historyczny h9 = new("Tajemnice wojny", "Jerzy Hoffman", "1976");
            Historyczny h10 = new("Ostatni samuraj", "Edward Zwick", "2003");
            Historyczny h11 = new("Katyń", "Andrzej Wajda", "2007");
            Historyczny h12 = new("Służące", "Tate Taylor", "2011");
            Historyczny h13 = new("Czas wojny", "Steven Spielberg", "2011");
            Historyczny h14 = new("Pianista", "Roman Polański", "2002");
            #endregion
            #region filmyscifi
            ScienceFiction sf1 = new("Blade Runner", "Ridley Scott", "1982");
            ScienceFiction sf2 = new("Matrix", "Lana Wachowski, Lilly Wachowski", "1999");
            ScienceFiction sf3 = new("Incepcja", "Christopher Nolan", "2010");
            ScienceFiction sf4 = new("Gwiezdne wojny: Nowa nadzieja", "George Lucas", "1977");
            ScienceFiction sf5 = new("Matrix Reaktywacja", "Lana Wachowski, Lilly Wachowski", "2003");
            ScienceFiction sf6 = new("Łowca androidów 2049", "Denis Villeneuve", "2017");
            ScienceFiction sf7 = new("Elysium", "Neill Blomkamp", "2013");
            ScienceFiction sf8 = new("Obcy – 8. pasażer Nostromo", "Ridley Scott", "1979");
            ScienceFiction sf9 = new("Wojna światów", "Steven Spielberg", "2005");
            ScienceFiction sf10 = new("Jestem legendą", "Francis Lawrence", "2007");
            ScienceFiction sf11 = new("Powrót do przyszłości", "Robert Zemeckis", "1985");
            ScienceFiction sf12 = new("Avatar", "James Cameron", "2009");
            ScienceFiction sf13 = new("Oblivion", "Joseph Kosinski", "2013");
            ScienceFiction sf14 = new("Star Trek", "J.J. Abrams", "2009");
            #endregion
            #region filmybiograficzne
            Biograficzny b1 = new("Teoria wszystkiego", "James Marsh", "2014");
            Biograficzny b2 = new("Bohemian Rhapsody", "Bryan Singer", "2018");
            Biograficzny b3 = new("The Social Network", "David Fincher", "2010");
            Biograficzny b4 = new("Gra tajemnic", "Morten Tyldum", "2014");
            Biograficzny b5 = new("The Theory of Everything", "James Marsh", "2014");
            Biograficzny b6 = new("Wielka piękność", "Paolo Sorrentino", "2013");
            Biograficzny b7 = new("Człowiek, który wiedział za dużo", "Alfred Hitchcock", "1956");
            Biograficzny b8 = new("Dzięki Bogu", "François Ozon", "2018");
            Biograficzny b9 = new("Luter", "Eric Till", "2003");
            Biograficzny b10 = new("Królowie ulicy", "David O. Russell", "2013");
            Biograficzny b11 = new("Za wszelką cenę", "Clint Eastwood", "2008");
            Biograficzny b12 = new("Kapitan Phillips", "Paul Greengrass", "2013");
            Biograficzny b13 = new("Bohemian Rhapsody", "Bryan Singer", "2018");
            Biograficzny b14 = new("Zachowaj spokój", "David O. Russell", "2015");
            #endregion

            #region filmydladzieci
            DlaDzieci d1 = new("Król Lew", "Roger Allers, Rob Minkoff", "1994");
            DlaDzieci d2 = new("Shrek", "Andrew Adamson, Vicky Jenson", "2001");
            DlaDzieci d3 = new("Toy Story: Historia zabawek", "John Lasseter", "1995");
            DlaDzieci d4 = new("Gdzie jest Nemo", "Andrew Stanton", "2003");
            DlaDzieci d5 = new("Królewna Śnieżka", "Wilfred Jackson", "1937");
            DlaDzieci d6 = new("Pocahontas", "Mike Gabriel, Eric Goldberg", "1995");
            DlaDzieci d7 = new("Kubuś Puchatek", "John Lounsbery", "1977");
            DlaDzieci d8 = new("Pinokio", "Ben Sharpsteen", "1940");
            DlaDzieci d9 = new("Aladyn", "Ron Clements, John Musker", "1992");
            DlaDzieci d10 = new("Bambi", "David Hand", "1942");
            DlaDzieci d11 = new("Mulan", "Tony Bancroft, Barry Cook", "1998");
            DlaDzieci d12 = new("Wielka Czwórka", "Joe Johnston", "2012");
            DlaDzieci d13 = new("Zootopia", "Byron Howard, Rich Moore", "2016");
            DlaDzieci d14 = new("Shrek 2", "Andrew Adamson, Kelly Asbury", "2004");
            #endregion
            #region filmyhorror
            Horror hr1 = new("Egzorcysta", "William Friedkin", "1973");
            Horror hr2 = new("Lśnienie", "Stanley Kubrick", "1980");
            Horror hr3 = new("Oczy szeroko zamknięte", "Stanley Kubrick", "1999");
            Horror hr4 = new("Koszmar z ulicy Wiązów", "Wes Craven", "1984");
            Horror hr5 = new("Milczenie owiec", "Jonathan Demme", "1991");
            Horror hr6 = new("Sierociniec", "J.A. Bayona", "2007");
            Horror hr7 = new("Psychoza", "Alfred Hitchcock", "1960");
            Horror hr8 = new("Scream", "Wes Craven", "1996");
            Horror hr9 = new("Martwe zło", "Sam Raimi", "1981");
            Horror hr10 = new("The Ring", "Gore Verbinski", "2002");
            Horror hr11 = new("To", "Andy Muschietti", "2017");
            Horror hr12 = new("Koszmar z ulicy Wiązów", "Wes Craven", "1984");
            Horror hr13 = new("The Exorcist", "William Friedkin", "1973");
            Horror hr14 = new("The Witch", "Robert Eggers", "2015");
            #endregion
            #region filmyfantasy
            Fantasy f1 = new("Władca Pierścieni: Drużyna Pierścienia", "Peter Jackson", "2001");
            Fantasy f2 = new("Harry Potter i Kamień Filozoficzny", "Chris Columbus", "2001");
            Fantasy f3 = new("Hobbit: Niezwykła podróż", "Peter Jackson", "2012");
            Fantasy f4 = new("Harry Potter i Komnata Tajemnic", "Chris Columbus", "2002");
            Fantasy f5 = new("Gra o Tron", "David Benioff", "2011");
            Fantasy f6 = new("Władca Pierścieni: Dwie wieże", "Peter Jackson", "2002");
            Fantasy f7 = new("Eragon", "Stefen Fangmeier", "2006");
            Fantasy f8 = new("Kroniki Narnii: Lew, Czarownica i stara szafa", "Andrew Adamson", "2005");
            Fantasy f9 = new("Mroczne cienie", "Tim Burton", "2012");
            Fantasy f10 = new("Wielka Czwórka", "Joe Johnston", "2012");
            Fantasy f11 = new("Czarnoksiężnik z Oz", "Victor Fleming", "1939");
            Fantasy f12 = new("Hobbit: Bitwa Pięciu Armii", "Peter Jackson", "2014");
            Fantasy f13 = new("Percy Jackson: Złodziej pioruna", "Chris Columbus", "2010");
            Fantasy f14 = new("Pięciomorgowy Król", "Shane Acker", "2009");
            #endregion
            #region filmyedukacyjne
            Edukacyjny ed1 = new("Niewygodna prawda", "Davis Guggenheim", "2006");
            Edukacyjny ed2 = new("Nasza planeta", "Alastair Fothergill", "2019");
            Edukacyjny ed3 = new("Marsz pingwinów", "Luc Jacquet", "2005");
            Edukacyjny ed4 = new("Zatoka", "Louie Psihoyos", "2009");
            Edukacyjny ed5 = new("Ziemia – nasz dom", "Yann Arthus-Bertrand", "2009");
            Edukacyjny ed6 = new("Przywrócić lasy", "Emmanuel Cappellin", "2017");
            Edukacyjny ed7 = new("An Inconvenient Truth", "Davis Guggenheim", "2006");
            Edukacyjny ed8 = new("Chasing Ice", "Jeff Orlowski", "2012");
            Edukacyjny ed9 = new("Before the Flood", "Fisher Stevens", "2016");
            Edukacyjny ed10 = new("Cowspiracy", "Kip Andersen, Keegan Kuhn", "2014");
            Edukacyjny ed11 = new("The True Cost", "Andrew Morgan", "2015");
            Edukacyjny ed12 = new("Our Planet", "Alastair Fothergill", "2019");
            Edukacyjny ed13 = new("The Last Dance", "Jason Hehir", "2020");
            Edukacyjny ed14 = new("The Minimalists: Less Is Now", "Matt D'Avella", "2021");
            #endregion


            // Dodawanie filmów do wypożyczalni
            #region dodawaniefilmow
            wypozyczalnia.DodajFilm(h1); wypozyczalnia.DodajFilm(h2);
            wypozyczalnia.DodajFilm(h3); wypozyczalnia.DodajFilm(h4);
            wypozyczalnia.DodajFilm(h5); wypozyczalnia.DodajFilm(h6);
            wypozyczalnia.DodajFilm(h7); wypozyczalnia.DodajFilm(h8);
            wypozyczalnia.DodajFilm(h9); wypozyczalnia.DodajFilm(h10);
            wypozyczalnia.DodajFilm(h11); wypozyczalnia.DodajFilm(h12);
            wypozyczalnia.DodajFilm(h13); wypozyczalnia.DodajFilm(h14);
            wypozyczalnia.DodajFilm(sf1); wypozyczalnia.DodajFilm(sf2);
            wypozyczalnia.DodajFilm(sf3); wypozyczalnia.DodajFilm(sf4);
            wypozyczalnia.DodajFilm(sf5); wypozyczalnia.DodajFilm(sf6);
            wypozyczalnia.DodajFilm(sf7); wypozyczalnia.DodajFilm(sf8);
            wypozyczalnia.DodajFilm(sf9); wypozyczalnia.DodajFilm(sf10);
            wypozyczalnia.DodajFilm(sf11); wypozyczalnia.DodajFilm(sf12);
            wypozyczalnia.DodajFilm(sf13); wypozyczalnia.DodajFilm(sf14);
            wypozyczalnia.DodajFilm(b1); wypozyczalnia.DodajFilm(b2);
            wypozyczalnia.DodajFilm(b3); wypozyczalnia.DodajFilm(b4);
            wypozyczalnia.DodajFilm(b5); wypozyczalnia.DodajFilm(b6);
            wypozyczalnia.DodajFilm(b7); wypozyczalnia.DodajFilm(b8);
            wypozyczalnia.DodajFilm(b9); wypozyczalnia.DodajFilm(b10);
            wypozyczalnia.DodajFilm(b11); wypozyczalnia.DodajFilm(b12);
            wypozyczalnia.DodajFilm(b13); wypozyczalnia.DodajFilm(b14);
            wypozyczalnia.DodajFilm(d1); wypozyczalnia.DodajFilm(d2);
            wypozyczalnia.DodajFilm(d3); wypozyczalnia.DodajFilm(d4);
            wypozyczalnia.DodajFilm(d5); wypozyczalnia.DodajFilm(d6);
            wypozyczalnia.DodajFilm(d7); wypozyczalnia.DodajFilm(d8);
            wypozyczalnia.DodajFilm(d9); wypozyczalnia.DodajFilm(d10);
            wypozyczalnia.DodajFilm(d11); wypozyczalnia.DodajFilm(d12);
            wypozyczalnia.DodajFilm(d13); wypozyczalnia.DodajFilm(d14);
            wypozyczalnia.DodajFilm(hr1); wypozyczalnia.DodajFilm(hr2);
            wypozyczalnia.DodajFilm(hr3); wypozyczalnia.DodajFilm(hr4);
            wypozyczalnia.DodajFilm(hr5); wypozyczalnia.DodajFilm(hr6);
            wypozyczalnia.DodajFilm(hr7); wypozyczalnia.DodajFilm(hr8);
            wypozyczalnia.DodajFilm(hr9); wypozyczalnia.DodajFilm(hr10);
            wypozyczalnia.DodajFilm(hr11); wypozyczalnia.DodajFilm(hr12);
            wypozyczalnia.DodajFilm(hr13); wypozyczalnia.DodajFilm(hr14);
            wypozyczalnia.DodajFilm(f1); wypozyczalnia.DodajFilm(f2);
            wypozyczalnia.DodajFilm(f3); wypozyczalnia.DodajFilm(f4);
            wypozyczalnia.DodajFilm(f5); wypozyczalnia.DodajFilm(f6);
            wypozyczalnia.DodajFilm(f7); wypozyczalnia.DodajFilm(f8);
            wypozyczalnia.DodajFilm(f9); wypozyczalnia.DodajFilm(f10);
            wypozyczalnia.DodajFilm(f11); wypozyczalnia.DodajFilm(f12);
            wypozyczalnia.DodajFilm(f13); wypozyczalnia.DodajFilm(f14);
            wypozyczalnia.DodajFilm(ed1); wypozyczalnia.DodajFilm(ed2);
            wypozyczalnia.DodajFilm(ed3); wypozyczalnia.DodajFilm(ed4);
            wypozyczalnia.DodajFilm(ed5); wypozyczalnia.DodajFilm(ed6);
            wypozyczalnia.DodajFilm(ed7); wypozyczalnia.DodajFilm(ed8);
            wypozyczalnia.DodajFilm(ed9); wypozyczalnia.DodajFilm(ed10);
            wypozyczalnia.DodajFilm(ed11); wypozyczalnia.DodajFilm(ed12);
            wypozyczalnia.DodajFilm(ed13); wypozyczalnia.DodajFilm(ed14);
            #endregion


            profil.Wypozycz(wypozyczalnia, "Aladyn");


        }
    }


}
