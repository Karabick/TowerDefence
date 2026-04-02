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

public interface ITowerInterface
{
    int level { get; }
    float hp { get; }
    int upgradeHP { get; }
    int price { get; }
    int upgradePrice { get; }
    int sellPrice { get; }
    int upgradeSellPrice { get; }
    int maxLevel { get; }
    int countOfModules { get; }
    int upgradeWarriorsNumber { get; }
    public FormationManager typeOfFormation {  get; }
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
                        Instantiate(prefabs[ind].prefabTower, place[i].place.position, Quaternion.identity);
                        if (prefabs[ind].prefabWarrior != null && place[i].targetPlace != null)
                        {
                            Instantiate(prefabs[ind].prefabWarrior, place[i].targetPlace.position, Quaternion.identity);
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



    public ITowerInterface SetTowerType(ITower towerType)
    {
        switch (towerType) {
            case ITower.ArcherTower:return new IArcherTower();
            case ITower.HPMageTower: return new IHPMageTower();
            case ITower.ProtectorTower: return new IProtectorTower();
            case ITower.DamageMageTower: return new IDamageMageTower();
            case ITower.KnightTower: return new IKnightTower();
            default: Debug.LogError($"Такого типа башни нет!");
                return null;
        }
    }
}