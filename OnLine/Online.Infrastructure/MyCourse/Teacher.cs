using System;
using System.Collections.Generic;

namespace Online.Infrastructure.MyCourse
{
    public partial class Teacher
    {
        public int Tid { get; set; }
        public string Tname { get; set; }
        public string Password { get; set; }
        public string Depart { get; set; }
        public int? Type { get; set; }
    }
}
