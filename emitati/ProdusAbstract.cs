using entitati;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emitati
{
    public abstract class ProdusAbstract : IPackageable
    {
        public  ProdusAbstract(int id, string? nume, string? codIntern, int? pret, string? categorie)
        {
            Id = id;
            Nume = nume;
            CodIntern = codIntern;
            Pret = pret;
            Categorie = categorie;

          
        }

        public ProdusAbstract() { }

        public ProdusAbstract(int id) { }

        protected ProdusAbstract(int id, string? nume, string? codIntern)
        {
            Id = id;
            Nume = nume;
            CodIntern = codIntern;
        }

        public ProdusAbstract(int id, string? nume, string? codIntern, string? categorie, int? pret) : this(id, nume, codIntern)
        {
        }

        public int Id { get; set; }
        public string? Nume { get; set; }
        public string? CodIntern { get; set; }

        public int? Pret { get; set; } = 0;

        public string? Categorie { get; set; } = "";

        public abstract string Descriere();

        public abstract string AltaDescriere();

        public virtual bool CompareItem(ProdusAbstract itemToAdd)
        {
            if(this.Nume == itemToAdd.Nume && this.CodIntern == itemToAdd.CodIntern) {
                return true;
            }else
            {
                return false;
            }
        }

        public abstract bool CanAddToPackage(List<object> test,string[] elemStringArr, int[] elemIntArr, string type);

        public bool CanAddToPackage(Pachet pachet)
        {
            throw new NotImplementedException();
        }

        public int handleTotalPrice()
        {
            throw new NotImplementedException();
        }

       
    }
}
