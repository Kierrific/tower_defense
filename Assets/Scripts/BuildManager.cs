using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private GameObject[] upgradePrefabs;
    [SerializeField] private GameObject towerCountPrefab;
    [SerializeField] private GameObject upgradeCountPrefab;
    [SerializeField] private GameObject deletionTrackerPrefab;

    private int selectedTower = 0;
    private int placeableTowers = 2;
    private int usableUpgrades = 0;
    public int tempValue = 0;
    public List<GameObject> towerList = new();
    public List<int> upgradeList = new();

    public void Start()
    {
        towerList.Add(towerPrefabs[selectedTower]);
        towerList.Add(towerPrefabs[selectedTower]);
    }

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
        main.selectedTower = rewardNum;
        if (!(rewardNum == 0) && !(rewardNum == 1) && !(rewardNum == 1001))
        {
            main.usableUpgrades++;
            upgradeList.Add(rewardNum);
            upgradeCountPrefab.GetComponent<Upgrade_Updates>().updateText();
        }
    }

    public int getPlaceableTowers()
    {
        return main.placeableTowers;
    }

    public void lowerTower()
    {
        main.placeableTowers--;
        main.towerList.Remove(main.towerList[^1]);
        towerCountPrefab.GetComponent<Text_Updates>().updateText();
    }

    public void increaseTower()
    {
        main.placeableTowers++;
        main.towerList.Add(main.towerPrefabs[main.selectedTower]);
        towerCountPrefab.GetComponent<Text_Updates>().updateText();
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
        upgradeCountPrefab.GetComponent<Upgrade_Updates>().updateText();
    }

    public void destroySelect()
    {
        if (!EnemySpawner.main.checkItemsSpawned())
        {
            if (selectedTower != 1001)
            {
                main.selectReward(1001);
                deletionTrackerPrefab.GetComponent<Delete_Text_Update>().updateText();

            }
            else
            {
                main.selectReward(main.tempValue);
                deletionTrackerPrefab.GetComponent<Delete_Text_Update>().updateText();
            }
        }
        
    }

    public List<GameObject> getTowerList()
    {
        return towerList;
    }

    public void setSelectedTower(int num)
    {
        selectedTower = num;
    }

    
}
