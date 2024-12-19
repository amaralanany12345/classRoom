using ClassRoom.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ClassRoom.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly AppDbContext _context;

        public FileService(IWebHostEnvironment environment, AppDbContext context)
        {
            _environment = environment;
            _context = context;
        }

        public AppFiles UploadFile(FileUploadModel fileUploaded)
        {
            var newFile = new AppFiles();
            if (fileUploaded.File != null || fileUploaded.File.Length > 0)
            {
                //throw new ArgumentException("file is not found");
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "files/");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var filePath = Path.Combine(uploadsFolder, fileUploaded.File.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    fileUploaded.File.CopyTo(stream);
                }
                newFile.filePath = filePath;
                newFile.fileName = fileUploaded.File.FileName;
            }
            return newFile;
        }
        public async Task deleteFile(int fileId)
        {
            var file = await _context.appFiles.Where(a => a.id == fileId).FirstOrDefaultAsync();
            if (file == null)
            {
                throw new ArgumentException("file is not found");
            }

            _context.appFiles.Remove(file);
        }
    }
}
