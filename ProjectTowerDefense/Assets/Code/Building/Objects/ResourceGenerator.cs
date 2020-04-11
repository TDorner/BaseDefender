using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Map;

namespace Building
{
    public class ResourceGenerator : MonoBehaviour
    {
        [Header("Building Layout")]
        public GameObject particle;

        [Header("Building Statistics")]
        private RESOURCE_TYPE resourceTypeGold = RESOURCE_TYPE.Gold;
        public int resourceAmountGold;

        private RESOURCE_TYPE resourceTypeMeat = RESOURCE_TYPE.Meat;
        public int resourceAmountMeat;

        private RESOURCE_TYPE resourceTypeWood = RESOURCE_TYPE.Wood;
        public int resourceAmountWood;

        public int generationPerSeconds = 5;

        [Header("Other")]
        private PlayerHandler playerHandler;
        private CreateTileMap cTM;
        private ResourceManager resManager;


        private void Awake()
        {
            playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
            cTM = GameObject.FindGameObjectWithTag("TileMap").GetComponent<CreateTileMap>();
            resManager = playerHandler.resourceManager;
        }

        public void AddResourcesToPlayer()
        {
            AddGoldResourceToPlayer();
            AddMeatResourceToPlayer();
            AddWoodResourceToPlayer();
        }

        private void AddGoldResourceToPlayer()
        {
            Resource resource = resManager.GetResourceByResourceType(resourceTypeGold);
            resManager.AddResource(resource, resourceAmountGold);
        }
        private void AddMeatResourceToPlayer()
        {
            Resource resource = resManager.GetResourceByResourceType(resourceTypeMeat);
            resManager.AddResource(resource, resourceAmountMeat);
        }
        private void AddWoodResourceToPlayer()
        {
            Resource resource = resManager.GetResourceByResourceType(resourceTypeWood);
            resManager.AddResource(resource, resourceAmountWood);
        }
    }

}