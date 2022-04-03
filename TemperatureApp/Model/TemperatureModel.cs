namespace TemperatureApp.Model
{
    public class TemperatureModel
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }

        public override string ToString()
        {
            return $"Temperature: {this.Temperature}, Humidity: {this.Humidity}";
        }
    }
}
