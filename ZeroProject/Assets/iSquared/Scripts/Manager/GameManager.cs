using iSquared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameplayAreaSettings gameplayAreaSettings;
    public GameplayAreaSettings GameplayAreaSettings => gameplayAreaSettings;
}
