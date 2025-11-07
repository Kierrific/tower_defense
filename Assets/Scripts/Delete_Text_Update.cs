using TMPro;
using UnityEngine;

public class Delete_Text_Update : MonoBehaviour
{
    public static Delete_Text_Update main;

    public TMP_Text storeText;
    private TMP_Text textName;

    private void Awake()
    {
        main = this;
    }

    public void Start()
    {
        main.textName = main.storeText;
        main.textName.text = "Inactive";

    }

    public void updateText()
    {
        if (BuildManager.main.getSelectedTowerIndex() == 1001)
        {
            main.textName.text = "Active";
        }
        else
        {
            main.textName.text = "Inactive";
        }
    }
}
