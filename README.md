Tabletop Simulator Modding:

This Unity project is for our advanced Tabletop Simulator modders that want to have complete control over their custom objects with additional features. 
Anything that Unity engine provides besides scripting can be exported as an AssetBundle and then reimported into Tabletop Simulator.
This includes full shader / material support, animations, sounds, lights, particles, and much more.

We provide scripting support with a Lua api that can be found here: http://berserk-games.com/knowledgebase/scripting/
This project was made with Unity 5.3.4: https://unity3d.com/get-unity/download/archive

This project contains:

Multiple skys to preview your creations with how they will appear in TTS. <Skys Folder>

Example objects to provide scale (One Unity unit is 1 inch). <Examples Folder>

Scripts to enable advanced functionality. <Scripts Folder>


Steps:

1: Create your object using any built in Unity feature.

2: Attach any provided scripts in the "Scripts" folder for advanced functionality.

3: Create a prefab of that object.

4: Assign that prefab to a unique AssetBundle name.

5: Build your AssetBundles by right clicking on the prefab and then selecting "Build AssetBundles".

6: AssetBundles can be found in your "Tabletop Simulator - Modding/AssetBundles" folder.

7: Upload your AssetBundle to a webhost or in-game to Steam Cloud and use with the Custom AssetBundle object.
