using entitati;
using System;

namespace emitati
{
    internal class ServiciiMgr : ProdusAbstractMgr<Servicii>
    {
        public string? pret { get; private set; }
        public int categorie { get; private set; }

        private Servicii userInputData(int id)
        {
            String? nume;
            String? codIntern;

            Console.WriteLine("Introdu un serviciu");
            Console.Write("Numele:");
            nume = Console.ReadLine();

            Console.Write("Codul intern:");
            codIntern = Console.ReadLine();

            return new Servicii(id, nume, codIntern, pret, categorie);
        }

        public void ReadAbsProds(int number)
        {
            Servicii serviciu;
            int cnt = CountElemente;
            for (int i = cnt; i < cnt + number; i++)
            {
                serviciu = userInputData(Id);
                ReadAbsProd(serviciu);
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
