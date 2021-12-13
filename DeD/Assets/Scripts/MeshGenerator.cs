using UnityEngine;

public static class MeshGenerator
{
    public static MeshData GenerateTerrainMesh(float[,] heightMap, float heightMultiplyer, AnimationCurve HeightCurve, int levelOfDetail)
    {
        AnimationCurve heightCurve = new AnimationCurve(HeightCurve.keys);
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);
        float topLeftX = (width - 1) / -2f;
        float topleftZ = (height - 1) / 2f;
        int meshSimpleInc = (levelOfDetail == 0) ? 1: levelOfDetail * 2;
        int verticiesPerLine = (width - 1) / meshSimpleInc + 1;
        MeshData meshData = new MeshData(verticiesPerLine, verticiesPerLine);
        int vertexIndex = 0;
        for (int y = 0; y < height; y+= meshSimpleInc)
        {
            for (int x = 0; x < width; x += meshSimpleInc)
            {
                meshData.vertecies[vertexIndex] = new Vector3(topLeftX + x, heightCurve.Evaluate(heightMap[x, y]) * heightMultiplyer, topleftZ - y);
                meshData.uvs[vertexIndex] = new Vector2(x / (float)width, y / (float)height);
                if (x < width - 1 && y < height - 1)
                {
                    meshData.AddTriangle(vertexIndex, vertexIndex + verticiesPerLine + 1, vertexIndex + verticiesPerLine);
                    meshData.AddTriangle(vertexIndex + verticiesPerLine + 1, vertexIndex, vertexIndex + 1);
                }
                vertexIndex++;
            }
        }

        return meshData;
    }

}

public class MeshData
{
    public Vector3[] vertecies;
    public int[] triangles;
    int triangleIndex;
    public Vector2[] uvs;
    public MeshData(int meshWidth, int meshHeight)
    {
        vertecies = new Vector3[meshWidth * meshHeight];
        uvs = new Vector2[meshWidth * meshHeight];
        triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];
    }

    public void AddTriangle(int a, int b, int c)
    {
        triangles[triangleIndex] = a;
        triangles[triangleIndex + 1] = b;
        triangles[triangleIndex + 2] = c;
        triangleIndex += 3;
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertecies;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        return mesh;
    }
}
