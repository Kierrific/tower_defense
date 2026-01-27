using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject dimPrefab;
    [SerializeField] private GameObject levelManager;

    private GameObject tower;
    private GameObject dimmer;
    private Color startColor;

    private void OnMouseEnter()
    {
        dimmer = Instantiate(dimPrefab, transform.position, Quaternion.identity);
    }

    private void OnMouseExit()
    {
        Destroy(dimmer);
    }

    private void OnMouseDown()
    {
        if (!EnemySpawner.main.checkItemsSpawned())
        {
            if (tower != null || BuildManager.main.getPlaceableTowers() == 0)
            {
                if (BuildManager.main.getSelectedTowerIndex() == 3 && BuildManager.main.getUsableUpgrades() > 0)
                {
                    tower.GetComponent<Turret>().addMultiplier(2);
                    BuildManager.main.lowerUpgrades();
                    return;
                }
                else if (BuildManager.main.getSelectedTowerIndex() == 4 && BuildManager.main.getUsableUpgrades() > 0)
                {
                    tower.GetComponent<Turret>().addBPS(0.1f);
                    BuildManager.main.lowerUpgrades();
                    return;
                }
                else if (BuildManager.main.getSelectedTowerIndex() == 5 && BuildManager.main.getUsableUpgrades() > 0)
                {
                    tower.GetComponent<Turret>().addDamage(2);
                    BuildManager.main.lowerUpgrades();
                    return;
                }
                else if (BuildManager.main.getSelectedTowerIndex() == 1001)
                {
                    int id = tower.GetComponent<Turret>().getIdentifier();
                    BuildManager.main.setSelectedTower(id);
                    Destroy(tower);
                    BuildManager.main.increaseTower();
                    BuildManager.main.setSelectedTower(1001);
                }
                return;
            }
            if (BuildManager.main.getSelectedTowerIndex() != 1001)
            {
                GameObject towerToBuild = BuildManager.main.getTowerList()[^1];
                BuildManager.main.lowerTower();
                tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
            }
            
        }
        
    }
}
