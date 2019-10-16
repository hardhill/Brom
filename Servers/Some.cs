using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brom.Servers
{
    class Some
    {
        private bool _running;
        private long _cnt;

        public bool Running {
            get { return _running; }
        } 

        public delegate void ChangeCount(long e);
        public event ChangeCount OnChangeCount;

        public Some()
        {

        }

        async public Task StartAsync()
        {
           
            await Task.Run(() => {
                _running = true;
                while (_running)
                {
                    _cnt++;
                    OnChangeCount(_cnt);
                    Thread.Sleep(100);
                }
            });
            
        }
        public void Stop()
        {
            _running = false;
        }
    }
}
