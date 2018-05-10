using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;

namespace BLL.Mappers
{
    public static class BankAccountMapper
    {
        public static BankAccountDto ToAccountDto(this BankAccount account)
        {
            return new BankAccountDto
            {
                AccountType = account.AccountType.ToString(),
                Id = account.Id,
                Name = account.Person.name,
                Lastname = account.Person.lastname,
                Sum = account.Sum,
                Bonus = account.Bonus,
                BonusType = account.BonusType,
                IsClosed = account.IsClosed
            };
        }

        public static BankAccount ToAccount(this BankAccountDto accountDto)
        {
            throw new NotImplementedException();
        }
    }
}
