using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oetc_m.Data.Entity;
using oetc_m.Data.Enum;
using oetc_m.Data.Interface;
using oetc_m.Helper;
using oetc_m.Models;
using oetc_m.Models.Dto;

namespace oetc_m.RestController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IApplicationDao _applicationDao;

        public ApplicationController(IWebHostEnvironment webHostEnvironment, IApplicationDao applicationDao)
        {
            _webHostEnvironment = webHostEnvironment;
            _applicationDao = applicationDao;
        }

        [HttpPost("submitapplication")]
        public async Task<ReturnObj<ApplicationRecord>> SubmitApplicationAsync()
        {
            //获取前端数据
            var form = Request.Form;
            string address = form["address"];
            string name = form["name"];
            string phoneNumber = form["phoneNumber"];
            string purpose = form["purpose"];
            FormFile imageFile = (FormFile)form.Files[0];

            ReturnObj<ApplicationRecord> returnObj = new ReturnObj<ApplicationRecord>();

            //保存图片
            string fileExt = imageFile.FileName.Split('.')[1]; //文件扩展名，不含“.”
            string newFileName = DateTime.Now.ToString("hh-mm").ToString() + "  "+name + " " + address + "." + fileExt; //随机生成新的文件名
            string fileDir = _webHostEnvironment.WebRootPath + "/enter/" + DateTime.Now.ToString("yyyy-MM-dd");
            string filePath = fileDir + "/" + newFileName;

            bool isImgSave = await ImgHelper.SaveEnterImgAsync(imageFile, fileDir, filePath);

            //图片保存成功后将信息存入数据库
            if (isImgSave)
            {
                Random rNum = new Random();//随机生成类
                int num1 = rNum.Next(1000, 9999);//返回指定范围内的随机数
                while (_applicationDao.IsHaveRecordCode(num1))
                {
                    num1 = rNum.Next(1000, 9999);
                }
                ApplicationRecord applicationRecord = new ApplicationRecord
                {
                    Name = name,
                    AccessControlAddress = address,
                    Purpose = purpose,
                    PhoneNumber = phoneNumber,
                    ApplicationTime = DateTime.Now,
                    Status = ApplicationStatus.AlreadyApplied,
                    EnterPictureSrc = "/enter/" + DateTime.Now.ToString("yyyy-MM-dd") + "/" + newFileName,
                    RecordCode = num1.ToString()
                };
                int excute = _applicationDao.SingleAdd(applicationRecord);
                if (excute > 0)
                {
                    returnObj.Success = true;
                    returnObj.Data = applicationRecord;
                }
                else
                {
                    returnObj.Success = false;
                }
            }
            return returnObj;
        }

        [HttpPost("submitexitphoto")]
        public async Task<ReturnObj<string>> SubmitExitPhotoAsync([FromForm] string recordCode)
        {
            FormFile imageFile = (FormFile)Request.Form.Files[0];
            ReturnObj<string> returnObj = new ReturnObj<string>();
            ApplicationRecord applicationRecord = _applicationDao.SingleGetByRecordCode(recordCode);
            if(applicationRecord == null)
            {
                returnObj.Success = false;
                returnObj.Msg = "申请码错误，请重新输入";
                return returnObj;
            }

            //保存图片
            string fileExt = imageFile.FileName.Split('.')[1]; //文件扩展名，不含“.”
            string newFileName = DateTime.Now.ToString("hh-mm").ToString() + "  " + 
                applicationRecord.Name + " " + applicationRecord.AccessControlAddress + "." + fileExt; //随机生成新的文件名
            string fileDir = _webHostEnvironment.WebRootPath + "/leave/" + DateTime.Now.ToString("yyyy-MM-dd");
            string filePath = fileDir + "/" + newFileName;

            bool isImgSave = await ImgHelper.SaveEnterImgAsync(imageFile, fileDir, filePath);

            
            if (isImgSave)
            {
                applicationRecord.Status = ApplicationStatus.exited;
                applicationRecord.LeaveTime = DateTime.Now;
                applicationRecord.LeavePictureSrc = "/leave/" + DateTime.Now.ToString("yyyy-MM-dd") + "/" + newFileName;
                int excute = _applicationDao.SingleUpdate(applicationRecord);
                if (excute > 0)
                {
                    returnObj.Success = true;
                }
                else
                {
                    returnObj.Success = false;
                }
            }
            return returnObj;   
        }

        [HttpPost("application/query")]
        public ResponsePageObj<ApplicationRecordDto> ApplicationRecordQuery(ApplicationSearchDto searchDto)
        {
            ResponsePageObj<ApplicationRecordDto> res = new ResponsePageObj<ApplicationRecordDto>();

            return res;
        }
    }
}
