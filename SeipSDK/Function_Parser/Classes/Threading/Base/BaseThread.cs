using System.Threading;

namespace RuntimeFunctionParser.Classes.Threading.Base
{
    public abstract class BaseThread
    {
        public bool IsAlive
        {
            get
            {
                return _thread.IsAlive;
            }
        }

        private Thread _thread;
        protected BaseThread()
        {
            _thread = new Thread(new ThreadStart(RunThread));
        }

        public void Start(object extraParam)
        {
            if (extraParam == null)
            {
                _thread.Start();
                return;
            }
            _thread.Start(extraParam);
        }

        public void Join()
        {
            _thread.Join();
        }

        public abstract void RunThread();
    }
}