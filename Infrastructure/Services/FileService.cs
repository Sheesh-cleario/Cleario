using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
	public class FileService : IFileService
	{
		public Task<string> AddFileAsync(IFormFile file)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteFileASync(string fileUrl)
		{
			throw new NotImplementedException();
		}
	}
}
