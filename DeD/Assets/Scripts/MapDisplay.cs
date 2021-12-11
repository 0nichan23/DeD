using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer TextureRenderer;
    //public Texture2D texture;
    //public Color[] colors;
    public MeshFilter meshFilter;
    public MeshRenderer rendy;

    public void DrawTexture(Texture2D texture)
    {
        
        TextureRenderer.sharedMaterial.SetTexture("_MainTex", texture);
        TextureRenderer.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    public void DrawMesh(MeshData meshData, Texture2D texture)
    {
        meshFilter.sharedMesh = meshData.CreateMesh();
        rendy.sharedMaterial.mainTexture = texture;
    }
}
