using UpKeepProject.Command.Base;
using UpKeepProject.Viewmodel.Base;

namespace UpKeepProject.Command
{
    public class SetViewStateCommand<TDataViewModel> : CommandBase
    {
        private IPageViewModel<TDataViewModel> _pageViewModel;
        private PageViewModelState _state;

        public SetViewStateCommand(IPageViewModel<TDataViewModel> pageViewModel, PageViewModelState state)
        {
            _pageViewModel = pageViewModel;
            _state = state;
        }

        protected override void Execute()
        {
            _pageViewModel.SetState(_state);
        }
    }
}