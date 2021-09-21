using System;
using System.Collections.Generic;

#nullable disable

namespace JobPortalDI.ProjModel
{
    public partial class Job
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public int? Cid { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public int? Salary { get; set; }
        public string Location { get; set; }
        public string ContactUser { get; set; }
        public string ContactEmail { get; set; }
    }
}
