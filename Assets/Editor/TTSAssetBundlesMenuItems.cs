using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System;

namespace AssetBundles
{
	public class TTSAssetBundlesMenuItems
	{	
		[MenuItem ("Assets/Build AssetBundles")]
		static public void BuildAssetBundles ()
		{
            string outputPath = "AssetBundles";

            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);

            try
            {
                BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.selectedStandaloneTarget);

                //Add .unity3d to AssetBundles and deletes unnecessary files
                string[] files = Directory.GetFiles(outputPath);

                foreach (string path in files)
                {                    
                    if (Path.GetFileName(path) == "AssetBundles" || path.EndsWith(".manifest"))
                    {
                        File.Delete(path);
                    }
                    else if (!Path.HasExtension(path))
                    {
                        string pathPlusUnity = path + ".unity3d";

                        if (File.Exists(pathPlusUnity))
                        {
                            File.Delete(pathPlusUnity);
                        }

                        File.Move(path, pathPlusUnity);
                    }
                }

                Debug.Log("Build complete! AssetBundles can be found in the 'Tabletop-Simulator-Modding/AssetBundles' folder.");
            }
            catch(Exception e)
            {
                Debug.LogError("Error building AssetBundles: " + e.Message);
            }           
        }        
	}
}