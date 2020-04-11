using UnityEngine;
using Map;
using Player;

namespace Building
{
    public class BaseBuilding : MonoBehaviour
    {
        [Header("Building Layout")]
        public int sizeX = 1;
        public int sizeY = 1;
        public GameObject buildingPrefab;

        [Header("Building Statistics")]
        public int lifePoints;

        [Header("Building Costs")]
        public int buildCostGold;
        public int buildCostWood;
        public int buildCostMeat;

        [Header("Other")]
        private PlayerHandler playerHandler;
        private CreateTileMap cTM;

        private void Awake()
        {
            playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
            cTM = GameObject.FindGameObjectWithTag("TileMap").GetComponent<CreateTileMap>();
        }

        private void Start()
        {
            SubstractCosts();
        }

        private void SubstractCosts()
        {
            playerHandler.resourceManager.SubstractResource(playerHandler.resourceManager.goldResource, buildCostGold);
            playerHandler.resourceManager.SubstractResource(playerHandler.resourceManager.woodResource, buildCostWood);
            playerHandler.resourceManager.SubstractResource(playerHandler.resourceManager.meatResource, buildCostMeat);

            Debug.Log("Resources Taken");
        }

        public void OccupyTiles(int _x, int _y)
        {

        }
    }
}