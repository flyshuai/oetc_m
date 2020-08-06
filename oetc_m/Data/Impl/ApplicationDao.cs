using Microsoft.EntityFrameworkCore.Internal;
using oetc_m.Data.Entity;
using oetc_m.Data.Enum;
using oetc_m.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Data.Impl
{
    public class ApplicationDao : IApplicationDao
    {
        public HomeDbContext Context;
        public ApplicationDao(HomeDbContext context)
        {
            Context = context;
        }

        public bool IsHaveRecordCode(int num)
        {
            List<ApplicationRecord> list = Context.ApplicationRecords.ToList();
            bool flag = false;
            for(int i = 0; i < list.Count; i++)
            {
                if (list[i].RecordCode == num.ToString() && list[i].Status != ApplicationStatus.exited)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public int SingleAdd(ApplicationRecord record)
        {
            Context.ApplicationRecords.Add(record);
            int result = Context.SaveChanges();
            return result;
        }

        public ApplicationRecord SingleGetByRecordCode(string code)
        {
            var list = Context.ApplicationRecords.Where(p => p.RecordCode == code && p.Status != ApplicationStatus.exited);
            if(list!=null && list.Count() > 0)
            {
                return list.FirstOrDefault();
            }
            return null;
        }

        public int SingleUpdate(ApplicationRecord record)
        {
            Context.ApplicationRecords.Update(record);
            int result = Context.SaveChanges();
            return result;
        }
    }
}
