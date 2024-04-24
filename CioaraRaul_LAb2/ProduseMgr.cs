using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace emitati
{
       internal class ProduseMgr : ProdusAbstractMgr<Produs>

    
        {
        List<Produs> produsList = new List<Produs>();

        public int pret { get; private set; }
        public string? categorie { get; private set; }

        public ProduseMgr() { 
        }
        public Produs userInputData(int id)
            {
                String? nume;
                String? codIntern;
                String? producator;

                Console.WriteLine("Introdu un produs");
                Console.Write("Numele:");
                nume = Console.ReadLine();

                Console.Write("Codul intern:");
                codIntern = Console.ReadLine();
                Console.Write("Producator:");
                producator = Console.ReadLine();

            //citest produsr

                return new Produs(id, nume, codIntern, producator,pret,categorie);
            }// citim datele unui produs
            public void ReadAbsProds(int number)
            {
                Produs produs;
                int cnt = CountElemente;
                for (int i = cnt; i < cnt + number; i++)
                {
                    produs = userInputData(Id);
                    ReadAbsProd(produs);
                }
            }
        public override int handleHowMany(int numberOfItems = 0)
        {
            Console.WriteLine("Do you want to pick from produs or serviciu: ");
            string anw = Console.ReadLine();
            if (anw == "produs")
            {
                Console.WriteLine("How many products do u wanna add: ");
                numberOfItems = int.Parse(Console.ReadLine());
            }
            if (anw == "serviciu")
            {
                Console.WriteLine("How many servicies do u wanna add: ");
                numberOfItems = int.Parse(Console.ReadLine());
            }
            return numberOfItems;
        }

        public void InitListafromXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Raul C\\Downloads\\lab8\\POS3labO (1)\\POS3labO\\POS\\CioaraRaul_LAb2\\XMLFile1.xml"); // Load XML file from the given path

            XmlNodeList lista_noduri = doc.SelectNodes("/produse/Produs");
            foreach (XmlNode nod in lista_noduri)
            {

                string nume = nod["Nume"].InnerText;
                string codIntern = nod["CodIntern"].InnerText;
                string producator = nod["Producator"].InnerText;
                int pret = int.Parse(nod["Pret"].InnerText);
                string categorie = nod["Categorie"].InnerText;


                Produs prod = new Produs(IdXML, nume, codIntern, producator, pret, categorie);

                listaProd.Add(prod);

                // T newProdus = (T)Activator.CreateInstance(typeof(T), new object[] { Id + 1, nume, codIntern, producator, pret, categorie });
                //elemente.Add(newProdus);

                // CountElemente++;
                IdXML++;




                /* var xmlElem = new
                 {
                     number = IdXML,
                     categorie,
                     codIntern,
                     producator,
                     pret,
                     nume
                 };

                 readXMLobj(xmlElem);*/
            }
        }
        public void afisareLista()
        {
            foreach (var item in listaProd)
            {
                item.afisareProdus();
            }
        }
        public override void filtreaza(string filtru)
        {
            foreach(var item in listaProd)
            {
                if(item.Categorie == filtru)
                {
                    Console.WriteLine("Da");
                }
            }
        }
        public override int handleCategory(string[] category, string categoySearchBy)
        {
            
            List<string> filteredCategories = new List<string>();


            for (int i = 0; i < category.Length; i++)
            {
                if (category[i] == categoySearchBy)
                {
                    filteredCategories.Add(category[i]);
                }
            }

            int howManyTimesAppeard = filteredCategories.Count();
            Console.WriteLine($"The number of appearence of {categoySearchBy} is {howManyTimesAppeard}");

            return howManyTimesAppeard;

        }
        public override void handlePrice(int[] price, int targetPrice)
        {
            List<int> priceLower = new List<int>();
            List<int> priceHigher = new List<int>();
            List<int> priceEqual = new List<int>();

            for(int i = 0; i < price.Length; i++)
            {
                if (price[i] == targetPrice) {

                    priceEqual.Add(price[i]);
                }
                if (price[i] < targetPrice)
                {
                    priceLower.Add(price[i]);
                }
                if (price[i] > targetPrice)
                {
                    priceHigher.Add(price[i]);
                }
            }
            Console.WriteLine($"Your price: {targetPrice}.The equal with your price: {priceEqual.Count}, the higher price: {priceHigher.Count}, the lower price: {priceLower.Count}");
        }

    }
 }
 
