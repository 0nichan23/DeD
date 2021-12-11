using UnityEngine;

public class Mapgenerator : MonoBehaviour
{
    public enum DrawMode
    {
        Noise, 
        Colour,
        Mesh
    }
    public DrawMode drawmode;
    public int MapWidth;
    public int MapHeight;
    public float NoiseScale;
    public MapDisplay display;
    public bool AutoUpdate;
    public int Octaves;
    [Range(0,1)]
    public float Persistance;
    public float Lacunarity;
    public int seed;
    public Vector2 offset;
    public TerrainType[] regions;
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(MapWidth, MapHeight, Octaves, seed, NoiseScale, Persistance
            , Lacunarity, offset);
        Color[] colourmap = new Color[MapWidth * MapHeight];
        for (int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourmap[y * MapWidth + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }
        if (drawmode == DrawMode.Noise)
        {
            display.DrawTexture(TextureGenerator.textureFromHeightMap(noiseMap));
        }
        else if (drawmode == DrawMode.Colour)
        {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourmap, MapWidth, MapHeight));
        }
        else if (drawmode == DrawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap), TextureGenerator.TextureFromColourMap(colourmap, MapWidth, MapHeight));
        }
    }

    private void OnValidate()
    {
        if (MapWidth < 1)
        {
            MapWidth = 1;
        }
        if (MapHeight < 1)
        {
            MapHeight = 1;
        }
        if (Lacunarity < 1)
        {
            Lacunarity = 1;
        }
        if (Octaves < 0)
        {
            Octaves = 0;
        }
    }

    [System.Serializable]
    public struct TerrainType
    {
        public string name;
        public float height;
        public Color colour;
    }


}
