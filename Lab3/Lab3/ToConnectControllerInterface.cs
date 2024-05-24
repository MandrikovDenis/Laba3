using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public interface ToConnectControllerInterface
    {
        public bool tryConnect();
        public SaveDirInterface getNameDir();
        public bool save(string name);
    }
}
