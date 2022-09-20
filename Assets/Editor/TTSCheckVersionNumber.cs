using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.IO;
using UnityEngine.Networking;

[InitializeOnLoad]
public class TTSCheckVersionNumber {

    [Serializable]
    public class GitHubRelease
    {
        public string url;
        public int id;
        public string tag_name;
        public string target_commitish;
        public string name;
        public bool draft;
        public bool prerelease;
        public string body;
    }
        
    const string unityVersion = "2019.4";
    const string versionPath = "version.txt";

    static TTSCheckVersionNumber()
    {
        //Check Unity Version
        if (!Application.unityVersion.StartsWith(unityVersion))
        {
            Debug.LogError(string.Format("You are using the wrong version of Unity. Should be using Unity {0}. Current version is {1}.", unityVersion, Application.unityVersion));
        }

        UnityWebRequest webRequest = UnityWebRequest.Get("https://api.github.com/repos/Berserk-Games/Tabletop-Simulator-Modding/releases");
        webRequest.SendWebRequest();

        ContinuationManager.Add(() => webRequest.isDone, () =>
        {
            if (webRequest.isNetworkError) //Error
            {
                Debug.LogError("Failed to fetch version number from GitHub: " + webRequest.error);
            }
            else
            {
                //Debug.Log("WWW result : " + www.text);  

                string ourVersion = "";

                if (File.Exists(versionPath))
                {
                    ourVersion = File.ReadAllText(versionPath);
                }
                else
                {
                    Debug.LogError(string.Format("{0} could not be found! Something is wrong with the project. Did you open the project you downloaded from GitHub with Unity?", versionPath));
                    return;
                }

                Version currentVersion = new Version(ourVersion.Replace("v", ""));                      

                try
                {      
                    //Hacky way to get around JsonUtility not working with arrays         
                    GitHubRelease[] releases = JsonHelper.FromJson<GitHubRelease>(webRequest.downloadHandler.text);

                    bool foundRelease = false;

                    for(int i = 0; i < releases.Length; i++)
                    {
                        GitHubRelease release = releases[i];

                        //Debug.Log(JsonUtility.ToJson(release));

                        if(!release.draft && !release.prerelease)
                        {
                            foundRelease = true;                            

                            Version checkVersion = new Version(release.tag_name.Replace("v", ""));

                            if (currentVersion >= checkVersion)
                            {
                                Debug.Log(string.Format("Tabletop-Simulator-Modding project is up to date. Current version is {0}.", ourVersion));
                            }
                            else //Version out of date
                            {
                                string message = string.Format("Tabletop-Simulator-Modding project is out of date. New version is {0}. Current version is {1}.", release.tag_name, ourVersion);

                                Debug.LogError(message);

                                TTSCheckVersionNumberWindow window = ScriptableObject.CreateInstance<TTSCheckVersionNumberWindow>();

                                window.message = message;
                                window.ShowUtility();

                                window.minSize = new Vector2(50, 50);
                                window.maxSize = new Vector2(500, 500);

                                Rect rect = new Rect();
                                rect.width = 450;
                                rect.height = 120;                                

                                rect.center = new Vector2(1920 / 2, 1080 / 2);

                                window.position = rect;
                            }

                            break;
                        }
                    }
                    
                    if(!foundRelease)
                    {
                        Debug.LogError("Couldn't find any releases on GitHub!");
                    }                    
                }
                catch(Exception e)
                {
                    Debug.LogError("Error parsing Json! " + e.Message);
                }
            }

            webRequest.Dispose();
        });
    }     
}
