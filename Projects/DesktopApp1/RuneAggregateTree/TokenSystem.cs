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
        public string[] RType { get => rType; set => rType = value; }

        private string[] rType;

        
        //Token stuff

        public Token(string rname, int rTID)
        {
            Rname = rname;
            RTID = rTID;
        }
    }

}
