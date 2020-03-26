using UnityEngine;
using UnityEngine.UI;
using Player;

namespace UI
{
    public class UITopPanel : MonoBehaviour
    {
        public Text pointText;
        public Text goldText;
        public Text woodText;
        public Text meatText;

        private PlayerHandler playerHandler;
        private ResourceManager resManager;

        private void Awake()
        {
            playerHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
            resManager = playerHandler.resourceManager;
        }

        void Update()
        {
            UpdateResourceCounters();
        }

        private void UpdateResourceCounters()
        {
            pointText.text = resManager.points.ToString();
            goldText.text = resManager.goldResource.GetCount().ToString();
            woodText.text = resManager.woodResource.GetCount().ToString();
            meatText.text = resManager.meatResource.GetCount().ToString();
        }
    }
}
