using entitati;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace emitati
{
    public class Pachet : ProdusAbstract , IPackageable
    {
        List<IPackageable> elemPack = new List<IPackageable>();

        public class ItemDetails
        {
            public int? Pret { get; set; }
            public string? Nume { get; set; }
            public string? CodIntern { get; set; }
            public string? Producator { get; set; }
            public string? Categorie { get; set; }
        }

        public Pachet(IPackageable elem_pachet, int id, string? nume, string? codIntern, int? pret, string? categorie)
             : base(id, nume, codIntern, categorie, pret)
        { 

        }
        public Pachet()
        {

        }
        public string? Producator { get; }
        public List<Pachet> Elem { get; }

        public override string AltaDescriere()
        {
            return "The other description from package";   
        }

        public override bool CanAddToPackage(List<object> test, string[] elemStringArr, int[] elemIntArr, string type = "")
        {
            List<object> testObj = new List<object>();
            int maxProdus = 1;
            int maxServiciu = 2;



            try
            {
                
                if (elemIntArr != null && elemStringArr != null && !string.IsNullOrEmpty(type))
                {
                    if (type.ToLower() == "serviciu")
                    {
                        if (elemIntArr[2] < maxServiciu)
                        {
                            ItemDetails itemDetails = addToPachetXML(type);
                            Console.WriteLine($"Nume: {itemDetails.Nume}, Cod Intern: {itemDetails.CodIntern}, Producator: {itemDetails.Producator}, Categorie: {itemDetails.Categorie}, Pret: {itemDetails.Pret}");
                            elemIntArr[2]++;
                            Console.WriteLine(elemIntArr[2]);

                       
                            var obj = new
                            {
                                number = 0,
                                categorie = itemDetails.Categorie,
                                codIntern = itemDetails.CodIntern,
                                producator = itemDetails.Producator,
                                pret = itemDetails.Pret,
                                nume = itemDetails.Nume,
                                produs = 0,
                                serviciu = elemIntArr[2],
                            };

                            testObj.Add(obj);
                          

                            foreach( var item in testObj)
                            {
                                dynamic dynamicItem = item;
                                Console.WriteLine(dynamicItem.categorie);
                            }

                          

                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Max amount of servicii reached");
                        }
                    }
                    else if (type.ToLower() == "produs")
                    {
                        if (elemIntArr[1] < maxProdus)
                        {
                            ItemDetails itemDetails = addToPachetXML(type);
                            Console.WriteLine($"Nume: {itemDetails.Nume}, Cod Intern: {itemDetails.CodIntern}, Producator: {itemDetails.Producator}, Pret:{itemDetails.Pret}");
                            elemIntArr[1]++;
                            Console.WriteLine(elemIntArr[1]);

                            var obj = new
                            {
                                number = 0,
                                categorie ="",
                                codIntern = itemDetails.CodIntern,
                                producator = itemDetails.Producator,
                                pret = itemDetails.Pret,
                                nume = itemDetails.Nume,
                                produs = elemIntArr[1],
                                serviciu = 0,
                            };

                            testObj.Add(obj);
                            foreach (var item in testObj)
                            {
                                dynamic dynamicItem = item;
                                Console.WriteLine(dynamicItem.pret);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Max amount of produse reached");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid type");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input parameters");
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public ItemDetails addToPachetXML(string type)
        {
            ItemDetails itemDetails = new ItemDetails();


            if (type == "produs")
            {
                String? nume;
                String? codIntern;
                String? producator;
                int? pret;

                Console.WriteLine("Introdu un produs");
                Console.Write("Numele:");
                nume = Console.ReadLine();

                Console.Write("Codul intern:");
                codIntern = Console.ReadLine();
                Console.Write("Producator:");
                producator = Console.ReadLine();
                Console.Write("Pret:");
                pret = int.Parse(Console.ReadLine());

                itemDetails.Nume = nume;
                itemDetails.CodIntern = codIntern;
                itemDetails.Producator = producator;
                itemDetails.Pret = pret;
                //citest produse

                
            }
            if(type == "serviciu")
            {
                String? nume;
                String? codIntern;
                string? producator;
                string? categorie;
                int? pret;

                Console.WriteLine("Introdu un serviciu");
                Console.Write("Numele:");
                nume = Console.ReadLine();

                Console.Write("Codul intern:");
                codIntern = Console.ReadLine();
                Console.Write("Producator:");
                producator = Console.ReadLine();
                Console.Write("Categorie: ");
                categorie = Console.ReadLine();
                Console.Write("Pret:");
                pret = int.Parse(Console.ReadLine());

                itemDetails.Nume = nume;
                itemDetails.CodIntern = codIntern;
                itemDetails.Producator = producator;
                itemDetails.Categorie = categorie;
                itemDetails.Pret= pret;

            }
            if(type != "produs" && type != "serviciu")
            {
                throw new Exception("Something went wrong");
            }

            return itemDetails;

        }

        public override string Descriere()
        {
            return "Pachetul cu id u: " + this.Id + " contine codul intern" + this.CodIntern + " el din pack " + this.elemPack;
        }

        public int handleTotalPrice(int[] arrayEl)
        {
            if ( arrayEl!= null)
            {
                Console.WriteLine(arrayEl.Length);
            }
            if( arrayEl== null)
            {
                throw new Exception("Element null");
            }
            return 1;
        }

    }
}
