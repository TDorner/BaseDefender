using UnityEngine;

namespace Map
{
    public class TileData
    {
        public enum TEXTURE_DATA
        {
            GRASSLAND,
            FIELD,
            MOUNTAIN,
            WATER
        }

        public enum TEXTURE_DISTRIBUTION
        {
            GRASSLAND = 12,
            FIELD = 8,
            MOUNTAIN = 2,
            WATER = 3
        }

        public enum CONTENT_DATA
        {
            EMPTY,
            BUILDING,
            TERRAIN
        }

        public CONTENT_DATA contentData;
        public TEXTURE_DATA textureData;


        public TileData()
        {
            CreateTile();
        }

        private void CreateTile()
        {
            textureData = RandomTextureValue();

            if(textureData == TEXTURE_DATA.MOUNTAIN || textureData == TEXTURE_DATA.WATER)
            {
                contentData = CONTENT_DATA.TERRAIN;
            }
            else
            {
                contentData = CONTENT_DATA.EMPTY;
            }
        }

        public void SetTileTexture(TEXTURE_DATA tdata)
        {
            textureData = tdata;
        }
        public void SetTileContent(CONTENT_DATA cdata)
        {
            contentData = cdata;
        }

        public TileData GetTile()
        {
            return this;
        }

        public void ShowData()
        {
            Debug.Log("ContentData: " + contentData);
            Debug.Log("TextureData: " + textureData);
        }

        public int CheckTextureData()
        {
            TEXTURE_DATA tData = textureData;
            int num = 0;
            switch (tData)
            {
                case TileData.TEXTURE_DATA.GRASSLAND:
                    num = 0;
                    break;
                case TileData.TEXTURE_DATA.FIELD:
                    num = 1;
                    break;
                case TileData.TEXTURE_DATA.MOUNTAIN:
                    num = 2;
                    break;
                case TileData.TEXTURE_DATA.WATER:
                    num = 3;
                    break;
                default:
                    num = 0;
                    break;
            }
            return num;
        }
        // TODO improve RandomTextureValue()
        private TEXTURE_DATA RandomTextureValue()
        {
            TEXTURE_DATA tex;
            int roll;

            roll = Random.Range(0, ((int)TEXTURE_DISTRIBUTION.GRASSLAND + (int)TEXTURE_DISTRIBUTION.FIELD + (int)TEXTURE_DISTRIBUTION.MOUNTAIN + (int)TEXTURE_DISTRIBUTION.WATER));

            if(roll < (int)TEXTURE_DISTRIBUTION.GRASSLAND)
            {
                tex = TEXTURE_DATA.GRASSLAND;
            }
            else if (roll < (int)TEXTURE_DISTRIBUTION.GRASSLAND + (int)TEXTURE_DISTRIBUTION.FIELD)
            {
                tex = TEXTURE_DATA.FIELD;
            }
            else if (roll < (int)TEXTURE_DISTRIBUTION.GRASSLAND + (int)TEXTURE_DISTRIBUTION.FIELD + (int)TEXTURE_DISTRIBUTION.MOUNTAIN) 
            {
                tex = TEXTURE_DATA.MOUNTAIN;
            }
            else
            {
                tex = TEXTURE_DATA.WATER;
            }
            return tex;
        }


    }
}
