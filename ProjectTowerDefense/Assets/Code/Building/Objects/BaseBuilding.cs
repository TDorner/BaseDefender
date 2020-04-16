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

        public int posX;
        public int posY;

        [Header("Other")]
        private BuildingManager manager;

        private void Awake()
        {
            manager = GameObject.FindGameObjectWithTag("BuildingManager").GetComponent<BuildingManager>();
        }

        private void Start()
        {
            
        }

        private void GetPosition()
        {

        }

    }
}