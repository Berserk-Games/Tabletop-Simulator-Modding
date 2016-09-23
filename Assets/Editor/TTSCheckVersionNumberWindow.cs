using UnityEngine;
using System.Collections;
using UnityEditor;

public class TTSCheckVersionNumberWindow : EditorWindow {

    public string message;

    void OnEnable()
    {
        minSize = new Vector2(5, 5);
        maxSize = new Vector2(500, 500);
        position = new Rect(Screen.width / 2, Screen.height / 2, 200, 200);
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.padding = new RectOffset(4, 4, 4, 4);
        style.normal.textColor = new Color(0.9f, 0.1f, 0.1f);
        style.fontSize = 22;
        style.wordWrap = true;        

        GUILayout.Label(message, style);

        if (GUILayout.Button("Ok"))
        {
            Application.OpenURL("https://github.com/Knils/Tabletop-Simulator-Modding");
            Close();
        }
    }
}
