using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class LanguageTable
    {
        public LanguageTable()
        {
            AccountInformationParameterTranslation = new HashSet<AccountInformationParameterTranslation>();
            AccountParameterValuesTranslation = new HashSet<AccountParameterValuesTranslation>();
            DormitoriesTableTranslation = new HashSet<DormitoriesTableTranslation>();
            DormitoryInformationTableTranslation = new HashSet<DormitoryInformationTableTranslation>();
            DormitoryTypeTranslation = new HashSet<DormitoryTypeTranslation>();
            FacilityOptionTranslation = new HashSet<FacilityOptionTranslation>();
            FacilityTableTranslation = new HashSet<FacilityTableTranslation>();
            RoomTableTranslation = new HashSet<RoomTableTranslation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageCode { get; set; }

        public ICollection<AccountInformationParameterTranslation> AccountInformationParameterTranslation { get; set; }
        public ICollection<AccountParameterValuesTranslation> AccountParameterValuesTranslation { get; set; }
        public ICollection<DormitoriesTableTranslation> DormitoriesTableTranslation { get; set; }
        public ICollection<DormitoryInformationTableTranslation> DormitoryInformationTableTranslation { get; set; }
        public ICollection<DormitoryTypeTranslation> DormitoryTypeTranslation { get; set; }
        public ICollection<FacilityOptionTranslation> FacilityOptionTranslation { get; set; }
        public ICollection<FacilityTableTranslation> FacilityTableTranslation { get; set; }
        public ICollection<RoomTableTranslation> RoomTableTranslation { get; set; }
    }
}
