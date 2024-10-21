using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Observer
{
    bool _playerDead = false;

    [SerializeField]
    GameObject player;
    Rigidbody rb;
    float speed = 2.5f;
    public override void Notify(Subject subject)
    {
        _playerDead = subject.GetComponent<PlayerManager>().isDead;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerDead && player!= null)
        {
            if(Vector3.Magnitude(player.transform.position - transform.position) < 10)
            {
                gameObject.transform.LookAt(player.transform.position);
                rb.velocity = transform.forward * speed;
            }
            
            

        }
    }
}
