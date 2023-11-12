using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Test.Models.Shoes
{
    enum HeelsType
    {
        Kitten,
        Block,
        Stiletto,
        Platforms,
        AnkleStrap
    }
    internal class HighHeels : Shoe
    {
        HeelsType _heels;
        float _height;
        [Column(TypeName = "nvarchar(20)")]
        [EnumDataType(typeof(HeelsType))]
        public HeelsType Heels { get { return _heels; } private set { _heels = value; } }
        public float Height { get { return _height; } private set { _height = value; } }

        public HighHeels(string name, string brand, decimal price, HeelsType heels, float height) : base(name, brand, price)
        { 
            _heels = heels;
            _height = height;
        }

        public override void Show()
        {
            Console.WriteLine($"High Heels -\nBrand: {_brand}\nName: {Name}\nType: {_heels}\nHeels Height: {_height} cm\nPrice: {Price}");
        }
        public override string ToString()
        {
            return $"High Heels -\nBrand: {_brand}\nName: {Name}\nType: {_heels}\nHeels Height: {_height} cm\nPrice: {Price}";
        }
    }
}
