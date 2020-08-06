using oetc_m.Data.Entity;
using oetc_m.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Data.Impl
{
    public class AddressDao : IAddressDao
    {
        public HomeDbContext Context;

        public AddressDao(HomeDbContext context)
        {
            Context = context;
        }

        public List<Address> GetAddressList()
        {
            return Context.Addresses.ToList();
        }
    }
}
