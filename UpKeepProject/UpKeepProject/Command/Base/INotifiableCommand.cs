using System.Windows.Input;

namespace UpKeepProject.Command.Base
{
    public interface INotifiableCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}