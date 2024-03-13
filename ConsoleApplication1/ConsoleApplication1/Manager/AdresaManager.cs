using ConsoleApplication1.Manager.Serialization;
using ConsoleApplication1.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Manager
{
    class AdresaManager
    {
        private List<Adresa> adrese;
        private Serializer<Adresa> serializer;
        private readonly string fileName = "adrese.txt";

        public AdresaManager()
        {
            serializer = new Serializer<Adresa>();
            UcitajAdrese();
        }

        private void UcitajAdrese()
        {
            adrese = serializer.FromCSV(fileName);
        }

        private void SacuvajAdrese()
        {
            serializer.ToCSV(fileName, adrese);
        }

        public Adresa DodajAdresu(Adresa adr)
        {
            adrese.Add(adr);
            SacuvajAdrese();
            return adr;
        }

        public Adresa UpdateAdresa(Adresa adr, Adresa nova_adr)
        {


            adr.id_adr = nova_adr.id_adr;
            adr.grad = nova_adr.grad;
            adr.broj = nova_adr.broj;
            adr.ulica = nova_adr.ulica;
            adr.drzava = nova_adr.drzava;


            SacuvajAdrese();
            return adr;
        }

        public Adresa IzbrisiAdresu(int id)
        {
            Adresa adr = GetAdresaById(id);
            if (adr == null) return null;

            adrese.Remove(adr);
            SacuvajAdrese();
            return adr;
        }

        public Adresa GetAdresaById(int id)
        {
            return adrese.Find(k => k.id_adr == id);
        }

        public List<Adresa> GetAllAdrese()
        {
            return adrese;
        }
    }
}
