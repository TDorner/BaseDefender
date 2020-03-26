using UnityEngine;

namespace Map
{

    public class TileMapTexture
    {



        public TileMapTexture()
        {

        }


        public Texture2D BuildTexture(int _height, int _width, int _tileResolution, Texture2D _terrainTiles, TileData[,] _tileDataHolder)
        {
            int texWidth = _width * _tileResolution;
            int texHeight = _height * _tileResolution;
            Texture2D texture = new Texture2D(texWidth, texHeight);

            Color[][] tiles = ChopUpTiles(_tileResolution, _terrainTiles);

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    TileData tData = _tileDataHolder[y, x];

                    
                    Color[] p = tiles[tData.CheckTextureData()];
                    texture.SetPixels(x * _tileResolution, y * _tileResolution, _tileResolution, _tileResolution, p);
                }
            }

            texture.filterMode = FilterMode.Point;
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.Apply();

            return texture;
        }

        private Color[][] ChopUpTiles(int _tileResolution, Texture2D _terrainTiles)
        {
            int numTilesPerRow = _terrainTiles.width / _tileResolution;
            int numRows = _terrainTiles.height / _tileResolution;

            Color[][] tiles = new Color[numTilesPerRow * numRows][];

            for (int y = 0; y < numRows; y++)
            {
                for (int x = 0; x < numTilesPerRow; x++)
                {
                    tiles[y * numTilesPerRow + x] = _terrainTiles.GetPixels(x * _tileResolution, y * _tileResolution, _tileResolution, _tileResolution);
                }
            }
            return tiles;
        }




    }
}
