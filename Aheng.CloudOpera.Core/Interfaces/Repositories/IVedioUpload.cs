using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aheng.CloudOpera.Core.Interfaces.Repositories
{
    public interface IVedioFileServer
    {
        //string UploadFile(Guid userId, IFormFile file);
        //Task<bool> Upload(Guid userId, IFormFile file);
        Task<string> Upload(Guid userId, IFormFile file);
        //decimal GetProgress(Guid vedioId);
    }
}