using emitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entitati
{
    public class Servicii : ProdusAbstract
    {
        private string? pret;
        private int categorie;

        public Servicii(int id, string? nume, string? codIntern, string? producator, int pret, string? categorie) : base(id, nume, codIntern)
        {
            

        }
        public Servicii()
        {

        }

        public Servicii(int id, string? nume, string? codIntern, string? pret, int categorie) : base(id, nume, codIntern)
        {
            this.pret = pret;
            this.categorie = categorie;
        }

        public override string Descriere()
        {
            return "Produs: " + this.Nume + "[" + this.CodIntern + "" +
                "] ";
        }

        public override string AltaDescriere()
        {
            return this.Nume + "[ " + this.CodIntern + "]";
        }
        public override bool CompareItem(ProdusAbstract itemToAdd)
        {
            return base.CompareItem(itemToAdd);
        }

        public override bool CanAddToPackage(List<object> test, string[] elemStringArr, int[] elemIntArr, string type = "")
        {
            throw new NotImplementedException();
        }
    }
}
