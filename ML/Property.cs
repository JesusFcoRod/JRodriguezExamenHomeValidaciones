using System.Net.Sockets;

namespace ML
{
    public class Property
    {
        public int IdProperty { get; set; }
        public string Tittle { get; set; }
        public string Address { get; set; }
        public string Descripcion { get; set; }
        public string Created_at { get; set; }
        public string Update_at { get; set; }
        public string Disable_at { get; set; }
        public string Status { get; set; }

        public List<object> Propertys { get; set; }
    }
}