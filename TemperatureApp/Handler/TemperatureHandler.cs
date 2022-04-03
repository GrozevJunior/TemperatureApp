using TemperatureApp.Command;
using TemperatureApp.Model;

namespace TemperatureApp.Handler
{
    public class TemperatureHandler : IHandler<TemperatureModel>
    {
        private const float TargetTemperature = 20.8f;

        private ICommand<TemperatureModel> printCommand;
        private ICommand<TemperatureModel> targetReachedCommand;

        public TemperatureHandler() : this(new PrintTemperatureCommand(), new TargetReachedCommand())
        {
        }
        public TemperatureHandler(ICommand<TemperatureModel> printCommand, ICommand<TemperatureModel> targetReachedCommand)
        {
            this.printCommand = printCommand;
            this.targetReachedCommand = targetReachedCommand;
        }
        public void Handle(TemperatureModel model)
        {
            this.printCommand.execute(model);

            if (model.Temperature.CompareTo(TargetTemperature) == 0)
            {
                this.targetReachedCommand.execute(model);
            }
        }
    }
}
