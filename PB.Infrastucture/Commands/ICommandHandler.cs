using System.Threading.Tasks;

namespace PB.Infrastucture.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
         Task HandleAsync(T command);
    }
}