using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RuneAggregateTree
{
    public class TokenSystem
    {
        #region
        private string _name = "";
        private string _names = "";
        #endregion

        public int RTID { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name
        {
            //Expression bodied members
            //get { return _name ?? ""; }
            get => _name ?? "";
            //set { _name = value ?? ""; }
            set => _name = value ?? "";
        }

        public string[] Names;
    }
}
