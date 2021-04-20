using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public AudioSource ExplosionSource;
    public AudioClip ExplosionSound;

          public AudioClip KillSound;
    public GameObject Explosion;

    private void OnCollisionEnter(Collision collision)
      // private void OnTriggerEnter(Collider collision)
    {

      //     Debug.Log("Hit ---------------------------------");
            // if (collision.transform.root.CompareTag("Player"))
           if (collision.gameObject.CompareTag("Player"))
            {
                  //   Debug.Log("Hit Player ===========================");
                    Scoreboard.damageCount++;
                  ExplosionSource.PlayOneShot(KillSound);
            }

           if (collision.gameObject.CompareTag("Enemy"))
            {
                  //  Debug.Log("Hit Enemy ++++++++++++++++++++++++++++");
                    Scoreboard.hitCount++;

                       Destroy(collision.gameObject, 1f);       

                          ExplosionSource.PlayOneShot(KillSound);

                  //      collision.gameObject.alive = false;
                  //  collision.gameObject.setDead();
            }

            // if (collision.gameObject.CompareTag("Terrain"))
            // {
       
            //       Debug.Log("Hit Terrain !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                   
            // }


      //      if (collision.CompareTag("Player"))
      //       {
      //               Scoreboard.damageCount++;
      //       }

      //      if (collision.CompareTag("Enemy"))
      //       {
      //               Scoreboard.hitCount++;
      //       }
  
        ExplosionSource.PlayOneShot(ExplosionSound);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Explosion.SetActive(true);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 5.0f);
    }
}
