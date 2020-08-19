using oetc_m.Data.Entity;
using oetc_m.Data.Enum;
using oetc_m.Data.Interface;
using oetc_m.Helper;
using oetc_m.Models;
using oetc_m.Models.Dto;
using oetc_m.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Service.Impl
{
    public class ApplicationService : IApplicationService
    {
        public readonly IApplicationDao _applicationDao;
        public ApplicationService(IApplicationDao applicationDao)
        {
            _applicationDao = applicationDao;
        }

        public ReturnObj<string> CreateExcel(ApplicationSearchDto searchDto, string rootPath)
        {
            try
            {
                List<ApplicationRecord> applicationRecords = _applicationDao.Search(searchDto);

                ExcelHelper.CreatApplicationRecordExcel(applicationRecords,rootPath);
            }
            catch(Exception e)
            {
                throw e;
            }
            return new ReturnObj<string>();
        }

        public ReturnObj<ApplicationRecordDto> GetApplicationDetail(int id)
        {
            ReturnObj<ApplicationRecordDto> res = new ReturnObj<ApplicationRecordDto>();
            ApplicationRecord applicationRecord = _applicationDao.SingleGet(id);
            ApplicationRecordDto applicationRecordDto = new ApplicationRecordDto
            {
                Id = applicationRecord.Id,
                Name = applicationRecord.Name,
                Purpose = applicationRecord.Purpose,
                ApplicationTime = applicationRecord.ApplicationTime,
                AccessControlAddress = applicationRecord.AccessControlAddress,
                LeaveTime = applicationRecord.LeaveTime,
                EnterPictureSrc = "http://localhost:5000" + applicationRecord.EnterPictureSrc,
                LeavePictureSrc = "http://localhost:5000" + applicationRecord.LeavePictureSrc,
                Status = applicationRecord.Status,
                RecordCode = applicationRecord.RecordCode,
                PhoneNumber = applicationRecord.PhoneNumber
            };
            res.Data = applicationRecordDto;
            res.Success = true;
            return res;
        }

        public ResponsePageObj<ApplicationRecordDto> SearchApplication(ApplicationSearchDto searchDto)
        {
            ResponsePageObj<ApplicationRecordDto> res = new ResponsePageObj<ApplicationRecordDto>();
            try
            {
                List<ApplicationRecord> applicationRecords = _applicationDao.Search(searchDto);
                res.Page.TotalCount = applicationRecords.Count;
                res.Page.TotalPages = (int)Math.Ceiling(res.Page.TotalCount / searchDto.PageSize * 1.0);
                res.Data = new List<ApplicationRecordDto>();

                applicationRecords = applicationRecords.Skip(searchDto.CurrentPage * searchDto.PageSize - searchDto.PageSize)
                    .Take(searchDto.PageSize).ToList();
                applicationRecords.ForEach((v) => {
                    ApplicationRecordDto dto = new ApplicationRecordDto
                    {
                        Id = v.Id,
                        Name = v.Name,
                        PhoneNumber = v.PhoneNumber,
                        AccessControlAddress = v.AccessControlAddress,
                        Purpose = v.Purpose,
                        ApplicationTime = v.ApplicationTime,
                        AgreeTime = v.AgreeTime,
                        LeaveTime = v.LeaveTime,
                        EnterPictureSrc = v.EnterPictureSrc,
                        LeavePictureSrc = v.LeavePictureSrc,
                        Status = (ApplicationStatus)v.Status,
                        RecordCode = v.RecordCode
                    };
                    res.Data.Add(dto);
                });
                res.Success = true;
            }
            catch(Exception e)
            {
                res.Msg="系统错误，请联系管理员";
                return res;
            }
            return res;
        }
    }
}
