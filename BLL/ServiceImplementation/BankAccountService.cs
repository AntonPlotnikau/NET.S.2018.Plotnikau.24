using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;
using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class BankAccountService : IBankAccountService
    {
        private IRepository repository;
        private IEnumerable<IValidator<BankAccount>> validators;

        public BankAccountService(IRepository repository, IEnumerable<IValidator<BankAccount>>  validators)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }

        public void Close(string id)
        {
            var account = repository.GetAccountById(id).ToAccount();
            account.Close();
            repository.Update(account.ToAccountDto());
        }

        public void Deposit(string id, decimal money)
        {
            var account = repository.GetAccountById(id).ToAccount();
            account.Deposit(money);
            repository.Update(account.ToAccountDto());
        }

        public void OpenAccount(AccountType type, string name, string lastname, IBonus bonus, Func<string> generator, IAccountCreatorService creator)
        {
            var account = creator.Create(type, name, lastname, bonus, generator);
            if (!ValidateAccount(account))
            {
                throw new InvalidOperationException("account is not valid");
            }

            repository.Add(account.ToAccountDto());
        }

        public void Withdraw(string id, decimal money)
        {
            var account = repository.GetAccountById(id).ToAccount();
            account.Withdraw(money);
            repository.Update(account.ToAccountDto());
        }

        private bool ValidateAccount(BankAccount account)
        {
            foreach (var validator in validators)
            {
                if (!validator.IsValid(account))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
