using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public abstract class BankAccount
    {
        private readonly string id;
        private Person person;
        private decimal sum;
        private readonly IBonus bonus;
        private bool isClosed;

        public BankAccount(string name, string lastname, IBonus bonus, Func<string> generator, bool isClosed = false)
        {
            this.id = generator() ?? throw new ArgumentNullException(nameof(generator));
            this.person.name = name ?? throw new ArgumentNullException(nameof(name));
            this.person.lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
            this.bonus = bonus ?? throw new ArgumentNullException(nameof(bonus));
            this.isClosed = isClosed;
        }       

        public string Id => this.id;

        public Person Person => person;

        public decimal Sum => sum;

        public abstract AccountType AccountType { get; }

        public decimal Bonus => bonus.BonusSum;

        public string BonusType => bonus.GetType().Name;

        public bool IsClosed => isClosed;

        public void Close()
        {
            if (!CanBeClosed()) 
            {
                throw new InvalidOperationException("this account can not be closed");
            }

            isClosed = true;
        }

        public void Withdraw(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sum));
            }

            WithdrawSum();
            WithdrawBonuses();
        }

        public void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sum));
            }

            DepositSum();
            DepositBonuses();
        }

        protected abstract bool CanBeClosed();

        protected abstract void WithdrawBonuses();

        protected abstract void WithdrawSum();

        protected abstract void DepositBonuses();

        protected abstract void DepositSum();
    }
}
