using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class BankCurrencyTable
    {
        public BankCurrencyTable()
        {
            AccountParameterValues = new HashSet<AccountParameterValues>();
        }

        public int Id { get; set; }
        public int BankId { get; set; }
        public string CurrencyName { get; set; }

        public DormitoryBankAccountTable Bank { get; set; }
        public ICollection<AccountParameterValues> AccountParameterValues { get; set; }
    }
}
