using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProfanityScanner.Business.Database
{
    public partial class BadWords
    {
        public int BadWordId { get; set; }
        public string Word { get; set; }
    }
}
