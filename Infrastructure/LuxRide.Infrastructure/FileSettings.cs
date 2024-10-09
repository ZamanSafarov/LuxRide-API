﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxRide.Infrastructure
{
	public class FileSettings
	{
		public string Path { get; set; }
		public TeamSettings TeamSettings { get; set; }
		public string CreateSubFolfers(string basePath, string entiyName, string uniqueFolderName, string folderName)
		{
			var path = System.IO.Path.Combine(basePath, entiyName);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			string uniquePath = System.IO.Path.Combine(path, uniqueFolderName);
			if (!Directory.Exists(uniquePath))
			{
				Directory.CreateDirectory(uniquePath);
			}
			string documentpath = System.IO.Path.Combine(uniquePath, folderName);
			if (!Directory.Exists(documentpath))
			{
				Directory.CreateDirectory(documentpath);
			}
			return documentpath;
		}
	}

	public class TeamSettings
	{
		public string TeamName { get; set; }
		public string Photos { get; set; }
	}
}
