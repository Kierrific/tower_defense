using TMPro;
using UnityEngine;

public class Upgrade_Updates : MonoBehaviour
{
    public static Upgrade_Updates main;

    public TMP_Text textName;
    private TMP_Text storeText;

    private void Awake()
    {
        main = this;
    }

    public void Start()
    {
        main.storeText = main.textName;
        main.storeText.text = "Upgrade Count: ";
        main.textName.text = main.storeText.text + LevelManager.main.gameObject.GetComponent<BuildManager>().getUsableUpgrades();

    }

    public void updateText()
    {
        main.storeText.text = "Upgrade Count: ";
        main.textName.text = main.storeText.text + LevelManager.main.gameObject.GetComponent<BuildManager>().getUsableUpgrades();
    }
}
