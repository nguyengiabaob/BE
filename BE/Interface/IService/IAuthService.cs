using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BE.Models;

public interface IAuthService
{
    public Task<string> Resgister(RegisterData data);
}