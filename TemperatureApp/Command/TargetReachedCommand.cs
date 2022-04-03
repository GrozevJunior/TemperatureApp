using TemperatureApp.Logger;
using TemperatureApp.Model;

namespace TemperatureApp.Command
{
    public class TargetReachedCommand : ICommand<TemperatureModel>
    {
        private ILogger logger;

        public TargetReachedCommand() : this(new ConsoleLogger())
        {

        }

        public TargetReachedCommand(ILogger logger)
        {
            this.logger = logger;
        }

        public void execute(TemperatureModel model)
        {
            this.logger.Log("Target temperature reached");
        }
    }
}
