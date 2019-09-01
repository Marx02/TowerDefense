using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 5.0f;
    public float startHealth = 100;
    private float health;
    public Image healthBar;



    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        
    }

    public void takeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }



   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "END")
        {
            Destroy(agent.gameObject);
            Debug.Log("Object hit finish");
        }
        
    }

}
