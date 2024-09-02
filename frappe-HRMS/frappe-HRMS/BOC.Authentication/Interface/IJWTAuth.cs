using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOC.Authentication.Interface
{
    public interface IJWTAuth
    {
        string Authentication(string username, string password);
    }
}
