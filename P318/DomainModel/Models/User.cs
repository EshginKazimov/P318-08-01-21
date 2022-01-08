using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Base;

namespace DomainModel.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
