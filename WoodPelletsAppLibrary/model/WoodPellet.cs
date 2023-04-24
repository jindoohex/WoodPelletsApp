namespace WoodPelletsAppLibrary.model
{
    public class WoodPellet
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public int Price { get; set; }
        public int Quality { get; set; }

        public WoodPellet()
        {

        }

        public WoodPellet(int id, string brand, int price, int quality)
        {
            Id = id;
            Brand = brand;
            Price = price;
            Quality = quality;
            Validate();

        }

        public bool CheckBrand(string brand)
        {
            if (brand.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Name must be at least two characters.");
            }
            return true;
        }

        public bool CheckQuality(int quality)
        {
            if (quality > 5 || quality < 1)
            {
                throw new ArgumentOutOfRangeException("Quality number must be between one and five.");
            }
            return true;
        }

        public bool Validate()
        {
            bool ok = true;
            try
            {
                CheckBrand(Brand);
                CheckQuality(Quality);
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
            return ok;
        }

        public bool PriceCheck(int price)
        {
            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException("Price must be a positive number.");
            }
            return true;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Brand: {Brand}, Price: {Price}, Quality: {Quality}";
        }
    }
}
