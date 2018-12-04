using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using UpKeepProject.View.Domain;
using UpKeepProject.Command;

namespace UpKeepProject.Viewmodel.App
{
    public class MainPageViewModel
    {
        private static Frame _appFrame;
        private static Dictionary<string, NavigationCommand> _navigationCommands;

        private NavigationViewItem _selectedMenuItem;

        public MainPageViewModel()
        {
            _selectedMenuItem = null;
        }

        public NavigationViewItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                if (_selectedMenuItem == null) return;

                string tag = _selectedMenuItem.Tag.ToString();
                if (!_navigationCommands.ContainsKey(tag))
                {
                    throw new ArgumentException(NoNavigationCommandMessage(tag));
                }

                _navigationCommands[tag].Execute(null);

            }
        }
        public static void SetAppFrame(Frame appFrame)
        {
            _appFrame = appFrame;
            _navigationCommands = new Dictionary<string, NavigationCommand>();
            AddCommands();
        }

        private static void AddCommands()
        {
            _navigationCommands.Add("OpenPersonaleView", CreateNavigationCommand(typeof(PersonaleView)));
            _navigationCommands.Add("OpenKundeView", CreateNavigationCommand(typeof(KundeView)));
        }

        private static NavigationCommand CreateNavigationCommand(Type viewType)
        {
            return new NavigationCommand(_appFrame, viewType);
        }

        private static string NoNavigationCommandMessage(string tag)
        {
            return $"No navigation command associated with Tag {tag}";
        }
    }
}