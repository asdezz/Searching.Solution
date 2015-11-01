

namespace SearchingLibrary
{
    using System;
    using System.Collections.Generic;
  public  class AnnFilter
    {
        public int Category_id { get; set; }
        public int? Country_id { get; set; }
        public int? City_id { get; set; }
        public int? Areas_id { get; set; }
        public char? Gender_user { get; set; }
        public DateTime? DateAnnouncing { get; set; }
        public DateTime? MinDateBirthday { get; set; }
        public DateTime? MaxDateBirthday { get; set; }
        public bool? Popular { get; set; }
        public bool? DateSort { get; set; }
    }
}