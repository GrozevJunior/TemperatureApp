using TemperatureApp.Model;
using TemperatureApp.Logger;

namespace TemperatureApp.Command
{
    public class PrintTemperatureCommand : ICommand<TemperatureModel>
    {
        private ILogger logger;

        public PrintTemperatureCommand() : this(new ConsoleLogger())
        {

        }

        public PrintTemperatureCommand(ILogger logger)
        {
            this.logger = logger;
        }

        public void execute(TemperatureModel model)
        {
            this.logger.Log(model.ToString());
        }
    }
}
