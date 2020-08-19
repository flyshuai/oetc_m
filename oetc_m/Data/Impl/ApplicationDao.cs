using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore.Internal;
using oetc_m.Data.Entity;
using oetc_m.Data.Enum;
using oetc_m.Data.Interface;
using oetc_m.Models.Dto;
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
                if (list[i].RecordCode == num.ToString() && list[i].Status != ApplicationStatus.Exited)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public List<ApplicationRecord> Search(ApplicationSearchDto searchDto)
        {
            var list = Context.ApplicationRecords.ToList();
            if (searchDto.StatusList != null && searchDto.StatusList.Count!=0)
            {
                list = list.Where(p => searchDto.StatusList.Contains(p.Status)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(searchDto.Name))
            {
                list = list.Where(p => p.Name.Equals(searchDto.Name)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(searchDto.PhoneNumber))
            {
                list = list.Where(p => p.PhoneNumber.Equals(searchDto.PhoneNumber)).ToList();
            }
            if(searchDto.AccessControlAddressList!=null && searchDto.AccessControlAddressList.Count != 0)
            {
                list = list.Where(p => searchDto.AccessControlAddressList.Contains(p.AccessControlAddress)).ToList();
            }
            if(searchDto.ApplicationTimeRange!=null && searchDto.ApplicationTimeRange.Count != 0)
            {
                list = list.Where(p => p.ApplicationTime <= searchDto.ApplicationTimeRange[1] && p.ApplicationTime >= searchDto.ApplicationTimeRange[0]).ToList();
            }

            return list;
        }

        public int SingleAdd(ApplicationRecord record)
        {
            Context.ApplicationRecords.Add(record);
            int result = Context.SaveChanges();
            return result;
        }

        public ApplicationRecord SingleGet(int id)
        {
            return Context.ApplicationRecords.SingleOrDefault(p => p.Id == id);
        }

        public ApplicationRecord SingleGetByRecordCode(string code)
        {
            var list = Context.ApplicationRecords.Where(p => p.RecordCode == code && p.Status != ApplicationStatus.Exited);
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
