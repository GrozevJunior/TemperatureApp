using System.Text;
using System.Text.Json;
using TemperatureApp.Model;

namespace TemperatureApp.Parser
{
    public class TemperatureModelParser : IParser<TemperatureModel>
    {
        public TemperatureModel ParseInput(byte[] rawInput)
        {
            string jsonData = Encoding.UTF8.GetString(rawInput);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<TemperatureModel>(jsonData, options);
        }
    }
}
