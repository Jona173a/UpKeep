using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpKeepProject.Command.Base;
using UpKeepProject.Model.App;

namespace UpKeepProject.Command.App
{
    public class ReferenceChangeCommand<T> : CommandBase
    {
        protected int? _referrerId;
        protected Action<T> _changeReference;


        public ReferenceChangeCommand(Action<T> changeReference)
        {
            _referrerId = null;
            _changeReference = changeReference;
        }

        public void SetReferrerId(int? id)
        {
            _referrerId = id;
        }

        protected override bool CanExecute()
        {
            return _referrerId != null;
        }

        protected override void Execute()
        {
            if (_referrerId != null)
            {
                T obj = DomainModel.GeCatalog<T>().Read(_referrerId.Value);
                _changeReference(obj);
                DomainModel.GeCatalog<T>().Update(_referrerId.Value, obj);
            }
        }
    }
}
