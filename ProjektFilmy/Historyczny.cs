using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektFilmy
{

    public class Historyczny : Film
    {

        public Historyczny() : base("", "", DateTime.MinValue.ToString()) { } //konstruktor domyslny
        public Historyczny(string tytul, string rezyser, string datawydania)
            : base(tytul, rezyser, datawydania)
        {
            this.Id = $"{this.Id}-HIS";
        }

        public override double dniWypozyczenia()
        {
            return base.dniWypozyczenia() + 21;
        }

        public override string ToString()
        {
            return $"Film historyczny {base.ToString()}";
        }
    }

    public class ScienceFiction : Film
    {
        public ScienceFiction() : base("", "", DateTime.MinValue.ToString()) { }
        public ScienceFiction(string tytul, string rezyser, string datawydania)
            : base(tytul, rezyser, datawydania)
        {
            this.Id = $"{this.Id}-SCI-FI";
        }

        public override double dniWypozyczenia()
        {
            return base.dniWypozyczenia() + 5;
        }

        public override string ToString()
        {
            return $"Film Science-fiction {base.ToString()}";
        }
    }

    public class Biograficzny : Film
    {
        public Biograficzny() : base("", "", DateTime.MinValue.ToString()) { }
        public Biograficzny(string tytul, string rezyser, string datawydania)
            : base(tytul, rezyser, datawydania)
        {
            this.Id = $"{this.Id}-BIO";
        }

        public override double dniWypozyczenia()
        {
            return base.dniWypozyczenia() + 7;
        }

        public override string ToString()
        {
            return $"Film biograficzny {base.ToString()}";
        }
    }

    public class DlaDzieci : Film
    {
        public DlaDzieci() : base("", "", DateTime.MinValue.ToString()) { }
        public DlaDzieci(string tytul, string rezyser, string datawydania)
            : base(tytul, rezyser, datawydania)
        {
            this.Id = $"{this.Id}-KID";
        }

        public override double dniWypozyczenia()
        {
            return base.dniWypozyczenia();
        }

        public override string ToString()
        {
            return $"Film dla dzieci {base.ToString()}";
        }
    }

    public class Horror : Film
    {
        public Horror() : base("", "", DateTime.MinValue.ToString()) { }
        public Horror(string tytul, string rezyser, string datawydania)
            : base(tytul, rezyser, datawydania)
        {
            this.Id = $"{this.Id}-HOR";
        }

        public override double dniWypozyczenia()
        {
            return base.dniWypozyczenia() + 7;
        }

        public override string ToString()
        {
            return $"Horror {base.ToString()}";
        }
    }

    public class Fantasy : Film
    {
        public Fantasy() : base("", "", DateTime.MinValue.ToString()) { }
        public Fantasy(string tytul, string rezyser, string datawydania)
            : base(tytul, rezyser, datawydania)
        {
            this.Id = $"{this.Id}-FAN";
        }

        public override double dniWypozyczenia()
        {
            return base.dniWypozyczenia() + 10;
        }

        public override string ToString()
        {
            return $"Film fantasy {base.ToString()}";
        }
    }

    public class Edukacyjny : Film
    {
        public Edukacyjny() : base("", "", DateTime.MinValue.ToString()) { }
        public Edukacyjny(string tytul, string rezyser, string datawydania)
            : base(tytul, rezyser, datawydania)
        {
            this.Id = $"{this.Id}-EDU";
        }

        public override double dniWypozyczenia()
        {
            return base.dniWypozyczenia() + 30;
        }

        public override string ToString()
        {
            return $"Film edukacyjny {base.ToString()}";
        }
    }

}


