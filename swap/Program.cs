using DNS_Swapper;

namespace swap
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkManagement.setDNS(args[0], args[1]);
        }
    }
}
