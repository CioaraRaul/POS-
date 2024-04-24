using emitati;
using entitati;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;

namespace CioaraRaul_LAb2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //citire si afisare obicte de tipul Produs
            Produs prod = new Produs();
            ProduseMgr produseMgr = new ProduseMgr();
            PachetMgr package = new PachetMgr();
            Pachet testPack = new Pachet();

            //   Console.Write("Nr. produse:");
            //     int nrProduse = int.Parse(Console.ReadLine() ?? string.Empty);
            //       produseMgr.ReadAbsProds(nrProduse);

            //         Servicii serv = new Servicii();
            //ServiciiMgr serviciiMgr = new ServiciiMgr();
            // Console.WriteLine("Nr. Servicii: ");

            //  int NrServicii = int.Parse(Console.ReadLine() ?? String.Empty);
            //serviciiMgr.ReadAbsProds(NrServicii);

            Console.WriteLine("Package read from xml");
            List<object> test = (List<object>)package.Write2ConsoleXML(); // Assuming Write2ConsoleXML() returns a List<object>

            List<Produs> test1 = new List<Produs>();

            ProduseMgr produseMgr1 = new ProduseMgr();
            produseMgr1.InitListafromXML();
            produseMgr1.afisareLista();
            produseMgr1.filtreaza("Tehnologia");

            int[] pret = new int[test.Count];

            string[] category = new string[test.Count];

            for (int i = 0; i < test.Count; i++)
            {
                var let = test[i];
                dynamic dynamicItem = let;
                pret[i] = dynamicItem.pret;

                var let2 = test[i];
                dynamic dynamicItem2 = let2;
                category[i] = dynamicItem2.categorie;

            }

            produseMgr.handleCategory(category, "Tehnologia Informatiei");
            produseMgr.handlePrice(pret, 1000);

            testPack.handleTotalPrice(pret);

            // produseMgr.Write2Console();
            // serviciiMgr.Write2Console();

          

            dynamic lastItem = test.Last();

            string[] arrLastItemString = { lastItem.categorie, lastItem.producator
            , lastItem.nume,lastItem.codIntern};

             int[] arrLastItemInt = { lastItem.number, lastItem.produs, lastItem.serviciu, lastItem.pret };


            int num = package.handleHowMany();
            string result = package.handleChoose().ToLower();

            testPack.CanAddToPackage(test, arrLastItemString, arrLastItemInt, result);

            

            
           // testProdusAbs.handleCategory(category);
        }
    }
}
