using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjektFilmy

{
    [XmlInclude(typeof(Historyczny))]
    [XmlInclude(typeof(ScienceFiction))]
    [XmlInclude(typeof(Biograficzny))]
    [XmlInclude(typeof(DlaDzieci))]
    [XmlInclude(typeof(Horror))]
    [XmlInclude(typeof(Fantasy))]
    [XmlInclude(typeof(Edukacyjny))]
    public abstract class Film : IComparable<Film>
    {
        [XmlElement("Tytul")]
        public string Tytul { get; set; }

        [XmlElement("Rezyser")]
        public string Rezyser { get; set; }

        [XmlElement("DataWydania")]
        public int DataWydania { get; set; }


        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlIgnore]
        public DateTime DataOddania { get; set; }

        protected static int nrseryjny;

        static Film()
        {
            nrseryjny = 1;
        }

        public Film(string tytul, string rezyser, string datawydania)
        {
            this.Tytul = tytul;
            this.Rezyser = rezyser;
            this.DataWydania = Int32.Parse(datawydania);

            this.Id = $"ID-{this.DataWydania}-{nrseryjny++}";
        }

        public virtual double dniWypozyczenia() => 14;

        public int CompareTo(Film? other)
        {
            if (other is null) return 1;
            return string.Compare(Tytul, other.Tytul, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return $"\"{Tytul}\", {Rezyser}, {DataWydania}, {Id}";
        }
    }

}
