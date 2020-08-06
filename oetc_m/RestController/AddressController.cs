using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oetc_m.Data.Entity;
using oetc_m.Data.Interface;

namespace oetc_m.RestController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressDao _addressDao;

        public AddressController(IAddressDao addressDao)
        {
            _addressDao = addressDao;
        }
        [HttpGet]
        public List<Address> Get()
        {
            List<Address> addresses = _addressDao.GetAddressList();
            return addresses;
        }
    }
}
