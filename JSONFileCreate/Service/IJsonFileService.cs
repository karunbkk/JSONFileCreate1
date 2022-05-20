using JSONFileCreate.Models;

namespace JSONFileCreate.Service
{
    public interface IJsonFileService
    {
        public void CreateJSONFile(string path,PersonalInformation personalInformation);
    }
}
