using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BE.Models;

 interface IAuthService
{
    Task<string> Resgister( RegisterData data);
}