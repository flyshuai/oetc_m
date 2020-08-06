using oetc_m.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Data.Interface
{
    public interface IApplicationDao
    {
        int SingleAdd(ApplicationRecord record);
        bool IsHaveRecordCode(int num);
        ApplicationRecord SingleGetByRecordCode(string code);
        int SingleUpdate(ApplicationRecord record);
    }
}
