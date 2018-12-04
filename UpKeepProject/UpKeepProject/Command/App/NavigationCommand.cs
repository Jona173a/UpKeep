using System;
using Windows.UI.Xaml.Controls;
using UpKeepProject.Command.Base;

namespace UpKeepProject.Command
{
    public class NavigationCommand : CommandBase
    {
        private Frame _frame;
        private Type _pageType;
        private Func<bool> _canNavigateFunc;

        public NavigationCommand(Frame frame, Type pageType, Func<bool> canNavigateFunc)
        {
            _frame = frame;
            _pageType = pageType;
            _canNavigateFunc = canNavigateFunc;
        }

        public NavigationCommand(Frame frame, Type pageType) : this(frame, pageType, () => true) { }

        protected override bool CanExecute()
        {
            return _canNavigateFunc.Invoke();
        }
        protected override void Execute()
        {
            _frame.Navigate(_pageType);
        }

    }
}