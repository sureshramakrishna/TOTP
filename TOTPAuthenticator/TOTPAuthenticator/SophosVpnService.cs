namespace TOTPAuthenticator
{
    public class SophosVpnService
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
