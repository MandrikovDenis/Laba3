using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class ManageClass
    {
        public static int index = 2;

        public static ToConnectControllerInterface GetControllerInterface()
        {
#if DEBUG
            switch (index)
            {
                case 0: throw new NotImplementedException(); break;
                case 1: return new MockToConnectController_NoConnection(); break;
                case 2: return new MockToConnectController_Connection(); break;
            }
            return null;
        }
#else
            throw new NotImplementedException();
#endif

    }

    public class MockSaveDir : SaveDirInterface
    {
        public string Name { get; set; }
    }

    public class MockToConnectController_NoConnection : ToConnectControllerInterface
    {
        public SaveDirInterface getNameDir() { throw new NotImplementedException(); }

        public bool tryConnect() { return false; }

        public bool save(string name) { throw new NotImplementedException(); }

    }
    public class MockToConnectController_Connection : ToConnectControllerInterface
    {
        MockSaveDir nameDir = new MockSaveDir() { Name = "NewDirectory" };
        public SaveDirInterface getNameDir() { return nameDir; }

        public bool tryConnect() { return true; }

        public bool save(string name) { return true; }

    }
}
