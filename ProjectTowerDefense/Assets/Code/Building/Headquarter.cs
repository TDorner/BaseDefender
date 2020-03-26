using UnityEngine;
using Player;
using Map;

namespace Buildings
{

    public class Headquarter : MonoBehaviour
    {
        [Header("Building Layout")]
        public int sizeX = 2;
        public int sizeY = 2;
        public GameObject particle;

        [Header("Building Statistics")]
        public int lifePoints = 1000;
        public int resourceGeneration = 10;

        [Header("Building Costs")]
        public int buildCostGold = 0;
        public int buildCostWood = 0;
        public int buildCostMeat = 0;

        [Header("Other")]
        private PlayerHandler playerHandler;
        private CreateTileMap createTileMap;


        private void Awake()
        {
            playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
            createTileMap = GameObject.FindGameObjectWithTag("TileMap").GetComponent<CreateTileMap>();
        }
        private void Start()
        {

        }

        private void Update()
        {

        }

        public void RequestState()
        {
            
        }


        private void GenerateRessources()
        {

        }



    }
}