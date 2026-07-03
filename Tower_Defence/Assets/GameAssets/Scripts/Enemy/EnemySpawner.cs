using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Wave information")]
    public EnemyManager manager;
    public int wave_number;
    public int spawn_enemy_interval;
    public int interval_between_waves;
    public int time_before_start;

    private int current_wave_number = 0;
    private int currentWayIndex; 
    private int currentEnemyTypeIndex; 
    private int currentEnemyCount; 

    private void Start()
    {
        Invoke("Start_next_wave", time_before_start);
    }

    public void Start_next_wave()
    {
        current_wave_number++;
        Debug.Log($"Íà÷àòà âîëíà {current_wave_number}");
        if (current_wave_number <= wave_number) 
        {
            currentWayIndex = 0; 
            currentEnemyTypeIndex = 0;
            currentEnemyCount = 0;
            InvokeRepeating("spawn_enemy_in_current_wave", 0f, spawn_enemy_interval); 
        }
    }

    public void spawn_enemy_in_current_wave()
    {
        if (currentWayIndex >= manager.way.Count)
        {
            CancelInvoke("spawn_enemy_in_current_wave");
            if (current_wave_number < wave_number)
            {
                Invoke("Start_next_wave", interval_between_waves);
            }
            else Debug.Log($"Âñå âîëíû çàêîí÷åíû!");
            return;
        }

        var currentWay = manager.way[currentWayIndex];

        if (currentEnemyTypeIndex >= currentWay.enemys.Length)
        {
            currentWayIndex++;
            currentEnemyTypeIndex = 0;
            currentEnemyCount = 0;
        }

        var currentEnemyType = currentWay.enemys[currentEnemyTypeIndex];

        if (currentEnemyCount < currentEnemyType.count_of_enemy)
        {
            GameObject enemyPrefab = GateEnemyPrefab(currentEnemyType.enemys);
            if (enemyPrefab != null)
            {
                GameObject enemy = Instantiate(enemyPrefab, currentWay.spawnPoint.position, Quaternion.identity);
                enemy.GetComponent<EnemyMovement>().point = currentWay.points;
                currentEnemyCount++;
            }
        }

        if (currentEnemyCount >= currentEnemyType.count_of_enemy)
        {
            currentEnemyTypeIndex++;
            currentEnemyCount = 0;

            if (currentEnemyTypeIndex >= currentWay.enemys.Length)
            {
                currentWayIndex++;
                currentEnemyTypeIndex = 0;
                currentEnemyCount = 0;
            }
        }
    }

    public GameObject GateEnemyPrefab(IEnemy enemyType)
    {
        foreach (var enemy in manager.enemy_prefab)
        {
            if (enemy.enemys == enemyType)
            {
                return enemy.prefab;
            }
        }

        Debug.LogError($"Îøèáêà! Òèï âðàãà {enemyType} íå íàéäåí â ìåíåäæåðå âðàãîâ!");
        return null;
    }
}
