using System;
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
		public AboutSettings AboutSettings { get; set; }
		public PartnerSettings PartnerSettings { get; set; }
		public ReviewSettings ReviewSettings { get; set; }
		public FleetSettings FleetSettings { get; set; }
		public string CreateSubFolders(string basePath, string entiyName, string uniqueFolderName, string folderName)
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
	public class FleetSettings
	{
		public string FleetName { get; set; }
		public string Photos { get; set; }
	}
	public class PartnerSettings
	{
		public string PartnerName { get; set; }
		public string Photos { get; set; }
	}

	public class TeamSettings
	{
		public string TeamName { get; set; }
		public string Photos { get; set; }
	}
	public class AboutSettings
	{
		public string AboutName { get; set; }
		public string Photos { get; set; }
	}
	public class ReviewSettings
	{
		public string ReviewName { get; set; }
		public string Photos { get; set; }
	}
}
