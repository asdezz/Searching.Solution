

namespace SearchingLibrary
{
    using System;
    using System.Collections.Generic;
  public  class AnnFilter
    {
        public int Category_id { get; set; }
        public Nullable<int> Country_id { get; set; }
        public Nullable<int> City_id { get; set; }
        public Nullable<int> Areas_id { get; set; }
        public Nullable<char> Gender_user { get; set; }
        public Nullable<DateTime> MinDateAnnouncing { get; set; }
        public Nullable<DateTime> MaxDateAnnouncing { get; set; }
        public Nullable<DateTime> MinDateBirthday { get; set; }
        public Nullable<DateTime> MaxDateBirthday { get; set; }
        public Nullable<bool> Popular { get; set; }
        public Nullable<bool> DateSort { get; set; }
    }
}