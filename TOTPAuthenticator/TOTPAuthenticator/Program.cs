/// <summary>
/// <href="https://github.com/RobThree/TwoFactorAuth.Net"/>
/// </summary>
namespace TOTPAuthenticator
{
    public class Program
    {
        public static void Main(string[] _)
        {
            var secretKey = "O26NAQVLNNOUUSFJ3UMY5JNDPPEFLZNV";
            var tfa = new TOTP();
            var code = tfa.GetCode(secretKey);
        }
    }
}
