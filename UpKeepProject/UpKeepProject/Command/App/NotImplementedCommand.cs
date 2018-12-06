using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpKeepProject.Command.Base;

namespace UpKeepProject.Command.App
{
    public class NotImplementedCommand : CommandBase
    {
        private string _desc;

        public NotImplementedCommand(string desc)
        {
            _desc = desc;
        }

        protected override void Execute()
        {
            throw new NotImplementedException($"Not implemented yet: {_desc}");
        }
    }
}
