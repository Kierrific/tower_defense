using TMPro;
using UnityEngine;

public class Health_Text_Updates : MonoBehaviour
{
    public static Health_Text_Updates main;

    public TMP_Text textName;

    private void Awake()
    {
        main = this;
    }

    public void Start()
    {
        main.textName.text = LevelManager.main.GetComponent<Player_Health>().getHealth().ToString();

    }

    public void updateText()
    {
        main.textName.text = LevelManager.main.GetComponent<Player_Health>().getHealth().ToString();
    }
}
