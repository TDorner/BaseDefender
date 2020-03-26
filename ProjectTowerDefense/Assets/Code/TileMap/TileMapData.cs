using UnityEngine;

namespace Map
{
    public class TileMapData
    {
        TileData[,] tileDataHolder;

        int height;
        int width;

        public TileMapData()
        {

        }

        public TileData[,] BuildTileMapData(int _height, int _width)
        {
            // not sure if needed
            height = _height;
            width = _width;

            int x;
            int y;

            tileDataHolder = new TileData[_height, _width];

            for(y = 0; y < _height; y++)
            {
                for (x = 0; x < _width; x++)
                {
                    //Debug.Log("x: " + x + " y: " + y);
                    TileData tileData = new TileData();

                    tileDataHolder[y, x] = tileData;
                }
            }
            return tileDataHolder;
        }

        public void ShowTileDataHolderData()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Debug.Log(y + ":" + x + " ");
                    TileData tData = tileDataHolder[y, x];
                    tData.ShowData();
                }
            }
        }

        public TileData GetTileAt(int _x, int _y)
        {
            if ( _x < 0 || _x >= width || _y < 0 || _y >= height)
            {
                Debug.Log("Error");
                return null;
            }
            return tileDataHolder[_x, _y];
        }

        public void ChangeTextureAt(int _x, int _y, TileData.TEXTURE_DATA _texData)
        {
            TileData tData = tileDataHolder[_y, _x];
            tData.textureData = _texData;
        }
    }
}
