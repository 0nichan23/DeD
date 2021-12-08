using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer TextureRenderer;
    public Texture2D texture;
    public Color[] colors;
    public void DrawNoiseMap(float[,] noiseMap)
    {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);
        texture = new Texture2D(width, height);
        colors =  new Color[width*height];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
               colors[i * width + j] = Color.Lerp(Color.black, Color.white, noiseMap[i,j]);
                //Debug.Log(noiseMap[i,j]);
            }
        }
        texture.SetPixels(colors);
        texture.Apply();
        TextureRenderer.sharedMaterial.SetTexture("_MainTex", texture);
        TextureRenderer.transform.localScale = new Vector3(width, 1, height);
    }
}
