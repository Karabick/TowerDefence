using System;
using System.Collections.Generic;
using UnityEngine;

public enum ITower
{
    ArcherTower,
    KnightTower,
    HPMageTower,
    DamageMageTower,
    ProtectorTower
}

public class TowerManager : MonoBehaviour
{
    [Serializable]
    public class TowerPrefabs
    {
        public ITower towerType;
        public GameObject prefabTower;
        public GameObject prefabWarrior;
    }

    [Serializable]
    public class Places
    {
        public TowerManagerOnPlace towerPlaceManager;
        public Transform place;
        public Transform targetPlace;
        public bool empty = true;
    }

    [Header("Prefab Redactor")]
    public List<TowerPrefabs> prefabs = new List<TowerPrefabs>();

    [Header("Place Redactor")]
    public List<Places> place = new List<Places>();

    private void Update()
    {
        CheckTowersState();
    }

    void CheckTowersState()
    {
        for (int i = 0; i < place.Count; i++)
        {
            if (place[i].empty == true &&
                place[i].towerPlaceManager != null &&
                place[i].towerPlaceManager.click == true)
            {
                bool towerFound = false;

                for (int ind = 0; ind < prefabs.Count; ind++)
                {
                    if (prefabs[ind].towerType == place[i].towerPlaceManager.towerType)
                    {
                        GameObject tower = Instantiate(prefabs[ind].prefabTower, place[i].place.position, Quaternion.identity);

                        TowerController towerController = tower.GetComponent<TowerController>();
                        if (towerController != null)
                        {
                            towerController.managerOnPlace = place[i].towerPlaceManager;
                            towerController.info.targetPoint = place[i].targetPlace;
                            towerController.info.spawnPoint = place[i].towerPlaceManager.spawnPoint;
                        }

                        if (prefabs[ind].prefabWarrior != null && place[i].targetPlace != null)
                        {
                            GameObject warrior = Instantiate(prefabs[ind].prefabWarrior, place[i].targetPlace.position, Quaternion.identity);
                        }

                        towerFound = true;
                        break;
                    }
                }

                if (!towerFound)
                {
                    Debug.LogError($"Tower type {place[i].towerPlaceManager.towerType} not found in prefabs!");
                }

                place[i].towerPlaceManager.click = false;
                place[i].empty = false;
            }
        }
    }
}