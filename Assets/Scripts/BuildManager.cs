using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    [SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private GameObject[] upgradePrefabs;
    [SerializeField] private GameObject deletionTrackerPrefab;
    [SerializeField] private Image upgradeImage;

    private int selectedReward = 0;
    private int placeableTowers = 0;
    private int usableUpgrades = 0;
    public int tempValue = 0;
    public List<GameObject> towerList = new();
    public List<int> upgradeList = new();
    private int bothStartingGrabbed = 0;
    private int actualTowerSelect;
    private int currentUpgradeSelected;
    private int lastUpgradeSelected;

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
            currentUpgradeSelected = rewardNum;
            main.upgradeList.Add(rewardNum);
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
    }

    public void increaseTower()
    {
        main.placeableTowers++;
        main.towerList.Add(main.towerPrefabs[main.selectedReward]);
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

    public void UseUpgrade()
    {

    }

    public void SwitchUpgrade(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        { return; }

        bool changedUpgrade = false;
        if (main.upgradeList.Count > 1)
        {
            for (int i = 0; i < main.upgradeList.Count; i++)
            {
                if (main.upgradeList[i] != currentUpgradeSelected && !changedUpgrade && main.upgradeList[i] != lastUpgradeSelected)
                {
                    lastUpgradeSelected = currentUpgradeSelected;
                    currentUpgradeSelected = main.upgradeList[i];
                    changedUpgrade = true;

                    if (currentUpgradeSelected == 3)
                    {

                    }
                }
            }
        }

    }

    
}
