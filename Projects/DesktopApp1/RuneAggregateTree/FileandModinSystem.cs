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

        /* //Taygr 
        
        // reference Taygr hash here
        
        // try passing the above hash to a database or better yet a tokenization
        // then send those tokens to a binding source
        // and just use the RuneTree to add categorization and description to
        // the obvious tokens(Runes) going into the form and the game

        // RuneImport >> Tokens(obj) or db >> bindingsource >> GameObject
        */

        private HashSet<Rune> Taygr = new HashSet<Rune> { }; // done
        private HashSet<Rune> Volmir = new HashSet<Rune> { }; 
        private HashSet<Rune> Essenox = new HashSet<Rune> { }; 
        private HashSet<Rune> Daevina = new HashSet<Rune> { }; 

        // >> Forms 
        public HashSet<Token> GetTokens;

        public static Rune StrN { get; internal set; }

        public Token SetR { get; set; }

        // Creation 
        public HashSet<Rune> Daevina1 { get => Daevina; set => Daevina = value; }
        // Essense
        public HashSet<Rune> Essenox1 { get => Essenox; set => Essenox = value; }
        // Projectile
        public HashSet<Rune> Volmir1 { get => Volmir; set => Volmir = value; }
        // Ability
        public HashSet<Rune> Taygr1 { get => Taygr; set => Taygr = value; }

        public HashSet<Rune> TaygrRuneImport()
        {

            // Tree Type

            // You need another file path for the Rune Names

            // This is for the Taygr rune types
            string path = @"F:\RyuuseiEngine\Mods\TaygrRuneTypes.txt";
           
            string path2 = @"F:\RyuuseiEngine\Mods\TaygrRuneNames.txt";

            // This is for the Essenox rune type
            string path3 = @"F:\RyuuseiEngine\Mods\EssenoxRuneTypes.txt";

            string path4 = @"F:\RyuuseiEngine\Mods\EssenoxRuneNames.txt";

            // This is for Volmir
            string path5 = @"F:\RyuuseiEngine\Mods\VolmirRuneTypes.txt";

            string path6 = @"F:\RyuuseiEngine\Mods\VolmirRuneNames.txt";

            // This is for Daevina
            string path7 = @"F:\RyuuseiEngine\Mods\DaevinaRuneTypes.txt";

            string path8 = @"F:\RyuuseiEngine\Mods\DaevinaRuneNames.txt";

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

                Rune m = new Rune {RType = newTName[a], ID = NewRId[a], Description = Desc[a], Price = Pee[a], Name = newRName[a]};

                Token _tokend = new Token(StrN.Name, StrN.RType, StrN.ID, StrN.Price, StrN.Description);
                
                Taygr.Add(m);
                GetTokens.Add(_tokend);
            }

            //to db
            Taygr1.CopyTo(TaygrC);

            return Taygr; // Return the strings here to the "RuneTree" Aggregate
        }

    }
}
