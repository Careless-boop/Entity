using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models.Shoes
{
    enum ClosureType
    {
        LaceUp,
        HookAndLoop,
        SlipOn,
        Zip
    }
    enum HeightType
    {
        Low,
        Mid,
        High
    }
    [Table("Sneackers")]
    internal class Sneackers : Shoe
    {
        ClosureType _closure;
        HeightType _height;
        public ClosureType Closure { get { return _closure; } private set { _closure = value; } }
        public HeightType Height { get { return _height; } private set { _height = value; } }

        public Sneackers(string name, string brand, decimal price, ClosureType closure, HeightType height) : base(name, brand, price)
        {
            _closure = closure;
            _height = height;
        }

        public override void Show()
        {
            Console.WriteLine($"Sneackers -\nBrand:{_brand}\nName:{Name}\nClosure Type:{_closure}\nHeight:{_height}\nPrice:{Price}");
        }
        public override string ToString()
        {
            return $"Sneackers -\nBrand:{_brand}\nName:{Name}\nClosure Type:{_closure}\nHeight:{_height}\nPrice:{Price}";
        }
    }
}
