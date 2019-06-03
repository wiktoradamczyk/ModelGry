using System;
using System.Collections.Generic;
using System.Text;

namespace ModelGry
{
    public partial class Gra
    {
        private readonly List<Ruch> historia;
        public IReadOnlyList<Ruch> Historia => historia;

        // inner class - klasa wewnętrzna
        public class Ruch
        {
            public readonly int propozycja;
            public readonly Odpowiedz odpowiedz;
            public readonly DateTime kiedy;

            public Ruch(int prop, Odpowiedz odp)
            {
                propozycja = prop;
                odpowiedz = odp;
                kiedy = DateTime.Now;
            }

            public override string ToString()
            {
                return $"({propozycja}, {odpowiedz}, {kiedy})";
            }
        }

    }
}
