using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public float health = 50f;
    public GameObject Gun;
    public float speed=0.01f;
    public Transform player;
    public GameObject GameOver;
    Vector3 offset;
    public static int kill=0;
   
 
    public void TakeDamage(float amount)
    {

        health -= amount;
        if(health <= 0f)
        {
            kill++;
            Die();
        }
       
        
    }
    void FixedUpdate()
    {
        MoveEnemy();
        
    }

    public void Start()
    {
        GameOver = UIManager.instance.gameOverPanel;
        player = PlayerManager.instance.Player.transform;
        Gun = PlayerManager.instance.Gun;
       // txt = FindObjectOfType<Text>();
    }

    public void MoveEnemy()
    {
        //Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        

      //  transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.LookAt(player);
        offset = transform.position - player.transform.position;
        if (offset.x <= 0.5f)
        {
            speed = 0;
            
            //Invoke("DoSomething", 20);
           // GameOver.SetActive(true);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            speed = 5f;

        }
       

        
    }

      /* public void OnCollisionEnter2D(Collision2D coll) { 
         if (coll.gameObject.tag == "Player")
          {
            Destroy(gameObject);
          }

          } */

   public  void Die()
    {
        Destroy(gameObject);
    }
   

}
