using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
   public class WarriorPositionsController
    {
        GameObject warrior;
        Transform position;
    }

    public class WarriorCountOfFormation
    {
        public Transform targetPoint;
        public List<WarriorPositionsController> warriorsPositions = new List<WarriorPositionsController>();
    }

    public List<WarriorCountOfFormation> warriorFormations = new List<WarriorCountOfFormation>();

    public TowerManagerOnPlace managerOnPlace;
    public TowerManager manager;
    public ITowerInterface towerInterface;
    int countOfWarriors;

    private void Start()
    {
        towerInterface = manager.SetTowerType(managerOnPlace.towerType);
    }

    private void Update()
    {
        if (towerInterface != null) Debug.LogError($"Ошибка! Тип башни не определён! Проверьте менеджер башен");
        else
        {
            countOfWarriors = towerInterface.typeOfFormation.formationInterface.countingNumberOfWarriors();
        }
    }
}
