using JSONFileCreate.Models;
using Newtonsoft.Json;
using System.IO;

namespace JSONFileCreate.Service
{
    public class JSONFileService : IJsonFileService
    {
        

        public void CreateJSONFile(string path, PersonalInformation personalInformation)
        {
            if (!File.Exists(path))
            {
                using (var outFile = File.CreateText(path))
                {
                    using (var writer = new JsonTextWriter(outFile))
                    {
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartArray();
                        writer.WriteStartObject();
                        writer.WritePropertyName("FirstName");
                        writer.WriteValue(personalInformation.FName);
                        writer.WritePropertyName("LastName");
                        writer.WriteValue(personalInformation.LName);
                        writer.WriteEndObject();
                        writer.WriteEndArray();
                    }
                }
            }
            else if (File.Exists(path))
            {
                using (var outFile = new StreamWriter(path,append:true))
                { 
                    
                    using (var writer = new JsonTextWriter(outFile))
                    {
                        writer.Formatting = Formatting.Indented;
                        //writer.WriteStartArray();
                        writer.WriteStartObject();
                        writer.WritePropertyName("FirstName");
                        writer.WriteValue(personalInformation.FName);
                        writer.WritePropertyName("LastName");
                        writer.WriteValue(personalInformation.LName);
                        writer.WriteEndObject();
                        //writer.WriteEndArray();
                    }
                }
            }
        }
    }
}
