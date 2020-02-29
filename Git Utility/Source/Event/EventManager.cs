using System.Collections.Generic;
using System.Threading;

namespace GitUtility.Event
{
    /// <summary>
    /// Simple event trigger executor
    /// </summary>
    public class EventManager
    {
        private static EventManager inst = null;
        public static EventManager GetInstance()
        {
            if (inst == null) inst = new EventManager();
            return inst;
        }

        public static void Fire(EventData ed)
        {
            GetInstance().FireEvent(ed);
        }

        public static void Fire(int code)
        {
            GetInstance().FireEvent(new EventData(code));
        }

        // ========================================================
        //          non-static
        // ========================================================

        private List<IEventListener> parts;
        private EventManager()
        {
            parts = new List<IEventListener>();
        }

        public void AddListener(IEventListener el)
        {
            if (parts.Contains(el)) return;
            parts.Add(el);
        }

        public void RemoveListener(IEventListener el)
        {
            if (!parts.Contains(el)) return;
            parts.Remove(el);
        }

        private void FireEvent(EventData ed)
        {
            Thread executor = new Thread(delegate()
            {
                RunTask(ed);
            });
            executor.Start();
        }

        private void RunTask(EventData ed)
        {
            foreach (IEventListener el in parts)
            {
                el.OnEvent(ed);
            }
        }
    }
}
