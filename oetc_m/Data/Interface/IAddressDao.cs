using oetc_m.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Data.Interface
{
    public interface IAddressDao
    {
        //取全部记录
        List<Address> GetAddressList();
    }
}
