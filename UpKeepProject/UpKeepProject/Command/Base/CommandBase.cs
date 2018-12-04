﻿using System;
using UpKeepProject.Command.Base;

namespace UpKeepProject.Command.Base
{
    public abstract class CommandBase : INotifableCommand
    {
        public bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        public void Execute(object parameter)
        {
            Execute();
        }


        protected virtual bool CanExecute()
        {
            return true;
        }

        protected abstract void Execute();

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}