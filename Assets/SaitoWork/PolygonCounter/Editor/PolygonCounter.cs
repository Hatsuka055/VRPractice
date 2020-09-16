using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshFilter))]
public class PolygonCounter : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
     
        MeshFilter filter = target as MeshFilter;
        string vertices = "verts（頂点数）: " + filter.sharedMesh.vertexCount;
        string triangles = "tris（ポリゴン数）: " + filter.sharedMesh.triangles.Length / 3;
        EditorGUILayout.LabelField(vertices);
        EditorGUILayout.LabelField(triangles);
    }
}

[CustomEditor(typeof(SkinnedMeshRenderer))]
public class SkinPolygonCounter : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SkinnedMeshRenderer skin = target as SkinnedMeshRenderer;
        string vertices = "verts（頂点数）: " + skin.sharedMesh.vertexCount;
        string triangles = "tris（ポリゴン数）: " + skin.sharedMesh.triangles.Length / 3;
        EditorGUILayout.LabelField(vertices);
        EditorGUILayout.LabelField(triangles);
    }
}