using oetc_m.Models;
using oetc_m.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Service.Interface
{
    public interface IApplicationService
    {
        ResponsePageObj<ApplicationRecordDto> SearchApplication(ApplicationSearchDto searchDto);
    }
}
