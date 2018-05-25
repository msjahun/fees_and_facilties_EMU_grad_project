using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class DormitoryBankAccountTable
    {
        public DormitoryBankAccountTable()
        {
            BankCurrencyTable = new HashSet<BankCurrencyTable>();
        }

        public int Id { get; set; }
        public int DormitoryId { get; set; }
        public string BankName { get; set; }

        public DormitoriesTable Dormitory { get; set; }
        public ICollection<BankCurrencyTable> BankCurrencyTable { get; set; }
    }
}
