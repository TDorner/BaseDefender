using UnityEngine;

namespace Building
{

    public class Tower : MonoBehaviour
    {
        [Header("Building Layout")]
        public GameObject particle;

        [Header("Building Statistics")]
        public int range;
        public float attackDamage;
        public float attackSpeed;


        private void Start()
        {
            
        }

        private void Update()
        {
            //Shoot(Target());
        }

        public void RequestState()
        {
            
        }

        private GameObject Target()
        {
            return new GameObject();
        }
        private void Shoot(GameObject _target)
        {

        }



    }

}