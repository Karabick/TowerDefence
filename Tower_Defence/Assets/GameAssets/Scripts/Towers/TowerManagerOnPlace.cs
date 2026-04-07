using UnityEngine;

public class TowerManagerOnPlace : MonoBehaviour
{
    public ITower towerType;
    public Transform targetPoint;
    public Transform spawnPoint;
    public bool click = false;
    private bool active = false;

    private void OnMouseDown()
    {
        if (active == false)
        {
            active = true;
            click = true;
        }
        Debug.Log("Было выбрано нажать клавишу для создания башни на плотформе!");
    }

    public void ResetActive()
    {
        active = false;
    }
}