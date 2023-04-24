using WoodPelletsAppLibrary.model;

namespace WoodPelletsAppRESTService.Managers
{
    public class WoodPelletsManager : IWoodPelletsManager
    {
        private static int id = 1;
        private static List<WoodPellet> _woodPellets = new List<WoodPellet>() // Mock data for the website.
        {
            new WoodPellet(id++, "Trægutterne", 100, 4),
            new WoodPellet(id++, "De Flinke Træ", 95, 3),
            new WoodPellet(id++, "Varmefronten", 125, 5),
            new WoodPellet(id++, "Trægutterne", 90, 2),
            new WoodPellet(id++, "De Høje Gutter", 120, 4)
        };

        public WoodPelletsManager()
        {

        }

        public WoodPellet Create(WoodPellet woodPellet)
        {
            if (_woodPellets.Exists(wd => wd.Id == woodPellet.Id))
            {
                throw new ArgumentException("WoodPellet is already in the system");
            }
            woodPellet.Validate();

            woodPellet.Id = id++;

            _woodPellets.Add(woodPellet);
            return woodPellet;
        }

        public List<WoodPellet> GetAll()
        {
            return new List<WoodPellet>(_woodPellets);
        }

        public WoodPellet? GetById(int id)
        {
            return _woodPellets.Find(wd => wd.Id == id);
        }


        public WoodPellet? Update(int id, WoodPellet woodPellet)
        {
            woodPellet.Validate();
            WoodPellet? updatedWoodPellet = _woodPellets.Find(wp => wp.Id == id);
            if (updatedWoodPellet != null)
            {
                updatedWoodPellet.Brand = woodPellet.Brand;
                updatedWoodPellet.Price = woodPellet.Price;
                updatedWoodPellet.Quality = woodPellet.Quality;
            }
            return updatedWoodPellet;
        }
    }
}
