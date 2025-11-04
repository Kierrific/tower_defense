using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    private void Awake()
    {
        main = this;
    }
}
