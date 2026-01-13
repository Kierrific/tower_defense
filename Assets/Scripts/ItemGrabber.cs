using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemGrabber : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] itemPrefabs;

    private int randomNumber;
    private int itemIndex;
    private List<GameObject> itemBoxes = new();
    // ^this is so I can keep which item has the lowest chance that is eligible to be picked
    // (ex: if randomNumber rolls a 10, the item with a 10 chance instead of 90 would be picked)


    public void Trigger()
    {
        itemBoxes.Clear();

        randomNumber = Random.Range(1, 1001);
        itemIndex = 0;
        for (int i = 1; i < itemPrefabs.Length; i++)
        {
            //I hope I'm doing this right
            if (itemPrefabs[itemIndex].gameObject.GetComponent<Item>().getChance() > itemPrefabs[i].gameObject.GetComponent<Item>().getChance() && randomNumber <= itemPrefabs[i].gameObject.GetComponent<Item>().getChance())
            {
                itemIndex = i;
            }
            
        }

        GameObject firstItemBox = Instantiate(itemPrefabs[itemIndex], spawnPoint.position, Quaternion.identity);
        firstItemBox.transform.SetParent(GameObject.FindGameObjectWithTag("Upgrades").transform, false);

        itemBoxes.Add(firstItemBox);

        randomNumber = Random.Range(1, 1001);
        itemIndex = 0;
        for (int i = 1; i < itemPrefabs.Length; i++)
        {
            
            if (itemPrefabs[itemIndex].gameObject.GetComponent<Item>().getChance() > itemPrefabs[i].gameObject.GetComponent<Item>().getChance() && randomNumber <= itemPrefabs[i].gameObject.GetComponent<Item>().getChance())
            {
                itemIndex = i;
            }

        }

        GameObject secondItemBox = Instantiate(itemPrefabs[itemIndex], spawnPoint.position, Quaternion.identity);
        secondItemBox.transform.SetParent(GameObject.FindGameObjectWithTag("Upgrades").transform, false);

        itemBoxes.Add(secondItemBox);

        randomNumber = Random.Range(1, 1001);
        itemIndex = 0;
        for (int i = 1; i < itemPrefabs.Length; i++)
        {
            
            if (itemPrefabs[itemIndex].gameObject.GetComponent<Item>().getChance() > itemPrefabs[i].gameObject.GetComponent<Item>().getChance() && randomNumber <= itemPrefabs[i].gameObject.GetComponent<Item>().getChance())
            {
                itemIndex = i;
            }

        }

        GameObject thirdItemBox = Instantiate(itemPrefabs[itemIndex], spawnPoint.position, Quaternion.identity);
        thirdItemBox.transform.SetParent(GameObject.FindGameObjectWithTag("Upgrades").transform, false);

        itemBoxes.Add(thirdItemBox);
    }

    public void itemGrabbed()
    {
        foreach(GameObject item in itemBoxes)
        {
            Destroy(item);
        }
    }

    public void StartingItems()
    {
        GameObject firstTurret = Instantiate(itemPrefabs[0], spawnPoint.position, Quaternion.identity);
        firstTurret.transform.SetParent(GameObject.FindGameObjectWithTag("Upgrades").transform, false);
        itemBoxes.Add(firstTurret);

        GameObject secondTurret = Instantiate(itemPrefabs[1], spawnPoint.position, Quaternion.identity);
        secondTurret.transform.SetParent(GameObject.FindGameObjectWithTag("Upgrades").transform, false);
        itemBoxes.Add(secondTurret);
    }
}
