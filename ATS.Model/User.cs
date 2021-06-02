using System;

namespace ATS.Model
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public bool Inactive { get; set; }
    }
}
