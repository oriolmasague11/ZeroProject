using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace iSquared
{

    [CreateAssetMenu(menuName = "iSquared/Gameplay Area Settings", fileName = "GameplayAreaSettings")]
    public class GameplayAreaSettings : ScriptableObject
    {
        [SerializeField] private float maxHorizontalPosition = 9.5f;
        [SerializeField] private float maxVerticalPostion = 9.5f;
        [SerializeField] private float verticalSpawnDistance = 12f;
        [SerializeField] private float horizontalSpawnDistance = 12f;
        [SerializeField] private float horizontalReleaseDistance = 14f;
        [SerializeField] private float verticalReleaseDistance = 14f;

        public float MaxHorizontalPosition => maxHorizontalPosition;    //quan et demanen MaxHorizontalPosition retornes maxHorizontalPosition 
        public float MinVerticalPostion => maxVerticalPostion;
        public float HorizontalSpawnDistance => horizontalSpawnDistance;
        public float VerticalSpawnDistance => verticalSpawnDistance;
        public float HorizontalReleaseDistance => horizontalReleaseDistance;
        public float VerticalReleaseDistance => verticalReleaseDistance;

        private void OnValidate()
        {
            if(VerticalReleaseDistance <= VerticalSpawnDistance)
            {
                Debug.LogError("VerticalReleaseDistance must be greater than VerticalSpawnDistance!");
            }

            if(HorizontalReleaseDistance <= HorizontalSpawnDistance)
            {
                Debug.LogError("VerticalReleaseDistance must be greater than VerticalSpawnDistance!"); 
            }
        }

    }
}

