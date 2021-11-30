using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophosVpnService
{
    public class Service
    {
        public void Start()
        {
            var secretKey = "O26NAQVLNNOUUSFJ3UMY5JNDPPEFLZNV";
            var tfa = new TOTP();
            var code = tfa.GetCode(secretKey);
        }
        public void Stop()
        {
            Console.WriteLine("Stopping Service");
        }
    }
}
