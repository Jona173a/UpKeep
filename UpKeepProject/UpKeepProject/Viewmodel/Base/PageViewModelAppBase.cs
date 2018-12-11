using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Windows.UI;
using Windows.UI.Xaml.Media;
using UpKeepProject.Command.App;
using UpKeepProject.Command.Base;
using UpKeepProject.Data.Base;
using UpKeepProject.Model.App;
using UpKeepProject.Model.Base;
using UpKeepProject.Command;

namespace UpKeepProject.Viewmodel.Base
{
    public class PageViewModelAppBase<T, TDataViewModel> : PageViewModelBase<T, TDataViewModel>
        where T : IDomainClass, new()
        where TDataViewModel : class, IDataViewModel<T>, new ()
    {
        private Dictionary<PageViewModelState, Dictionary<string, CommandBase>> _allCommands;


        public PageViewModelAppBase()
        {
            CommandBase deleteCmd = new DeleteCommand<T, TDataViewModel>(_catalog, this);
            CommandBase createCmd = new CreateCommand<T, TDataViewModel>(_catalog, this);
            CommandBase updateCmd = new UpdateCommand<T, TDataViewModel>(_catalog, this);

            CommandBase setReadDeleteViewStateCmd = new SetViewStateCommand<TDataViewModel>(this, PageViewModelState.ReadDelete);
            CommandBase setCreateViewStateCmd = new SetViewStateCommand<TDataViewModel>(this, PageViewModelState.Create);
            CommandBase setUpdateViewStateCmd = new SetViewStateCommand<TDataViewModel>(this, PageViewModelState.Update);

            Dictionary<string, CommandBase> readDeleteCommands = new Dictionary<string, CommandBase>();
            readDeleteCommands.Add("Create", setCreateViewStateCmd);
            readDeleteCommands.Add("Update", setUpdateViewStateCmd);
            readDeleteCommands.Add("Delete", deleteCmd);

            Dictionary<string, CommandBase> createCommands = new Dictionary<string, CommandBase>();
            createCommands.Add("Read/Delete", setReadDeleteViewStateCmd);
            createCommands.Add("New", setCreateViewStateCmd);
            createCommands.Add("Save", createCmd);

            Dictionary<string, CommandBase> updateCommands = new Dictionary<string, CommandBase>();
            updateCommands.Add("Read/Delete", setReadDeleteViewStateCmd);
            updateCommands.Add("Create", setCreateViewStateCmd) ;
            updateCommands.Add("Update", updateCmd);

            _allCommands = new Dictionary<PageViewModelState, Dictionary<string, CommandBase>>();
            _allCommands.Add(PageViewModelState.ReadDelete, readDeleteCommands);
            _allCommands.Add(PageViewModelState.Create, createCommands);
            _allCommands.Add(PageViewModelState.Update, updateCommands);

            _viewStateChanged += OnViewStateHasChanged;

            SetState(PageViewModelState.ReadDelete);
        }


        public List<string> ViewCommandsDesc
        {
            get { return CurrentCommands.Keys.ToList(); }
        }

        public List<CommandBase> ViewCommandsObj
        {
            get { return CurrentCommands.Values.ToList(); }
        }

        public string ViewStateDesc
        {
            get
            {
                string header = "Tilstand: ";
                if (_state == PageViewModelState.ReadDelete) header += "Read/Delete";
                if (_state == PageViewModelState.Create) header += "Create";
                if (_state == PageViewModelState.Update) header += "Update";
                return header;
            }
        }

        public void ChangedState()
        {
            if (_state == PageViewModelState.ReadDelete)
            {

            }
        }

        public SolidColorBrush BackgroundColorDetails
        {
            get { return new SolidColorBrush(EnabledStateDetails ? Colors.White : Colors.GhostWhite); }
        }

        private Dictionary<string, CommandBase> CurrentCommands
        {
            get { return _allCommands[_state]; }
        }

        protected override ICatalog<T> GetCatalog()
        {
            return DomainModel.GeCatalog<T>();
        }

        protected override void NotifyCommands()
        {
            foreach (var cmd in CurrentCommands.Values)
            {
                cmd.RaiseCanExecuteChanged();
            }
        }

        private void OnViewStateHasChanged(PageViewModelState newState)
        {
            OnPropertyChanged(nameof(ViewCommandsDesc));
            OnPropertyChanged(nameof(ViewCommandsObj));
            OnPropertyChanged(nameof(ViewStateDesc));
        }
    }
}