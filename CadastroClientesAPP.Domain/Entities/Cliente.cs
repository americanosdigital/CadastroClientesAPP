using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientesAPP.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Lastname { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; }

        public Cliente(string name, string lastname, int age, string address)
        {
            Id = Guid.NewGuid();
            Name = name;
            Lastname = lastname;
            Age = age;
            Address = address;
        }
    }
}
