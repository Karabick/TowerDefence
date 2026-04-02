using System;
using System.Collections.Generic;
using UnityEngine;


public enum IFormation 
{
    Wedge,
    Rhomb,
    Lines
}


public interface IFormationInterface
{
    int Modules { get; }
    float DistnceBetweenSoldiers { get; }
    float DistanceBetweenFormations { get; }
    TowerController Controller { get; }
    void InitializeFormation(Transform StartPoint);
    void AddAllPoints(int countWarriors);
    Transform StartNewFirmation(Transform StartPoint);
    void SearchPlace();
    void RemoveWarrior();
    int countingNumberOfWarriors();
}

public class FormationManager : MonoBehaviour
{
   public IFormationInterface formationInterface;

}
