using UnityEngine;
using Input;
using Player;
using Map;

namespace Building.Placement
{


    public class BuildingPlacement
    {
        ResourceManager resManager;
        PlayerHandler playerHandler;
        TileMapData tileMapData;


        public BuildingPlacement()
        {
            playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
    
            resManager = playerHandler.resourceManager;
            tileMapData = GameObject.FindGameObjectWithTag("TileMap").GetComponent<CreateTileMap>().TMData;
        }



        public bool CheckForCosts(BaseBuilding _building)
        {
            Resource resGold = resManager.goldResource;
            Resource resWood = resManager.woodResource;
            Resource resMeat = resManager.meatResource;

            if (resGold.CheckResourceCount(_building.buildCostGold) && 
                resWood.CheckResourceCount(_building.buildCostWood) && 
                resMeat.CheckResourceCount(_building.buildCostMeat))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SubstractCosts(BaseBuilding _building)
        {
            playerHandler.resourceManager.SubstractResource(playerHandler.resourceManager.goldResource, _building.buildCostGold);
            playerHandler.resourceManager.SubstractResource(playerHandler.resourceManager.woodResource, _building.buildCostWood);
            playerHandler.resourceManager.SubstractResource(playerHandler.resourceManager.meatResource, _building.buildCostMeat);

            Debug.Log("Resources Taken");
        }

        public void OccupyTiles(BaseBuilding _building, Vector3 _vec)
        {
            for (int x = 0; x < _building.sizeX; x++)
            {
                for (int y = 0; y < _building.sizeY; y++)
                {
                    TileData tData = tileMapData.GetTileAt((int)(_vec.z + y), (int)(_vec.x + x));
                    tData.SetBuilding(_building);
                }
            }
        }

        public bool CheckTiles(BaseBuilding _building, Vector3 _vec)
        {
            for (int x = 0; x < _building.sizeX; x++)
            {
                for (int y = 0; y < _building.sizeY; y++)
                {
                    TileData tData = tileMapData.GetTileAt((int)(_vec.z + y), (int)(_vec.x + x));
                    Debug.Log("TileData: " + tData.contentData + " at: " + (_vec.x + x) + "|" + (_vec.z + y));

                    if (tData.contentData == TileData.CONTENT_DATA.BUILDING || tData.contentData == TileData.CONTENT_DATA.TERRAIN)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Build(BaseBuilding _building, Vector3 _vec)
        {
            if (CheckForCosts(_building) && CheckTiles(_building, _vec))
            {
                SubstractCosts(_building);
                OccupyTiles(_building, _vec);
                return true;
            }
            else
            {
                Debug.Log("Nope");
                return false;
            }
        }
    }
}