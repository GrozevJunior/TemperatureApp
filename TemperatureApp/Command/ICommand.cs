
namespace TemperatureApp.Command
{
    public interface ICommand<T>
    {
        void execute(T model);
    }
}
