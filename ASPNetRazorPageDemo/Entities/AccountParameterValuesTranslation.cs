using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class AccountParameterValuesTranslation
    {
        public int LanguageId { get; set; }
        public int AccountParamsValuesNonTransId { get; set; }
        public string Value { get; set; }

        public AccountParameterValues AccountParamsValuesNonTrans { get; set; }
        public LanguageTable Language { get; set; }
    }
}
