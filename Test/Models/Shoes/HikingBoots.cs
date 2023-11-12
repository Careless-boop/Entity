
namespace Test.Models.Shoes
{
    internal class HikingBoots : Shoe
    {
        float _traction;
        bool _areWaterproof;
        public float Traction
        {
            get
            {
                return _traction;
            }
            private set
            {
                _traction = value > 1 ? 1 : value < 0 ? 0 : value;
            }
        }
        public bool AreWaterproof { get { return _areWaterproof; } private set { _areWaterproof = value; } }

        public HikingBoots(string name, string brand, decimal price, float traction, bool areWaterproof) : base(name, brand, price)
        {
            Traction = traction;
            _areWaterproof = areWaterproof;
        }

        public override void Show()
        {
            Console.WriteLine($"Hiking Boots -\nBrand: {_brand}\nName: {Name}\nTraction: {_traction}\nWaterproof:{new string(_areWaterproof ? "Yes" : "No")}\nPrice: {Price}");
        }
        public override string ToString()
        {
            return $"Hiking Boots -\nBrand: {_brand}\nName: {Name}\nTraction: {_traction}\nWaterproof:{new string(_areWaterproof ? "Yes" : "No")}\nPrice: {Price}";
        }
    }
}
