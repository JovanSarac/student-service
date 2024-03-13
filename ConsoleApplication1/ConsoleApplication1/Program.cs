using ConsoleApplication1.model;
using ConsoleApplication1.Manager;
using ConsoleApplication1.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Manager.Serialization;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager_student = new StudentManager();
            ProfesorManager manager_profesor = new ProfesorManager();
            PredmetManager manager_predmet = new PredmetManager();
            OcenaNaIspituManager manager_ispit = new OcenaNaIspituManager();
            KatedraManager manager_katedra = new KatedraManager();
            AdresaManager manager_adresa = new AdresaManager();

            
            AllConsoleView view = new AllConsoleView(manager_student,manager_profesor,manager_predmet,manager_ispit,manager_katedra,manager_adresa);
            view.RunMenu();
           
        }

      
    }
}
