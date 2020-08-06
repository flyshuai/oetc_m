using oetc_m.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Models.Dto
{
    public class ApplicationRecordDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string AccessControlAddress { get; set; }
        public string Purpose { get; set; }
        public DateTime ApplicationTime { get; set; }
        public DateTime AgreeTime { get; set; }
        public DateTime LeaveTime { get; set; }
        public string EnterPictureSrc { get; set; }
        public string LeavePictureSrc { get; set; }
        public ApplicationStatus Status { get; set; }
        public string RecordCode { get; set; }
    }
}
