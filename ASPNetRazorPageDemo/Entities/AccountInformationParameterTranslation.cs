﻿using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class AccountInformationParameterTranslation
    {
        public int AccountInfoNonTransId { get; set; }
        public int LanguageId { get; set; }
        public string Parameter { get; set; }

        public AccountInformationParameter AccountInfoNonTrans { get; set; }
        public LanguageTable Language { get; set; }
    }
}
