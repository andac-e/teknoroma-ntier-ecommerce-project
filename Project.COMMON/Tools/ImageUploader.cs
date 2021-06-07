﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Project.COMMON.Tools
{
    public static class ImageUploader
    {

        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {


            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();

                string[] fileArray = file.FileName.Split('.'); 

                string extension = fileArray[fileArray.Length - 1].ToLower();

                string fileName = $"{uniqueName}.{extension}"; 
                if (extension == "jpg" || extension == "gif" || extension == "png" || extension == "jpeg")
                {
                    //Eger dosya ismi zaten varsa
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1"; //Dosya zaten var kodu
                    }

                    else
                    {
                        string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;

                    }
                }
                else
                {
                    return "2"; //Secilen dosya bir resim degildir...
                }

            }

            else
            {
                return "3"; //Dosya bos kodu
            }


        }
    }
}