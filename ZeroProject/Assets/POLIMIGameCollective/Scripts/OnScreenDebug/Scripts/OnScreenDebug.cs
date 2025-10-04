#define ON_SCREEN_DEBUG

using UnityEngine;

namespace POLIMIGameCollective
{
    public class OnScreenDebug : Singleton<OnScreenDebug>
    {
        [SerializeField] TMPro.TextMeshProUGUI debugText = null;

        private void Awake()
        {
            debugText = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        }

        public void Print(string message, bool append = false)
        {
            if (debugText != null)
            {
                debugText.text = message;
            }
        }
        
        public void Append(string message)
        {
            if (debugText != null)
            {
                debugText.text += message;
            }
        }
    }
}