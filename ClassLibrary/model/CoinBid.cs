using System;

namespace ClassLibrary
{
    public class CoinBid
    {
        private int _id;
        private string _Genstand;
        private int _Bud;
        private string _Navn;

        public CoinBid()
        {

        }

        public CoinBid(int id, string genstand, int bud, string navn)
        {
           _id = id;
           _Genstand = genstand;
           _Bud= bud;
           _Navn = navn;
        }

        public int Id
        {
            get => _id;
            set => _id = value;

        }

        public string Genstand
        {
            get => _Genstand;
            set => _Genstand = value;
        }
        public int Bud
        {
            get => _Bud;
            set => _Bud = value;
        }


        public string Navn
        {
            get => _Navn;
            set => _Navn = value;
        }


        public override string ToString()
        { 
            return $"{nameof(Id)}: {Id}, {nameof(Genstand)}: {Genstand}, {nameof(Bud)}: {Bud}, {nameof(Navn)}: {Navn}";
        }
    }
}
