using System.Threading.Tasks;

namespace PB.Infrastucture.Commands
{
    public interface ICommandDispatcher
    {
         Task DispatchAsync<T>(T command) where T : ICommand;
    }
}