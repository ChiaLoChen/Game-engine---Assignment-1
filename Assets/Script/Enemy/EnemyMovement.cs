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
    public int distance = 50;
    public int health = 5;
    public int maxScore = 3;

    bool run = false;
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
                run = true;
            }
            else
            {
                StartCoroutine(runStop());
            }
        }
        if (health <= 0)
        {
            Die();
        }

        if (run)
        {
            gameObject.transform.LookAt(player.transform.position);
            rb.AddForce(-transform.forward.normalized * speed * 10f * Time.deltaTime, ForceMode.Force);
        }
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        scoreUI.OnEnemyDeath();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            rb.AddForce(transform.up.normalized * 5 * 200f, ForceMode.Force);
        }
    }

    IEnumerator runStop()
    {
        yield return new WaitForSeconds(5);
        run = false;
    }
}
