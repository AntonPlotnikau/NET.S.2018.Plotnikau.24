using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class BankAccountDto
    {
        public string Id { get; set; }

        public string AccountType { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public decimal Sum { get; set; }

        public decimal Bonus { get; set; }

        public string BonusType { get; set; }

        public bool IsClosed { get; set; }
    }
}
