using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerManager : Subject
{
    public int currentHealth { get { return health; } }
    public int currentScore { get { return score; } }
    public bool isDead { get; private set; }

    [SerializeField]
    private int health = 100;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onDie()
    {
        NotifyObservers();
    }

    public void scoreChange()
    {
        NotifyObservers();
    }

    public void onHealthChange()
    {
        NotifyObservers();
    }
}