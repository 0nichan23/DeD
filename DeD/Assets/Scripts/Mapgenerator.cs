using UnityEngine;

public class Mapgenerator : MonoBehaviour
{
    public enum DrawMode
    {
        Noise, 
        Colour,
        Mesh
    }
    const int MapChunkSize = 241;
    [Range(0,6)]
    public int LevelOfDetail;
    public DrawMode drawmode;
   /* public int MapChunkSize;
    public int MapChunkSize;*/
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
    public float MeshHeight;
    public AnimationCurve MeshHeightCurve;

    private void Start()
    {
        GenerateMap();
    }
    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(MapChunkSize, MapChunkSize, Octaves, seed, NoiseScale, Persistance
            , Lacunarity, offset);
        Color[] colourmap = new Color[MapChunkSize * MapChunkSize];
        for (int y = 0; y < MapChunkSize; y++)
        {
            for (int x = 0; x < MapChunkSize; x++)
            {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++)
                {
                    if (currentHeight <= regions[i].height)
                    {
                        colourmap[y * MapChunkSize + x] = regions[i].colour;
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
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourmap, MapChunkSize, MapChunkSize));
        }
        else if (drawmode == DrawMode.Mesh)
        {
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, MeshHeight, MeshHeightCurve, LevelOfDetail), TextureGenerator.TextureFromColourMap(colourmap, MapChunkSize, MapChunkSize));
        }
    }

    private void OnValidate()
    {
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
