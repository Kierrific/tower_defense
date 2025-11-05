using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;

    private int selectedTower = 0;
    private int placeableTowers = 2;
    private int usableUpgrades = 0;
    private int tempValue = 0;
    
    public void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedTower()
    {
        return main.towerPrefabs[main.selectedTower];
    }

    public void selectReward(int rewardNum)
    {
        main.tempValue = main.selectedTower;
        main.selectedTower = rewardNum;
        if (rewardNum == 2 || rewardNum == 3)
        {
            main.usableUpgrades++;
        }
    }

    public int getPlaceableTowers()
    {
        return main.placeableTowers;
    }

    public void lowerTower()
    {
        main.placeableTowers--;
    }

    public void increaseTower()
    {
        main.placeableTowers++;
    }

    public int getSelectedTowerIndex()
    {
        return main.selectedTower;
    }
    public int getUsableUpgrades()
    {
        return main.usableUpgrades;
    }
    public void lowerUpgrades()
    {
        main.usableUpgrades--;
    }

    public void destroySelect()
    {
        if (selectedTower != 1001)
        {
            main.selectReward(1001);
        }
        else
        {
            main.selectReward(main.tempValue);
        }
    }
}
