using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class FacilityTableTranslation
    {
        public int LanguageId { get; set; }
        public int FacilityTableNonTransId { get; set; }
        public string FacilityTitle { get; set; }
        public string FacilityDescription { get; set; }

        public FacilityTable FacilityTableNonTrans { get; set; }
        public LanguageTable Language { get; set; }
    }
}
