using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Accounts
{
    public class SilverAccount : BankAccount
    {
        public SilverAccount(string name, string lastname, IBonus bonus, Func<string> generator, bool isClosed = false)
            : base(name, lastname, bonus, generator, isClosed) { }

        public override AccountType AccountType => AccountType.Silver;

        protected override bool CanBeClosed()
        {
            throw new NotImplementedException();
        }

        protected override void DepositBonuses()
        {
            throw new NotImplementedException();
        }

        protected override void DepositSum()
        {
            throw new NotImplementedException();
        }

        protected override void WithdrawBonuses()
        {
            throw new NotImplementedException();
        }

        protected override void WithdrawSum()
        {
            throw new NotImplementedException();
        }
    }
}
