using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberDriver.Models;

namespace UberDriver.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        User FindUserByUsername(string username);
    }
}
