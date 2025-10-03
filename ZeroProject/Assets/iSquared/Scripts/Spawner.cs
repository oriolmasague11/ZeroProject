using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyControler enemyPrefab; 
    [SerializeField] private BlackSquareControler blackSquarePrefab;

    private void Awake()
    {
        enemyPrefab = Resources.Load<EnemyControler>("iSquared/Prefabs/Enemy");
        blackSquarePrefab = Resources.Load<BlackSquareControler>("iSquared/Prefabs/BlackSquare"); 
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
