using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Map.CreateTileMap))]
public class TileMapInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate Mesh"))
        {
            Map.CreateTileMap tileMap = (Map.CreateTileMap)target;
            tileMap.CreateMap();
        }
    }

}
