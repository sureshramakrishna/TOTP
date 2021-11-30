/// <summary>
/// <href="https://github.com/RobThree/TwoFactorAuth.Net"/>
/// </summary>

using Topshelf;
namespace TOTPAuthenticator
{
    public class Program
    {
        public static void Main(string[] _)
        {
            HostFactory.Run(x =>
            {
                x.Service<SophosVpnService>(s =>
                {
                    s.ConstructUsing(n => new SophosVpnService());
                    s.WhenStarted(n => n.Start());
                    s.WhenStopped(n => n.Stop());
                });
                x.SetServiceName("SophosVpnService");
                x.SetDisplayName("SophosVpnService");
                x.RunAsLocalSystem();
                x.StartAutomatically();
            });
        }
    }
}
