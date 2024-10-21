using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Observer
{
    private ScoreUI scoreUI;
    bool _playerDead = false;

    [SerializeField]
    GameObject player;
    Rigidbody rb;
    public float speed = 2.5f;
    public int distance = 10;
    public int health = 5;
    public int maxScore = 3;
    public override void Notify(Subject subject)
    {
        _playerDead = subject.GetComponent<PlayerManager>().isDead;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        scoreUI = FindObjectOfType<ScoreUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerDead && player!= null)
        {
            if(Vector3.Magnitude(player.transform.position - transform.position) < distance)
            {
                gameObject.transform.LookAt(player.transform.position);
                rb.velocity = transform.forward * speed;
            }
        }

        if (health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        scoreUI.AddScore(Random.Range(1, maxScore));
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject);
    }
}
