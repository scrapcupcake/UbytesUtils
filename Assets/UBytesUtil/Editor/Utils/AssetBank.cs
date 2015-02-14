using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UBytes.Utils
{
	public class AssetBank
	{
		static AssetBank _instance;
		public static AssetBank instance {
			get {
				if (_instance == null)
					_instance = new AssetBank ();
				return _instance;
			}
		}

		public string defaultTitle { get; set; }
		public string defaultExtension { get; set; }
		public string defaultDirectory { get; set; }

		public AssetBank (string title = null, string extension = null, string directory = null)
		{
			defaultTitle = string.IsNullOrEmpty (title) ? "Save Asset" : title;
			defaultExtension = string.IsNullOrEmpty (extension) ? "asset" : extension;
			defaultDirectory = string.IsNullOrEmpty (directory) ? Application.dataPath : directory; 
			//TODO: Make sure path is within the project.
		}

		/// <summary>
		/// Like EditorUtility.SaveFilePanelInProject, but also parses the path to be project relative, for things like AssetDatabase.CreateAsset, and
		/// uses the defaults from AssetBank.default* accessors.
		/// </summary>
		/// <returns>The path, project relative.</returns>
		public string ProjectSaveFilePanel (string defaultName, string directory = "", string title = "", string extension = "")
		{
			if (directory.Length == 0)
				directory = defaultDirectory;			
			if (title.Length == 0)
				title = defaultTitle;
			if (extension.Length == 0)
				extension = defaultExtension;

			string fullPath = EditorUtility.SaveFilePanel (title, directory, defaultName, extension);
			return FileUtil.GetProjectRelativePath (fullPath);
		}

		public void SaveAsset (UnityEngine.Object asset, string defaultName, string directory = "", string title = "", string extension = "")
		{
			string path = ProjectSaveFilePanel (defaultName, directory, title, extension);
			AssetDatabase.CreateAsset (asset, path);
		}
	}
}
