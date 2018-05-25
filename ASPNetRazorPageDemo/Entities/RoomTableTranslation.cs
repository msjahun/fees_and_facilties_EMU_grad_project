using System;
using System.Collections.Generic;

namespace ASPNetRazorPageDemo.Entities
{
    public partial class RoomTableTranslation
    {
        public int LanguageId { get; set; }
        public int RoomTableNonTransId { get; set; }
        public string RoomType { get; set; }
        public string RoomTitle { get; set; }

        public LanguageTable Language { get; set; }
        public RoomTable RoomTableNonTrans { get; set; }
    }
}
