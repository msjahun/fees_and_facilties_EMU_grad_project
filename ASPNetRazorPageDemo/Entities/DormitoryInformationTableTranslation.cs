using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class DormitoryInformationTableTranslation
    {
        public int LanguageId { get; set; }
        public int DormitoryInfoNonTransId { get; set; }
        public string Information { get; set; }

        public DormitoryInformationTable DormitoryInfoNonTrans { get; set; }
        public LanguageTable Language { get; set; }
    }
}
