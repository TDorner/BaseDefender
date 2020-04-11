using UnityEngine;

namespace Player
{
    public class PlayerHandler : MonoBehaviour
    {
        public ResourceManager resourceManager;

        private void Awake()
        {
            resourceManager = new ResourceManager();
        }




    }
}