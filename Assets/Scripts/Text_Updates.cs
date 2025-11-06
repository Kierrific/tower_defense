using TMPro;
using UnityEditor;
using UnityEngine;

public class Text_Updates : MonoBehaviour
{
    //had to split this script into two because it just refused to register the other text box I had for upgrades.
    public static Text_Updates main;

    public TMP_Text textName;
    private TMP_Text storeText;

    private void Awake()
    {
        main = this;
    }

    public void Start()
    {
        main.storeText = main.textName;
        main.storeText.text = "Tower Count: ";
        main.textName.text = main.storeText.text + LevelManager.main.gameObject.GetComponent<BuildManager>().getPlaceableTowers();
        
    }

    public void updateText()
    {
        main.storeText.text = "Tower Count: ";
        main.textName.text = main.storeText.text + LevelManager.main.gameObject.GetComponent<BuildManager>().getPlaceableTowers();
    }

}

    
