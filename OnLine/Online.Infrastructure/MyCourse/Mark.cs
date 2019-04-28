using System;
using System.Collections.Generic;

namespace Online.Infrastructure.MyCourse
{
    public partial class Mark
    {
        public int Mid { get; set; }
        public int? Sid { get; set; }
        public string Sname { get; set; }
        public int? Score { get; set; }
        public string Depart { get; set; }
        public string Major { get; set; }
        public string Class { get; set; }
        public DateTime? Date { get; set; }
    }
}
