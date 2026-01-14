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

    private int selectedReward = 0;
    private int placeableTowers = 0;
    private int usableUpgrades = 0;
    public int tempValue = 0;
    public List<GameObject> towerList = new();
    public List<int> upgradeList = new();
    private int bothStartingGrabbed = 0;
    private int actualTowerSelect;

    public void Start()
    {
        EnemySpawner.main.SetItemsSpawned(true);
        LevelManager.main.gameObject.GetComponent<ItemGrabber>().StartingItems();
        bothStartingGrabbed++;
    }

    private void Update()
    {
        if (!EnemySpawner.main.checkItemsSpawned() && bothStartingGrabbed < 2)
        {
            EnemySpawner.main.SetItemsSpawned(true);
            LevelManager.main.gameObject.GetComponent<ItemGrabber>().StartingItems();
            bothStartingGrabbed++;
        }
    }

    public void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedTower()
    {
        return main.towerPrefabs[main.selectedReward];
    }

    public void selectReward(int rewardNum)
    {
        main.selectedReward = rewardNum;
        if (!(rewardNum == 0) && !(rewardNum == 1) && !(rewardNum == 2) && !(rewardNum == 1001))
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
        main.towerList.Add(main.towerPrefabs[main.selectedReward]);
        towerCountPrefab.GetComponent<Text_Updates>().updateText();
    }

    public int getSelectedTowerIndex()
    {
        return main.selectedReward;
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
            if (selectedReward != 1001)
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
        selectedReward = num;
    }

    
}
