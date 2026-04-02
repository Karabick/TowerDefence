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
    private int currentWayIndex; // индекс текущего пути
    private int currentEnemyTypeIndex; // индекс текущего типа врага на пути
    private int currentEnemyCount; // индекс текущего количества созданных врагов

    private void Start()
    {
        Invoke("Start_next_wave", time_before_start);
    }

    // запуск следующей волны
    public void Start_next_wave()
    {
        current_wave_number++;
        Debug.Log($"Ќачата волна {current_wave_number}");
        if (current_wave_number <= wave_number) 
        {
            currentWayIndex = 0; 
            currentEnemyTypeIndex = 0;
            currentEnemyCount = 0;
            InvokeRepeating("spawn_enemy_in_current_wave", 0f, spawn_enemy_interval); 
        }
    }

    // —оздание врагов на сцене в текущей волне
    public void spawn_enemy_in_current_wave()
    {
        if (currentWayIndex >= manager.way.Count)
        {
            CancelInvoke("spawn_enemy_in_current_wave");
            if (current_wave_number < wave_number)
            {
                Invoke("Start_next_wave", interval_between_waves);
            }
            else Debug.Log($"¬се волны закончены!");
            return;
        }

        var currentWay = manager.way[currentWayIndex];

        // ѕроверка на выход из массива типов
        if (currentEnemyTypeIndex >= currentWay.enemys.Length)
        {
            currentWayIndex++;
            currentEnemyTypeIndex = 0;
            currentEnemyCount = 0;
        }

        var currentEnemyType = currentWay.enemys[currentEnemyTypeIndex];

        // —оздание врага одного типа если их ещЄ нужно создавать
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

        // ≈сли создали всех врагов текущего типа, переходим к следующему
        if (currentEnemyCount >= currentEnemyType.count_of_enemy)
        {
            currentEnemyTypeIndex++;
            currentEnemyCount = 0;

            //переход к следущему пути
            if (currentEnemyTypeIndex >= currentWay.enemys.Length)
            {
                currentWayIndex++;
                currentEnemyTypeIndex = 0;
                currentEnemyCount = 0;
            }
        }
    }

    // выбор префаба врага который будет создан
    public GameObject GateEnemyPrefab(IEnemy enemyType)
    {
        foreach (var enemy in manager.enemy_prefab)
        {
            if (enemy.enemys == enemyType)
            {
                return enemy.prefab;
            }
        }

        Debug.LogError($"ќшибка! “ип врага {enemyType} не найден в менеджере врагов!");
        return null;
    }
}