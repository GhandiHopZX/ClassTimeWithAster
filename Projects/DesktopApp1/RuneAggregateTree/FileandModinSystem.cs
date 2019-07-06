using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace RuneAggregateTree
{
    class FileandModinSystem : RuneTree
    {

        // importing the sets
        public HashSet<string> Importfunction(string path)
        {
            // string hash
            HashSet<string> NewRunesTy = new HashSet<string>();

            // if statement
            if (!File.Exists(path))
            {
                string im;
                StreamReader importRune;

                using (importRune = File.OpenText(path))
                {
                    while ((im = importRune.ReadLine()) != null)
                    {
                        NewRunesTy.Add(im);
                    }
                }
            }
            return NewRunesTy;
        }

        //Taygr 
        // reference Taygr hash here
        private HashSet<Rune> Taygr = new HashSet<Rune> { }; // I still gotta pass these Runes into RuneTreeBranch's Taygr hashset

        // try passing the above hash to a database or better yet a tokenization
        // then send those tokens to a binding source
        // and just use the RuneTree to add categorization and description to
        // the obvious tokens(Runes) going into the form and the game

        // RuneImport >> Tokens(obj) or db >> bindingsource >> GameObject
        // >> Forms
        public HashSet<Token> GetTokens;
        public HashSet<Rune> TaygrRuneImport()
        {

            // Tree Type

            // You need another file path for the Rune Names

            /// This is for the rune type
            string path = @"F:\RyuuseiEngine\Mods\TaygrRuneTypes.txt";
           
            /// This is for the rune name
            string path2 = @"F:\RyuuseiEngine\Mods\TaygrRuneNames.txt";

            //// the rune types
            //Importfunction(path);

            //// the rune names
            //Importfunction(path2);

            // Addendum -> from strings to Runes
        //do
        //{

            var StrN = new Rune();
            int FR = Importfunction(path).Count;
            string[] newTName = { };
            int[] NewRId = { };
            string[] RN = { };
            string[] Desc = { };
            decimal[] Pee = { };
            string[] newRName = { };

            //names
            Importfunction(path2).CopyTo(RN);

            //types
            Importfunction(path).CopyTo(newRName);

            int a = 0;

            for (int i = 0; i < FR; i++, a++)
            {

                // push the new rune names into whole new 
                // Runes themselves

                //// Types and id
                StrN.RType = newTName[a];
                StrN.ID = NewRId[a];
                StrN.Price = Pee[a];
                StrN.Description = Desc[a];
                StrN.Name = newRName[a];
                // name
                //TokenSystem.Names = RN[a];

                Rune m = new Rune {RType = newTName[a], ID = NewRId[a], Description = Desc[a], Price = Pee[a]};

                Token _tokend = new Token(StrN.Name, StrN.RType, StrN.ID, StrN.Price, StrN.Description);

                
                Taygr.Add(m);
                GetTokens.Add(_tokend);
            }
            

            return Taygr; // Return the strings here to the "RuneTree" Aggregate
        }

        //to db
        public Token[] RuneToToken()
        {
            object ticket;
            
            int i;
            int y = 0;
            string[] maoi;

            for (i = 0; y < GetTokens.Count; i++, y++)
            {
                //GetTokens.CopyTo(sqlruneDatabase); FInd a solution to this <<<<<<<<<<<<<<
            }

            return null;
        }

        //private SqlRuneDatabase sqlruneDatabase;

    }
}
