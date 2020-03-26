using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Map;

namespace Buildings
{

    public class Lumber : MonoBehaviour
    {
        [Header("Building Layout")]
        public int sizeX = 1;
        public int sizeY = 1;
        public GameObject particle;

        [Header("Building Statistics")]
        public int lifePoints = 300;
        public int resourceGenerationWood = 10;

        [Header("Building Costs")]
        public int buildCostGold = 100;
        public int buildCostWood = 50;
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

        private void Update()
        {
        }

        public void RequestState()
        {
            
        }

        public void AddWoodToPlayer()
        {
            playerHandler.resourceManager.AddResource(playerHandler.resourceManager.woodResource, resourceGenerationWood);
        }

        private void SubstractCosts()
        {
            playerHandler.resourceManager.SubstractResource(playerHandler.resourceManager.goldResource, buildCostGold);
            playerHandler.resourceManager.SubstractResource(playerHandler.resourceManager.woodResource, buildCostWood);
            playerHandler.resourceManager.SubstractResource(playerHandler.resourceManager.meatResource, buildCostMeat);

            Debug.Log("Resources Taken");
        }

    }

}