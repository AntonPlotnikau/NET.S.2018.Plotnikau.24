using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IAccountCreatorService
    {
        BankAccount Create(AccountType type, string name, string lastname, IBonus bonus, Func<string> generator, bool isClosed = false);
    }
}
