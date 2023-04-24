using WoodPelletsAppLibrary.model;

namespace WoodPelletsAppRESTService.Managers
{
    public interface IWoodPelletsManager
    {
        WoodPellet Create(WoodPellet woodPellet);
        List<WoodPellet> GetAll();
        WoodPellet? GetById(int id);
        WoodPellet? Update(int id, WoodPellet woodPellet);
    }
}
