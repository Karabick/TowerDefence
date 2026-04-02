using System;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemyInterface
{
    int sHealth { get; }
    int incHealthByLevel { get; }
    int sAttack {  get; }
    int incAttackByLevel { get; }
    int sArmor { get; }
    int incArmorByHealth { get; }
    int wSpeed { get; }
    int rSpeed { get; }
    int atRange { get; }

}

[Serializable]
public class EKnight : IEnemyInterface
{
    public int startHealth = 100;
    public int increasedHealthByLevel = 55;
    public int startAttack = 25;
    public int increasedAttackByLevel = 15;
    public int startArmor = 20;
    public int increasedArmorByHealth = 15;
    public int speed = 3;
    public int rotationSpeed = 5;
    public int attackRange = 4;

    public int sHealth => startHealth;
    public int incHealthByLevel => increasedHealthByLevel;
    public int sAttack => startAttack;
    public int incAttackByLevel => increasedAttackByLevel;
    public int sArmor => startArmor;
    public int incArmorByHealth => increasedArmorByHealth;
    public int wSpeed => speed;
    public int rSpeed => rotationSpeed;
    public int atRange => attackRange;
}
[Serializable]
public class EArcher : IEnemyInterface
{
    public int startHealth = 100;
    public int increasedHealthByLevel = 55;
    public int startAttack = 25;
    public int increasedAttackByLevel = 15;
    public int startArmor = 20;
    public int increasedArmorByHealth = 15;
    public int speed = 3;
    public int rotationSpeed = 5;
    public int attackRange = 4;

    public int sHealth => startHealth;
    public int incHealthByLevel => increasedHealthByLevel;
    public int sAttack => startAttack;
    public int incAttackByLevel => increasedAttackByLevel;
    public int sArmor => startArmor;
    public int incArmorByHealth => increasedArmorByHealth;
    public int wSpeed => speed;
    public int rSpeed => rotationSpeed;
    public int atRange => attackRange;
}
[Serializable]
public class EWizard : IEnemyInterface
{
    public int startHealth = 150;
    public int increasedHealthByLevel = 55;
    public int startAttack = 25;
    public int increasedAttackByLevel = 15;
    public int startArmor = 20;
    public int increasedArmorByHealth = 15;
    public int speed = 3;
    public int rotationSpeed = 5;
    public int attackRange = 4;

    public int sHealth => startHealth;
    public int incHealthByLevel => increasedHealthByLevel;
    public int sAttack => startAttack;
    public int incAttackByLevel => increasedAttackByLevel;
    public int sArmor => startArmor;
    public int incArmorByHealth => increasedArmorByHealth;
    public int wSpeed => speed;
    public int rSpeed => rotationSpeed;
    public int atRange => attackRange;
}
[Serializable]
public class ETank : IEnemyInterface
{
    public int startHealth = 100;
    public int increasedHealthByLevel = 55;
    public int startAttack = 25;
    public int increasedAttackByLevel = 15;
    public int startArmor = 20;
    public int increasedArmorByHealth = 15;
    public int speed = 3;
    public int rotationSpeed = 5;
    public int attackRange = 4;

    public int sHealth => startHealth;
    public int incHealthByLevel => increasedHealthByLevel;
    public int sAttack => startAttack;
    public int incAttackByLevel => increasedAttackByLevel;
    public int sArmor => startArmor;
    public int incArmorByHealth => increasedArmorByHealth;
    public int wSpeed => speed;
    public int rSpeed => rotationSpeed;
    public int atRange => attackRange;
}
[Serializable]
public class ETowersAttacker : IEnemyInterface
{
    public int startHealth = 100;
    public int increasedHealthByLevel = 55;
    public int startAttack = 25;
    public int increasedAttackByLevel = 15;
    public int startArmor = 20;
    public int increasedArmorByHealth = 15;
    public int speed = 3;
    public int rotationSpeed = 5;
    public int attackRange = 4;

    public int sHealth => startHealth;
    public int incHealthByLevel => increasedHealthByLevel;
    public int sAttack => startAttack;
    public int incAttackByLevel => increasedAttackByLevel;
    public int sArmor => startArmor;
    public int incArmorByHealth => increasedArmorByHealth;
    public int wSpeed => speed;
    public int rSpeed => rotationSpeed;
    public int atRange => attackRange;
}

public enum IEnemy
{
    Knight,
    Archer,
    Wizard,
    Tank,
    TowersAttacker
}

public class EnemyManager : MonoBehaviour
{

    [Serializable]
    public class EnemysRedactor
    {
        [Header("Current Enemys Settings")]
        public EKnight knight = new EKnight();
        public EArcher archer = new EArcher();
        public EWizard wizard = new EWizard();
        public ETank tank = new ETank();
        public ETowersAttacker towersAttacker = new ETowersAttacker();
    }


     
    [Header("Enemys Redactor")]
    public EnemysRedactor enemysRedactor;


    [Serializable]
    public class Enemys
    {
        public IEnemy enemys;
        public GameObject prefab;
    }

    [Serializable]
    public class EnemysForSpawning
    {
        public IEnemy enemys;
        public int count_of_enemy;
    }

    [Serializable]
    public class Ways
    {
        public Transform spawnPoint;
        public Transform[] points;
        public EnemysForSpawning[] enemys;
    }

    [Header("Enemys")]
    public List<Enemys> enemy_prefab = new List<Enemys>();

    [Header("Ways")]
    public List<Ways> way = new List<Ways>();
}