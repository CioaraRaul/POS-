using emitati;
using entitati;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public interface IXmlComponent
{
    int Number { get; set; }
    string Categorie { get; set; }
    string CodIntern { get; set; }
    string Producator { get; set; }
    int Pret { get; set; }
    string Nume { get; set; }
}

namespace emitati
{
    internal abstract class ProdusAbstractMgr<T> where T : ProdusAbstract
    {
        //protected ProdusAbstract[] elemente = new ProdusAbstract[100];


        List<IXmlComponent> objectList = new List<IXmlComponent>();

        protected List<T> elemente = new List<T>();
        public int CountElemente { get; set; } = 0;
        public int Id { get; set; } = 0;

        public int IdXML { get; set; } = 0;

        public List<Produs> listaProd = new List<Produs>();

        public List<object> Write2ConsoleXML()
        {
            InitListafromXML();  // Assuming this initializes objectList

            List<object> result = new List<object>();

            foreach (var item in objectList)
            {
                Console.WriteLine(item.Nume + " foreach");

                // Assuming you want to print other properties as well


                // Create an anonymous object with the properties and add it to the result list
                var obj = new
                {
                    number = item.Number,
                    categorie = item.Categorie,
                    codIntern = item.CodIntern,
                    producator = item.Producator,
                    pret = item.Pret,
                    nume = item.Nume,
                    produs = 0,
                    serviciu = 0,
                };

                result.Add(obj);
            }

            return result;
        }


        public void readFromXML()
        {
            InitListafromXML();
            if (objectList.Count() != 0)
            {
                foreach (var obj in objectList)
                {
                    Console.WriteLine(obj.Number);
                    Console.WriteLine(obj.Nume);
                    Console.WriteLine(obj.CodIntern);
                    Console.WriteLine(obj.Producator);
                    Console.WriteLine(obj.Pret);
                    Console.WriteLine(obj.Categorie);

                }
            }
            if (objectList.Count() == 0)
            {
                Console.WriteLine("No packages. View your xml");
            }
            if (objectList.Count() <= 0)
            {
                Console.WriteLine("Something went wrong.");
            }


        }

        protected bool VerifyUnicity(ProdusAbstract item)
        {
            for (int i = 0; i < CountElemente; i++)
            {
                if (elemente[i].CompareItem(item))
                {
                    return true;
                }
            }
            return false;
        }


        public void ReadAbsProd(T item)
        {
            if (!VerifyUnicity(item))
            {
                elemente.Add(item); // Add the item directly to the list
                CountElemente++;
                Id++;
            }
        }

        public abstract int handleHowMany(int numberOfItems = 0);
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

                CountElemente++;
                IdXML++;




                var xmlElem = new
                {
                    number = IdXML,
                    categorie,
                    codIntern,
                    producator,
                    pret,
                    nume
                };

                readXMLobj(xmlElem);
            }
        }

        public void readXMLobj(object XmlComponents)
        {


            // Cast XmlComponents to var to access its properties
            var components = (dynamic)XmlComponents;

            // Access properties of components

            var obj = new XmlComponent
            {
                Number = Convert.ToInt32(components.number), // Convert components.number to int
                Categorie = components.categorie,
                CodIntern = components.codIntern,
                Producator = components.producator,
                Pret = Convert.ToInt32(components.pret), // Convert components.pret to int
                Nume = components.nume
            };

            // Add the object to the list
            objectList.Add(obj);
        }
        public abstract void filtreaza(string filtru);
        public abstract int handleCategory(string[] category, string categoySearchBy);

        public abstract void handlePrice(int[] price, int targetPrice);

    }
}
