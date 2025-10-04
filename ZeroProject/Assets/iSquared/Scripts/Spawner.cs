using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ScreenSize
{
    Bottom = 0, 
    Left = 1,
    Right = 2, 
    Top = 3
}

public class Spawner : MonoBehaviour
{
    [SerializeField] private float maxHorizontalPosition = 9.5f;
    [SerializeField] private float maxVerticalPostion = 9.5f;
    [SerializeField] private float verticalSpawnDistance = 12f;
    [SerializeField] private float horizontalSpawnDistance = 12f;


    [SerializeField] private EnemyControler enemyPrefab; 
    [SerializeField] private BlackSquareControler blackSquarePrefab;
    //other prefabs... 
    [SerializeField] private readonly float[] zRotation = new float[4];

    private void Awake()
    {
        enemyPrefab = Resources.Load<EnemyControler>("iSquared/Prefabs/Enemy");
        blackSquarePrefab = Resources.Load<BlackSquareControler>("iSquared/Prefabs/BlackSquare");

        // set rotations 
        zRotation[(int) ScreenSize.Bottom] = 0;
        zRotation[(int) ScreenSize.Right] = 90;
        zRotation[(int) ScreenSize.Left] = -90;
        zRotation[(int) ScreenSize.Top] = 180;
    }

    Vector2 GetRandomStartPosition()
    {
        return new Vector2(Random.Range(-7, 7), -9); 
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(2f);

        for(int i = 0; i < 20; i++)
        {
            if(Random.value < 0.3f)
            {
                EnemyControler enemy = Instantiate(enemyPrefab, GetRandomStartPosition(), Quaternion.identity);
            }
            else
            {
                BlackSquareControler blackSquare = Instantiate(blackSquarePrefab, GetRandomStartPosition(), Quaternion.identity);   
            }
            yield return new WaitForSeconds(Random.Range(1f, 2f)); 
        }

        yield return null; 
    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_EDITOR                        //aquest fragment de codi nomes s'executa si estem al editor de Unity. No a l'app mobil final. 
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Create an enemy 
            EnemyControler enemy = Instantiate(enemyPrefab, GetRandomStartPosition(), Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Create a black square 
            BlackSquareControler blackSquare = Instantiate(blackSquarePrefab, GetRandomStartPosition(), Quaternion.identity);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            //StartCoroutine(SpawnEnemies());
            StartCoroutine("SpawnEnemies");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //StartCoroutine(SpawnEnemies());
            StopCoroutine("SpawnEnemies");
        }
#endif
    }
}
