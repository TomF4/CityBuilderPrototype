using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTiles : MonoBehaviour
{
    public int rows = 10;
    public int cols = 10;
    public float tileSize = 1.0f;
    List<Tile> tiles = new List<Tile>();

    void Start()
    {
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[rows * cols];
        Vector2[] uv = new Vector2[rows * cols];
        int[] triangles = new int[(rows - 1) * (cols - 1) * 6];

        //
        // Generate vertices
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                vertices[row * cols + col] = new Vector3(col * tileSize, /*Random.Range(-10,10)*/0, row * tileSize);
                uv[row * cols + col] = new Vector2((float)col / cols, (float)row / rows);
            }
        }

        // Generate triangles
        int triangleIndex = 0;
        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                // First Triangle
                triangles[triangleIndex++] = row * cols + col;
                triangles[triangleIndex++] = (row + 1) * cols + col;
                triangles[triangleIndex++] = row * cols + col + 1;
                // Second Triangle
                triangles[triangleIndex++] = (row + 1) * cols + col;
                triangles[triangleIndex++] = (row + 1) * cols + col + 1;
                triangles[triangleIndex++] = row * cols + col + 1;
            }
        }
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;

    }

}

public enum TileType
{
    Grass,
    Mountain,
    Stone,
}

class Tile
{
    int posX = 0;
    int posY = 0;

    List<GameObject> inTile = new List<GameObject>();

    bool hasBuilding = false;
    bool isOccupied = false;
    bool hasPath = false;

}