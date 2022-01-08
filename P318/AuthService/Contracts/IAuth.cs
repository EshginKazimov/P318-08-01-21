using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthService.Models;

namespace AuthService.Contracts
{
    public interface IAuth
    {
        string GetToken(CredentialModel credential);
    }
}
