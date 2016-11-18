using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace Patterns
{
    //https://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx#basic_pattern
    class BasicDesignPattern: IDisposable       
    {   
        private SafeFileHandle resource;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);            
        }

        public virtual void Dispose(bool disposing)
        {
            if(disposing)
            {

            }
        }
    }
}
