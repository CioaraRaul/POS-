using emitati;

namespace entitati
{
    public class Produs : ProdusAbstract
    {
        public Produs(int id, string? nume, string? codIntern, string? producator, int pret, string? categorie) : base(id, nume, codIntern)
        {
            Producator = producator ?? string.Empty;
            Pret = pret;
            Categorie = categorie ?? string.Empty;
        }
        public Produs()
        {

        }
        public void afisareProdus()
        {
            Console.WriteLine($"{this.Id} {this.Nume} {this.CodIntern} {this.Pret} {this.Producator}");
        }
        public string? Producator { get; set; }

        public override string Descriere()
        {
            return "Produs: " + this.Nume + "[" + this.CodIntern + "" +
                "] " + this.Producator;
        }
        public override string AltaDescriere()
        {
            return this.Nume + this.CodIntern;
        }

        public override bool CompareItem(ProdusAbstract itemToAdd)
        {
            if (base.CompareItem(itemToAdd) && this.Producator == ((Produs)itemToAdd).Producator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool CanAddToPackage(List<object> test, string[] elemStringArr, int[] elemIntArr, string type = "")
        {
            return true; 
        }


    }
}