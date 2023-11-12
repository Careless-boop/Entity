using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test.Models.Shoes
{
    enum StrapType
    {
        FlipFlops,
        Gladiator,
        Slides,
        Strappy
    }
    internal class Sandals : Shoe
    {
        StrapType _strap;
        bool _areOpenToe;

        [Column(TypeName = "nvarchar(20)")]
        [EnumDataType(typeof(StrapType))]
        public StrapType Strap { get { return _strap; } private set { _strap = value; } }
        public bool AreOpenToe { get { return _areOpenToe; } private set { _areOpenToe = value; } }

        public Sandals(string name, string brand, decimal price, StrapType strap, bool areOpenToe) : base(name, brand, price)
        {
            _strap = strap;
            _areOpenToe = areOpenToe;
        }

        public override void Show()
        {
            Console.WriteLine($"Sandals -\nBrand:{_brand}\nName:{Name}\nOpen Toe:{new string(!_areOpenToe ? "No" : "Yes")}\nStrap Type:{_strap}\nPrice:{Price}");
        }
        public override string ToString()
        {
            return $"Sandals -\nBrand:{_brand}\nName:{Name}\nOpen Toe:{new string(!_areOpenToe ? "No" : "Yes")}\nStrap Type:{_strap}\nPrice:{Price}";
        }
    }
}
