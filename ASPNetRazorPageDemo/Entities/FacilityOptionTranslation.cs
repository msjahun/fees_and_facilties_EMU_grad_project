using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class FacilityOptionTranslation
    {
        public int FacilityOptionNonTransId { get; set; }
        public int LanguageId { get; set; }
        public string FacilityOption { get; set; }
        public string FacilityOptionDescription { get; set; }

        public FacilityOption FacilityOptionNonTrans { get; set; }
        public LanguageTable Language { get; set; }
    }
}
