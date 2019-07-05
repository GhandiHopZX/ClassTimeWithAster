using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RuneAggregateTree
{
    public class Token
    {
        #region
        private string _rname = "";
        #endregion

        public int RTID { get; set; }

        public string Rname { get => _rname; set => _rname = value; }

        public string Name { get => Rname ?? ""; set => Rname = value ?? ""; }
        public string RType { get => rType; set => rType = value; }

        private string rType;
        public string description;
        public decimal priceh;
        private RuneTree.Rune strN;

        //Token stuff

        public Token(string rname, string rtype, int rTID , decimal price, string desc)
        {
            Rname = rname;
            RType = rtype;
            RTID = rTID;
            description = desc;
            priceh = price;
        }

        public Token[] Tokens(RuneTree.Rune strN)
        {
            this.strN = strN;
            Token tokend = new Token(strN.Name, strN.RType, strN.ID, strN.Price, strN.Description);
            Token[] Tokenbag = { };
            return Tokenbag;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var items = new List<ValidationResult>();

            ////Name is required
            //if (String.IsNullOrEmpty(Name))
            //    items.Add(new ValidationResult("Name is required.", new[] { nameof(Name) }));


            //if (Price < 1000)
            //    items.Add(new ValidationResult("Price must be >= 0.", new[] { nameof(Price) }));

            if (priceh < 0)
                items.Add(new ValidationResult("Price must be >= 0.", new[] { nameof(priceh) }));

            if (priceh > 1000000)
                items.Add(new ValidationResult("Price is too great", new[] { nameof(priceh) }));

            return items;
        }
    }

}
