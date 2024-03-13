using ConsoleApplication1.Manager.Serialization;
using ConsoleApplication1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Manager
{
    class KatedraManager
    {
        private List<Katedra> katedre;
        private Serializer<Katedra> serializer;

        private readonly string fileName = "katedre.txt";

        public KatedraManager()
        {
            serializer = new Serializer<Katedra>();
            UcitajKatedre();
        }

        private void UcitajKatedre()
        {
            katedre = serializer.FromCSV(fileName);
        }

        private void SacuvajKatedre()
        {
            serializer.ToCSV(fileName, katedre);
        }

       
        

        public Katedra DodajKatedru(Katedra katedra)
        {
            katedre.Add(katedra);
            SacuvajKatedre();
            return katedra;
        }

        public Katedra UpdateKatedra(Katedra katedra,Katedra nova_katedra)
        {
            
           
            katedra.sifra_katedre = nova_katedra.sifra_katedre ;
            katedra.naziv_katedre = nova_katedra.naziv_katedre ;
            katedra.idSefaKatedra = nova_katedra.idSefaKatedra ;
            

            SacuvajKatedre();
            return katedra;
        }

        public Katedra IzbrisiKatedru(int id)
        {
            Katedra kat = GetKatedraById(id);
            if (kat == null) return null;

            katedre.Remove(kat);
            SacuvajKatedre();
            return kat;
        }

        public Katedra GetKatedraById(int id)
        {
            return katedre.Find(k => k.sifra_katedre == id);
        }

        public List<Katedra> GetAllKatedre()
        {
            return katedre;
        }
    }
}
