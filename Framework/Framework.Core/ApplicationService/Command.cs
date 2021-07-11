using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Core.ApplicationService
{
    public abstract class Command
    {
        protected Command()
        {
            TimeStamp  = DateTime.Now;
        }

        private DateTime TimeStamp { get; set; }
    }
}
