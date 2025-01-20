using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProjektFilmy
{
    // Container dla wypozyczalni i profila
    [XmlRoot("WypozyczalniaProfil")]
    public class WypozyczalniaProfil
    {
        [XmlElement("Wypozyczalnia")]
        public Wypozyczalnia Wypozyczalnia { get; set; }

        [XmlElement("Profil")]
        public Profil Profil { get; set; }

        public WypozyczalniaProfil() { }

        public WypozyczalniaProfil(Wypozyczalnia wypozyczalnia, Profil profil)
        {
            Wypozyczalnia = wypozyczalnia;
            Profil = profil;
        }

        public void ZapiszXml(string nazwaPliku)
        {
            using StreamWriter sw = new(nazwaPliku);
            XmlSerializer xs = new(typeof(WypozyczalniaProfil));
            xs.Serialize(sw, this);
        }

        public static WypozyczalniaProfil? OdczytXml(string nazwaPliku)
        {
            if (!File.Exists(nazwaPliku)) { return null; }
            using StreamReader sr = new(nazwaPliku);
            XmlSerializer xs = new(typeof(WypozyczalniaProfil));
            return xs.Deserialize(sr) as WypozyczalniaProfil;
        }
    }
}


