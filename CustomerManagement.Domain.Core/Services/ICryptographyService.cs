using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Domain.Core.Services
{
    public interface ICryptographyService
    {
        string GetHash(string data);
    }
}
