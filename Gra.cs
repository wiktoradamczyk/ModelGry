using System;
using System.Collections.Generic;

namespace ModelGry
{
    public partial class Gra
    {
        // inner types
        public enum Odpowiedz { ZaMalo = -1, Trafiono = 0, ZaDuzo = 1 }
        public enum State { Trwa, Poddana, Odgadnieta }

        //fields
        public State StanGry { get; private set; }
        public readonly int ZakresOd;
        public readonly int ZakresDo;
        private readonly int wylosowana;
        public int? Wylosowana
        {
            get
            {
                if (StanGry != State.Trwa)
                    return wylosowana;
                else
                    return null;
            }
            //set { }
        }

        // historia gry: ToDo
        public int LicznikRuchow { get; private set; } = 0;

        public Gra(int a, int b)
        {
            ZakresOd = Math.Min(a,b);
            ZakresDo = Math.Max(a,b);
            wylosowana = Losuj(ZakresOd, ZakresDo);
            //LicznikRuchow = 0;
            StanGry = State.Trwa;
            historia = new List<Ruch>();
        }

        public Odpowiedz Ocena( int propozycja )
        {
            LicznikRuchow++;
            Odpowiedz odp;
            if (propozycja < wylosowana)
                odp = Odpowiedz.ZaMalo;
            else if (propozycja > wylosowana)
                odp = Odpowiedz.ZaDuzo;
            else
            {
                StanGry = State.Odgadnieta;
                odp = Odpowiedz.Trafiono;
            }
            historia.Add(new Ruch(propozycja, odp));
            return odp;
        }

        public void Poddaj()
        {
            StanGry = State.Poddana;
        }

        public static int Losuj(int min = 1, int max = 100)
        {
            if (min > max)
            { //swap
                int temp = min;
                min = max;
                max = temp;
            }
            Random generator = new Random();
            return generator.Next(min, max + 1);
        }
    }
}
