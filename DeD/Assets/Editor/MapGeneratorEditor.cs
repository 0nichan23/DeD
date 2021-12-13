using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Mapgenerator))]
public class MapGeneratorEditor : Editor
{

	public override void OnInspectorGUI()
	{
		Mapgenerator mapGen = (Mapgenerator)target;

		if (DrawDefaultInspector())
		{
			if (mapGen.autoUpdate)
			{
				mapGen.DrawMapInEditor();
			}
		}

		if (GUILayout.Button("Generate"))
		{
			mapGen.DrawMapInEditor();
		}
	}
}