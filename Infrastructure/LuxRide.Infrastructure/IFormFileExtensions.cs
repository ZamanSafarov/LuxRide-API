using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Infrastructure
{
	public static class IFormFileExtensions
	{
		public static async Task<(string path, string fileName)> SaveAsync(this IFormFile file, string path)
		{

			if (!Directory.Exists(path))
			{ Directory.CreateDirectory(path); }
			string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
			string resultPath = Path.Combine(path, fileName);
			using (var fileStream = new FileStream(resultPath, FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}
			return ($"{path}/{fileName}", fileName);
		}
		public static bool IsImage(this IFormFile file)
		{
			string allowedExtension = "image/";
			string fileExtension = Path.GetExtension(file.ContentType).ToLower();
			return allowedExtension.Contains(fileExtension);
		}
	}

}
