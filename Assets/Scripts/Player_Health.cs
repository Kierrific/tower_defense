using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public static Player_Health main;
    
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject health_counter_prefab;

    [Header("Attributes")]
    [SerializeField] private int health = 20;

    private void Awake()
    {
        main = this;
    }

    public void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }

    public void takeDamage()
    {
        main.health = main.health - 1;
        health_counter_prefab.GetComponent<Health_Text_Updates>().updateText();
    }

    public int getHealth()
    {
        return main.health;
    }
}
