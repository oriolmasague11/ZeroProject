using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Esta molt guapo que el codi sigui aixi de reusable */
namespace iSquared
{
    public class DestroyOutsideScreen : MonoBehaviour
    {
        public float _horitzontalOuterLimits = 0;
        public float _verticalOuterLimits = 0;

        private void Awake()
        {
            _horitzontalOuterLimits = GameManager.Instance.GameplayAreaSettings.HorizontalReleaseDistance;
            _verticalOuterLimits = GameManager.Instance.GameplayAreaSettings.VerticalReleaseDistance;

        }

        // Update is called once per frame
        void Update()
        {
            if ((Mathf.Abs(transform.position.x) > _verticalOuterLimits) ||
                (Mathf.Abs(transform.position.y) > _horitzontalOuterLimits))
            {
                Destroy(gameObject);
            }

        }
    }
}
