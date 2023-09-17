public static class JsonDataService
{
    public static void SaveToJson<T>(string fileName, T data)
    {
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(fileName, json);
    }

    public static T LoadFromJson<T>(string fileName)
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            if (json != null)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                throw new InvalidOperationException("JSON content is null.");
            }
        }
        else
        {
            throw new FileNotFoundException("The JSON file was not found.", fileName);
        }
    }

}
