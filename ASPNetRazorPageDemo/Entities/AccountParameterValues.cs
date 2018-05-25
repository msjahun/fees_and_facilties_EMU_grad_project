using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class AccountParameterValues
    {
        public AccountParameterValues()
        {
            AccountParameterValuesTranslation = new HashSet<AccountParameterValuesTranslation>();
        }

        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public int ParameterId { get; set; }

        public BankCurrencyTable Currency { get; set; }
        public AccountInformationParameter Parameter { get; set; }
        public ICollection<AccountParameterValuesTranslation> AccountParameterValuesTranslation { get; set; }
    }
}
