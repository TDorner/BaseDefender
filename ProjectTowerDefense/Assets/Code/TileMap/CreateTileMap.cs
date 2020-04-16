using UnityEngine;

namespace Map
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshCollider))]
    public class CreateTileMap : MonoBehaviour
    {
        [Header("Map Settings")]
        [Range(1, 200)]
        // Z = Height
        public int height = 10;
        [Range(1, 200)]
        // X = Width
        public int width = 10;
        [Range(1, 10)]
        // Same Sized Quad
        public float tileSize = 1.0f;


        [Header("Texture Settings")]
        public int tileResolution = 16;
        public Texture2D terrainTiles;


        [Header("Other")]
        private TileMapGraphics TMGraphics;
        public TileMapData TMData;
        private TileMapTexture TMTexture;

        private Mesh mesh;
        private TileData[,] TDHolder;
        private Texture2D texture;

        private void Awake()
        {
            CreateMap();
        }

        public void CreateMap()
        {
            CreateData();
            CreateMesh();
            CreateTexture();
        }

        public void CreateMesh()
        {
            TMGraphics = new TileMapGraphics();
            mesh = TMGraphics.BuildMesh(height, width, tileSize);

            // Assign Mesh to Filter / Renderer / Collider
            MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
            MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();

            meshFilter.mesh = mesh;
            meshCollider.sharedMesh = mesh;
            Debug.Log("DONE Mesh");
        }

        public void CreateData()
        {
            TMData = new TileMapData();
            TDHolder = TMData.BuildTileMapData(height, width);

            //TMData.ShowTileDataHolderData();
            //TMData.ChangeTextureAt(2, 5, TileData.TEXTURE_DATA.WATER);

            Debug.Log("DONE Map Data");
        }

        public void CreateTexture()
        {
            TMTexture = new TileMapTexture();
            texture = TMTexture.BuildTexture(height, width, tileResolution, terrainTiles, TDHolder);

            MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
            meshRenderer.sharedMaterials[0].mainTexture = texture;

            Debug.Log("DONE Texture");
        }

        public void SetMapSettings(int _height, int _width, float _tileSize)
        {
            this.height = _height;
            this.width = _width;
            this.tileSize = _tileSize;
        }
    }

}