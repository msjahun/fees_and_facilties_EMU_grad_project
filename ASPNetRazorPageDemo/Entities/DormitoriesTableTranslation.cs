using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class DormitoriesTableTranslation
    {
        public int LanguageId { get; set; }
        public int DormitoriesTableNonTransId { get; set; }
        public string DormitoryName { get; set; }
        public string DormitoryAddress { get; set; }
        public string GenderAllocation { get; set; }
        public string RoomsPaymentPeriod { get; set; }

        public DormitoriesTable DormitoriesTableNonTrans { get; set; }
        public LanguageTable Language { get; set; }
    }
}
