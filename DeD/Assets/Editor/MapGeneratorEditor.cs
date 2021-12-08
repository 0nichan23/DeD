using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof (Mapgenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Mapgenerator mapgen = (Mapgenerator)target;
        if (DrawDefaultInspector())
        {
            if (mapgen.AutoUpdate)
            {
                mapgen.GenerateMap();
            }
        }
        
        if (GUILayout.Button("Generate"))
        {
            mapgen.GenerateMap();
        }
    }

}
