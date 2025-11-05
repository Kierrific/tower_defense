using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private GameObject levelManager;

    private GameObject tower;
    private Color startColor;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null || BuildManager.main.getPlaceableTowers() == 0)
        {
            if (BuildManager.main.getSelectedTowerIndex() == 2 && BuildManager.main.getUsableUpgrades() > 0)
            {
                tower.GetComponent<Turret>().addMultiplier(2);
                BuildManager.main.lowerUpgrades();
                return;
            }
            else if (BuildManager.main.getSelectedTowerIndex() == 3 && BuildManager.main.getUsableUpgrades() > 0)
            {
                tower.GetComponent<Turret>().addBPS(1);
                BuildManager.main.lowerUpgrades();
                return;
            }
            else if (BuildManager.main.getSelectedTowerIndex() == 1001)
            {
                Destroy(tower);
                BuildManager.main.increaseTower();
            }
                return;
        }
        GameObject towerToBuild = BuildManager.main.GetSelectedTower();
        BuildManager.main.lowerTower();
        tower = Instantiate(towerToBuild, transform.position, Quaternion.identity);
    }
}
