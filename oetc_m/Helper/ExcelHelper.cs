using oetc_m.Data.Entity;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Helper
{
    public class ExcelHelper
    {
        public static void CreatApplicationRecordExcel(List<ApplicationRecord> applicationRecords,string fileRoot)
        {
            //创建一个workbook对象，默认创建03版的Excel
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(fileRoot + "/申请记录导出模板.xlsx");

            //指定版本信息，07及以上版本最多可以插入1048576行数据
            workbook.Version = ExcelVersion.Version2013;

            //获取第一张sheet
            Worksheet sheet = workbook.Worksheets[0];

            int index = 2;
            applicationRecords.ForEach((v) =>
            {
                sheet.Range["A" + index].Text = v.Id.ToString();
                sheet.Range["B" + index].Text = v.Name;
                sheet.Range["C" + index].Text = v.PhoneNumber;
                sheet.Range["D" + index].Text = v.AccessControlAddress;
                sheet.Range["E" + index].Text = v.Purpose;
                sheet.Range["F" + index].Text = v.ApplicationTime.ToString();
                sheet.Range["G" + index].Text = v.LeaveTime.ToString();
                sheet.Range["H" + index].Text = v.EnterPictureSrc;
                sheet.Range["I" + index].Text = v.LeavePictureSrc ?? "";
                index++;
            });



            string fileDir = fileRoot+"/Excel/" + DateTime.Now.ToString("yyyy-MM-dd");
            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }
            string fileName = DateTime.Now.ToString("hh-mm") +"数据导出.xlsx";
            workbook.SaveToFile(fileDir + "/"+ fileName);
        }
    }
}
