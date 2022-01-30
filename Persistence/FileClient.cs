using System.Text.Json;

namespace Persistence
{
    public class FileClient : IFileClient
    {
        public void Append<T>(string fileName, T item)
        {
            var jsonItems = JsonSerializer.Serialize(item);

            File.AppendAllLines(fileName,new[] {jsonItems});
        }

        public void DeleteFileContents(string fileName)
        {
            File.WriteAllLines(fileName, Array.Empty<string>());
        }

        public IEnumerable<T> ReadAll<T>(string fileName)
        {            
                var jsonItems = File.ReadAllLines(fileName);
                
                return jsonItems.Select(jsonItem => JsonSerializer.Deserialize<T>(jsonItem));            
        }

        public void WriteAll<T>(string fileName, IEnumerable<T> items)
        {
            var jsonItems = items.Select(item => JsonSerializer.Serialize(item));

            File.WriteAllLines(fileName, jsonItems);
        }
    }
}
