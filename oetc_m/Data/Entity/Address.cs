using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Data.Entity
{
    [Table("address")]
    public class Address
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("access_control_address_name")]
        public string AccessControlAddressName { get; set; }

        [Column("code")]
        public int Code { get; set; }
    }
}
