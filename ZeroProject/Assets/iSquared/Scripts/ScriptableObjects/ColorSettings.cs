using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace iSquared
{
    [CreateAssetMenu(menuName = "iSquared/Color Settings", fileName = "ColorSettings")]
    public class ColorSettings : ScriptableObject
    {
        [SerializeField] private Color background = Color.white;
        [SerializeField] private Color player = new Color(32, 32, 32, 255);
        [SerializeField] private Color others = new Color(255, 0, 0, 255);

        public Color Background => background;
        public Color Player => player;
        public Color Others => others;

    }
}

