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

        public DateTime TimeStamp { get; }
    }
}
