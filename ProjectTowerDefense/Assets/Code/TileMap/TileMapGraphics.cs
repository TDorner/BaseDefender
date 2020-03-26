using UnityEngine;


namespace Map
{

    public class TileMapGraphics
    {

        public Mesh BuildMesh(int _height, int _width, float _tileSize)
        {
            int numTiles = _height * _width;
            int numTris = numTiles * 2;

            int vertSizeX = _width + 1;
            int vertSizeZ = _height + 1;
            int numVertices = vertSizeX * vertSizeZ;

            /*
             * Generate Mesh Data
             */

            Vector3[] vertices = new Vector3[numVertices];
            Vector3[] normals = new Vector3[numVertices];
            Vector2[] uv = new Vector2[numVertices];

            int[] triangles = new int[numTris * 3];

            //Set Vertices
            int x, z;

            for (z = 0; z < vertSizeZ; z++)
            {
                for (x = 0; x < vertSizeX; x++)
                {
                    vertices[z * vertSizeX + x] = new Vector3(x * _tileSize, 0, z * _tileSize);
                    normals[z * vertSizeX + x] = Vector3.up;
                    uv[z * vertSizeX + x] = new Vector2((float)x / _width, (float)z / _height);
                }
            }
            Debug.Log("DONE Vertices");

            //Set Tris
            for (z = 0; z < _height; z++)
            {
                for (x = 0; x < _width; x++)
                {
                    int squareIndex = z * _width + x;
                    int triOffset = squareIndex * 6;

                    triangles[triOffset + 0] = z * vertSizeX + x + 0 + 0;
                    triangles[triOffset + 1] = z * vertSizeX + x + vertSizeX + 0;
                    triangles[triOffset + 2] = z * vertSizeX + x + vertSizeX + 1;

                    triangles[triOffset + 3] = z * vertSizeX + x + 0 + 0;
                    triangles[triOffset + 4] = z * vertSizeX + x + vertSizeX + 1;
                    triangles[triOffset + 5] = z * vertSizeX + x + 0 + 1;
                }
            }
            Debug.Log("DONE Tris");

            // Create Mesh and populate with data
            Mesh mesh = new Mesh
            {
                vertices = vertices,
                triangles = triangles,
                normals = normals,
                uv = uv
            };

            return mesh;

        }
    }
}
