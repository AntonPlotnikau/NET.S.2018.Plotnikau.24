using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using BLL.Interface.Accounts;

namespace BLL.ServiceImplementation
{
    public class BankAccountFactory : IAccountCreatorService
    {
        private readonly Dictionary<AccountType, System.Func<BankAccount>> map =
            new Dictionary<AccountType, System.Func<BankAccount>>();

        public BankAccount Create(AccountType type, string name, string lastname, IBonus bonus, Func<string> generator, bool isClosed = false)
        {
            Configurate(name, lastname, bonus, generator, isClosed);
            var creator = GetCreator(type);
            if (creator == null)
            {
                throw new InvalidOperationException(nameof(type) + "is not provided");
            }

            return creator();
        }

        private void Configurate(string name, string lastname, IBonus bonus, Func<string> generator, bool isClosed)
        {
            map[AccountType.Base] = () => new BaseAccount(name, lastname, bonus, generator, isClosed);
            map[AccountType.Silver] = () => new SilverAccount(name, lastname, bonus, generator, isClosed);
        }

        private Func<BankAccount> GetCreator(AccountType type)
        {
            System.Func<BankAccount> creator;
            map.TryGetValue(type, out creator);
            return creator;
        }
    }
}
