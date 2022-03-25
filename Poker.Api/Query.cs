using static System.Runtime.InteropServices.RuntimeInformation;

namespace Poker.Api
{
    public class Query
    {
        public string SysInfo =>
          $"{FrameworkDescription} running on {RuntimeIdentifier}";
    }
}
