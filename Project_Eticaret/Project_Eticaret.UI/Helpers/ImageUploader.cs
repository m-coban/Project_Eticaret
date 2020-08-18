using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Project_Eticaret.UI.Helpers
{
    public class ImageUploader
    {
        public static string UploadSingleImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var uniquename = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);
                var fileArray = file.FileName.Split('.');
                string extention = fileArray[fileArray.Length - 1].ToLower();
                var fileName = uniquename + "." + extention;

                // file.FileName = 'KartalKaan.JPG'
                // fileArray = {"KartalKaan", "JPG"}
                // fileArray.Length = 2
                // fileArray.Length -1 = 1
                // fileArray[0] = "KartalKaal"
                // fileArray[fileArray.Length - 1] = "JPG"
                // extention = jpg
                // fileName = uniquename.jpg

                if (extention == "jpg" || extention == "png" || extention == "jpeg" || extention == "gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+fileName)))
                    {
                        // Eğer server üzerinde aynı isimde resim varsa
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    // Geçerli dosya uzantılarından birine sahip değil(.jpg, .png, .jpeg, .gif)
                    return "2";
                }
            }
            // Dosya boş ise
            return "0";
        }
    }
}