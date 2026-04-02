using UnityEngine;

public class IWedgeFormation : MonoBehaviour, IFormationInterface
{

    public int modules = 0;
    public float distanceBetweenSoldiers = 0;
    public float diatsnceBetweenFormations = 0;
    public TowerController controller;


    public int Modules => modules;
    public float DistnceBetweenSoldiers => distanceBetweenSoldiers;
    public float DistanceBetweenFormations => diatsnceBetweenFormations;
    public TowerController Controller => controller;

    public int countingNumberOfWarriors ()
    {
        int warriorsNumber = 0;

        for(int i = 0;i< Modules; i++)
        {
            if (i % 3 == 0 || (i + 1) % 3 == 0)
            {
                warriorsNumber+=2;
            }
            else warriorsNumber++;
        }
        return warriorsNumber;
    }

    public void InitializeFormation(Transform StartPoint)
    { 

    }
    public void AddAllPoints(int countWarriors) 
    {
        int count = 0;
        for (int i = 0; i < countWarriors; i++) 
        {
           if(count == 5)
            {
                count = 0;
                Controller.warriorFormations.Add(null);
            }
        }
    }

    public Transform StartNewFirmation(Transform StartPoint)
    {
        return null;
    }
    public void SearchPlace() { }

    public void RemoveWarrior() { }
}
