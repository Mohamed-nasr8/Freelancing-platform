using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdsourcing.BL.Helper
{
    public class UploadFiles
    {
        public static string UploadFile(string LocalPath, IFormFile File)
        {

            try
            {
                // 1 ) Get Directory
                string FilePath = Directory.GetCurrentDirectory() + LocalPath;


                //2) Get File Name
                string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);


                // 3) Merge Path with File Name
                string FinalPath = Path.Combine(FilePath, FileName);


                //4) Save File As Streams "Data Overtime"

                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    File.CopyTo(Stream);
                }


                return FileName;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static string RemoveFile(string FolderName, string FileName)
        {
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/Files/" + FolderName + "/" + FileName))
                {
                    File.Delete(Directory.GetCurrentDirectory() + "/" + FolderName + "/" + FileName);
                }
                return "File Deleted";
            }
            catch (Exception ex)
            {
                return "File Deleted";
            }
        }

        //public static async Task<string> UpdateFileAsync(string FolderName, string CurrentFileName, IFormFile newFile)
        //{
        //    try
        //    {
        //        // Check if the file exists
        //        if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", FolderName, CurrentFileName)))
        //        {
        //            // Generate a unique file name for the new file
        //            string newFileName = Guid.NewGuid() + Path.GetFileName(newFile.FileName);

        //            // Get the full path to the new file
        //            string newFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", FolderName, newFileName);

        //            // Copy the new file to the target directory
        //            using (var stream = new FileStream(newFilePath, FileMode.Create))
        //            {
        //                await newFile.CopyToAsync(stream);
        //            }

        //            // Delete the current file
        //            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", FolderName, CurrentFileName));

        //            return newFileName;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception
        //        return null;
        //    }
        //}
        public static string UpdateFile(string existingFileName, IFormFile newFile, string folderName)
        {
            // Delete existing file
            RemoveFile(folderName, existingFileName);

            // Save new file
            return UploadFile(folderName,newFile);
        }

    }
}
