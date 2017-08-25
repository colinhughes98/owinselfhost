using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;


namespace OwinSelfHost.Middleware
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class ColMiddleWare
    {       
        private readonly AppFunc _next;

        public ColMiddleWare(AppFunc next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {           
            Debug.WriteLine("MiddleWare started");
            await _next(environment);
            Debug.WriteLine("Middleware completed....");
        }
       
    }
}