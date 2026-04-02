using UnityEngine;

public class IKnightTower : MonoBehaviour, ITowerInterface
{
    public int aLevel = 0;
    public float aHP = 0;
    public int aUpgradeHP = 0;
    public int aPrice = 0;
    public int aUpgradePrice = 0;
    public int aSellPrice = 0;
    public int aUpgradeSellPrice = 0;
    public int aMaxLevel = 0;
    public int aStartWarriorsNumber = 0;
    public int aUpgradeWarriorsNumber = 0;
    public FormationManager aTypeOfFormation;

    public int level => aLevel;
    public float hp => aHP;
    public int upgradeHP => aUpgradeHP;
    public int price => aPrice;
    public int upgradePrice => aUpgradePrice;
    public int sellPrice => aSellPrice;
    public int upgradeSellPrice => aUpgradeSellPrice;
    public int maxLevel => aMaxLevel;
    public int countOfModules => aStartWarriorsNumber;
    public int upgradeWarriorsNumber => aUpgradeWarriorsNumber;
    public FormationManager typeOfFormation => aTypeOfFormation;
}
