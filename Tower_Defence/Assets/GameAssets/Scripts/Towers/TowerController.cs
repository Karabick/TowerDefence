using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TowerInfo
{
    public int towerHealth;
    public int towerPrice;
    public float distanceBetweenSoldiers;
    public float distanceBetweenFormations;
    public int modulesCount;
    public GameObject warriorPrefab;
    public Transform targetPoint;
    public Transform spawnPoint;
}

public class TowerController : MonoBehaviour
{
    public TowerInfo info;
    public TowerManagerOnPlace managerOnPlace;
    int warriorsCount;
    int currentWarrior = 1;
    List<Transform> targetPoints = new List<Transform>();

    private void Start()
    {
        if (managerOnPlace != null)
        {
            info.targetPoint = managerOnPlace.targetPoint;
            info.spawnPoint = managerOnPlace.spawnPoint;
        }
        CreateFormation();
    }

    void CreateFormation()
    {
        GameObject warrior;
        if (info.modulesCount <= 0)
        {
            Debug.LogError($"Количество модулей не может быть равным или меньше нуля!");
            return;
        }
        warriorsCount = CountOfWarriors(info.modulesCount);

        for (int i = 0; i < warriorsCount; i++)
        {
            targetPoints.Add(null);
        }

        targetPoints[0] = info.spawnPoint;

        if (info.warriorPrefab == null)
        {
            Debug.LogError("Префвб воина пуст!");
            return;
        }

        warrior = Instantiate(info.warriorPrefab, info.spawnPoint.position, Quaternion.identity);
        WarriorsMovement movement = warrior.GetComponent<WarriorsMovement>();

        if (movement == null)
        {
            movement = warrior.AddComponent<WarriorsMovement>();
        }

        movement.targetPoint = info.targetPoint;

        while (currentWarrior < warriorsCount)
        {
            Transform newPoint = SearchPlace(targetPoints);
            warrior = Instantiate(info.warriorPrefab, info.spawnPoint.position, Quaternion.identity);
            movement = warrior.GetComponent<WarriorsMovement>();

            if (movement == null)
            {
                movement = warrior.AddComponent<WarriorsMovement>();
            }

            movement.targetPoint = newPoint;
            currentWarrior++;
        }
    }

    int CountOfWarriors(int modulesCount)
    {
        if (modulesCount == 1) return 1;
        if (modulesCount == 2) return 3;
        if (modulesCount == 3) return 5;
        if (modulesCount == 4) return 7;
        return 7;
    }

    Transform SearchPlace(List<Transform> targetPoints)
    {
        int i = 0;
        int currentIndInModule = 1;

        while (i < targetPoints.Count)
        {
            if (currentIndInModule == 5)
            {
                if (i - 4 >= 0 && targetPoints[i - 4] != null)
                {
                    Vector3 newPos = targetPoints[i - 4].position;
                    newPos.z -= info.distanceBetweenFormations;
                    targetPoints[i - 4].position = newPos;
                }
                currentIndInModule = 0;
            }

            if (i + 1 < targetPoints.Count && targetPoints[i + 1] == null)
            {
                if (i == 0)
                {
                    GameObject newPoint = new GameObject("Waypoint");
                    newPoint.transform.parent = transform;
                    Vector3 newPos = targetPoints[i].position;
                    newPos.x -= info.distanceBetweenSoldiers;
                    newPos.z += info.distanceBetweenSoldiers;
                    newPoint.transform.position = newPos;
                    targetPoints[i + 1] = newPoint.transform;
                    return newPoint.transform;
                }
                else if (i % 2 == 0)
                {
                    GameObject newPoint = new GameObject("Waypoint");
                    newPoint.transform.parent = transform;
                    Vector3 newPos = targetPoints[i - 1].position;
                    newPos.x -= info.distanceBetweenSoldiers;
                    newPos.z += info.distanceBetweenSoldiers;
                    newPoint.transform.position = newPos;
                    targetPoints[i + 1] = newPoint.transform;
                    return newPoint.transform;
                }
                else
                {
                    GameObject newPoint = new GameObject("Waypoint");
                    newPoint.transform.parent = transform;
                    Vector3 newPos = targetPoints[i - 1].position;
                    newPos.x += info.distanceBetweenSoldiers;
                    newPos.z += info.distanceBetweenSoldiers;
                    newPoint.transform.position = newPos;
                    targetPoints[i + 1] = newPoint.transform;
                    return newPoint.transform;
                }
            }

            currentIndInModule++;
            i++;
        }

        return transform;
    }
}