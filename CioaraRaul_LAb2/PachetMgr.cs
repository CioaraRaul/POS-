using emitati;
using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CioaraRaul_LAb2
{
    internal class PachetMgr: ProdusAbstractMgr<Pachet>
    {
        public Pachet userInputData(int id, IPackageable elem_pachet, List<Pachet>elem)
        {
                String? nume;
                String? codIntern;
                String? categorie;
                int? pret;

                Console.WriteLine("Introdu un produs");

                Console.Write("Numele:");
                nume = Console.ReadLine();

                Console.Write("Codul intern:");
                codIntern = Console.ReadLine();

                Console.Write("Pret:");
                pret = int.Parse(Console.ReadLine());

                Console.WriteLine("Categorie: ");
                categorie = Console.ReadLine();

               
                
                //citest pack

                return new Pachet(elem_pachet, id, nume, codIntern, pret, categorie);
            // citim datele unui pack
        }
        public override int handleHowMany(int numberOfItems = 0)
        {
          
           Console.WriteLine("How many servicies do u wanna add: ");
           numberOfItems = int.Parse(Console.ReadLine());
            
            return numberOfItems;
        }

        public string handleChoose(string result = "")
        {
            Console.WriteLine("Produs or serviciu: ");
            result = Console.ReadLine();
            return result;
        }
        public override void filtreaza(string filtru)
        {
            throw new NotImplementedException();
        }
        public override int handleCategory(string[] category, string categoySearchBy)
        {
            
                List<string> filteredCategories = new List<string>();


                for (int i = 0; i < category.Length; i++)
                {
                    if (category[i] == "e")
                    {

                    }
                }

                Console.WriteLine(filteredCategories);



                return 0;

        }
        public override void handlePrice(int[] price, int targetPrice)
        {
            throw new NotImplementedException();
        }

    }
}
