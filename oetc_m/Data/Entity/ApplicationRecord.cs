using oetc_m.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Data.Entity
{
    [Table("application_record")]
    public class ApplicationRecord
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("access_control_address")]
        public string AccessControlAddress { get; set; }
        [Column("purpose")]
        public string Purpose { get; set; }
        [Column("application_time")]
        public DateTime ApplicationTime { get; set; }
        [Column("agree_time")]
        public DateTime AgreeTime { get; set; }
        [Column("leave_time")]
        public DateTime LeaveTime { get; set; }
        [Column("enter_picture")]
        public string EnterPictureSrc { get; set; }
        [Column("leave_picture")]
        public string LeavePictureSrc { get; set; }
        [Column("status")]
        public ApplicationStatus Status { get; set; }
        [Column("record_code")]
        public string RecordCode { get; set; }
    }
}
