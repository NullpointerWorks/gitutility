using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitUtility.Event
{
    public interface IEventListener
    {
        void OnEvent(EventData ed);
    }
}
