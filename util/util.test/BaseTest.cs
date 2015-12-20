using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util.test
{
    abstract class BaseTest
    {
        public abstract void Arrange();
        public abstract void Act();
        public abstract void Assert();
        
        public virtual void Test()
        {
            Arrange();
            Act();
            Assert();
        }
    }
}
