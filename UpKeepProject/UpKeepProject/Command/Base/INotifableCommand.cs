using System.Windows.Input;

namespace UpKeepProject.Command.Base
{
    public interface INotifableCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}