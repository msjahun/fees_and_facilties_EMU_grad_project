using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class DormitoriesTable
    {
        public DormitoriesTable()
        {
            DormitoriesTableTranslation = new HashSet<DormitoriesTableTranslation>();
            DormitoryBankAccountTable = new HashSet<DormitoryBankAccountTable>();
            RoomTable = new HashSet<RoomTable>();
        }

        public int Id { get; set; }
        public int DormitoryTypeId { get; set; }
        public string RoomPriceCurrency { get; set; }
        public string RoomPriceCurrencySymbol { get; set; }

        public DormitoryType DormitoryType { get; set; }
        public ICollection<DormitoriesTableTranslation> DormitoriesTableTranslation { get; set; }
        public ICollection<DormitoryBankAccountTable> DormitoryBankAccountTable { get; set; }
        public ICollection<RoomTable> RoomTable { get; set; }
    }
}
