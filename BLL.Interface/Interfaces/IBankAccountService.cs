using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    public interface IBankAccountService
    {
        void OpenAccount(AccountType type, string name, string lastname, IBonus bonus, Func<string> generator, IAccountCreatorService creator);
        void Close(string id);
        void Deposit(string id, decimal money);
        void Withdraw(string id, decimal money);
    }
}
