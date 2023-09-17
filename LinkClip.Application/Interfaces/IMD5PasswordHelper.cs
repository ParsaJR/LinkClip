using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkClip.Application.Interfaces
{
    public interface IMD5PasswordHelper
    {
        string EncodePasswordMd5(string password);
    }
}
