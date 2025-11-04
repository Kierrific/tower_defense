using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Chance")]
    public int chance;

    public int getChance()
    {
        return chance;
    }
}
