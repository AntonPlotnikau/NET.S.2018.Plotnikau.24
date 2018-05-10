using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    public interface IRepository
    {
        void Add(BankAccountDto bankAccountDto);
        void Update(BankAccountDto bankAccountDto);
        bool Remove(string id);
        IEnumerable<BankAccountDto> GetAll();
        BankAccountDto GetAccountById(string id);
    }
}
