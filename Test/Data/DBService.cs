using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.Shoes;

namespace Test.Data
{
    internal class DBService
    {
        public List<Shoe> GetShoes()
        {
            return new List<Shoe>()
            {
                new SportShoes("Gel-Rocket 11","Asics",3099m,CushioningLevel.MediumPlus,false),
                new Sneackers("180 Tones","Puma",3420m,ClosureType.LaceUp,HeightType.Low),
                new Sandals("Classic Sandal","Crocs",1690m,StrapType.Slides,true),
                new HikingBoots("Terrex Eastrail","Adidas",4490m,0.4f,true),
                new HighHeels("Kabail","Guess",8399m,HeelsType.AnkleStrap,8.5f),
                new SportShoes("Ozweego","Adidas",3799m,CushioningLevel.Medium,false),
                new Sneackers("Air Force 1","Nike",6999m,ClosureType.LaceUp,HeightType.Mid),
                new Sandals("Mono Hilfiger Beach","Tommy Hilfiger",1890m,StrapType.FlipFlops,true),
                new HikingBoots("Cortina Valley","Timberland",8999m,0.6f,true),
                new HighHeels("Rhinnae","Guess",6790m,HeelsType.Platforms,10f),
            };
        }
    }
}
