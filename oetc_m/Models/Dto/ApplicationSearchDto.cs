using oetc_m.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Models.Dto
{
    public class ApplicationSearchDto
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public List<string> AccessControlAddressList { get; set; }

        public List<ApplicationStatus> StatusList { get; set; }

        public List<DateTime> ApplicationTimeRange { get; set; }

        public DateTime AgreeTime { get; set; }

        public DateTime LeaveTime { get; set; }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }
    }
}
