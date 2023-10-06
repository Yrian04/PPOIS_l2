using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PPOIS_l2.Tests")]
namespace PPOIS_l2
{
    internal class ClientBase
    {
        private List<Client> clients = new List<Client>();

        public void CreateClient(string name) => clients.Add(new Client(name));
        public Client? GetClient(string name) => clients.Find(x => x.Name == name);
        public bool IsClientExists(string name) => clients.Exists(x => x.Name == name);
    }
}
