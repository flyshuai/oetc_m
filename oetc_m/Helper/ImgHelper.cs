using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Helper
{
    public class ImgHelper
    {

        public ImgHelper()
        {
            
        }
        public static async Task<bool> SaveEnterImgAsync(FormFile imageFile,string fileDir, string filePath)
        {
            if (!Directory.Exists(fileDir))
            {
                Directory.CreateDirectory(fileDir);
            }
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                return true;
            }
            catch (Exception e)
            {
                
            }
            return false;
        }
    }
}
