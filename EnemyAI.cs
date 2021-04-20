using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform FirstLocation;
    public Transform SecondLocation;
    private Transform NextLocation;

    public GameObject CannonSmoke;
    public GameObject SearchRayParent;
    public GameObject SearchRay;
    public GameObject TurnTower;
    public GameObject BarrelExit;
    public GameObject Projectile;

    private Transform PlayerTransform;


    private bool HittingPlayer = false;

    public float ProjectileSpeed = 8000f;
    public float TurnTowerSpeed = 3f;
    public float EnemySpeed = 10f;
    public float CannonTimer = 10f;
    private float nextCannon = 0;

    private bool alive;


    void Start()
    {
           alive = true;
        NextLocation = SecondLocation;
    }


    private void CreateCannonSmoke()
    {
        CannonSmoke.SetActive(true);
        Invoke("RemoveSmoke", 0.2f);

    }

    private void RemoveSmoke()
    {
        CannonSmoke.SetActive(false);
    }
   
    void Update()
    {

          if(alive){
        MoveEnemy();
        TurnSearchRay();
        TurnTowerTowardsPlayer();
        }
    }

    private void FireCannon()
    {
        //CannonSource.PlayOneShot(CannonSound);
        if(nextCannon < Time.time)
        {
            CreateCannonSmoke();
            nextCannon = Time.time + CannonTimer;
            var firedProjectile = Instantiate(Projectile, BarrelExit.transform.position, BarrelExit.transform.rotation);
            firedProjectile.GetComponent<Rigidbody>().velocity = BarrelExit.transform.TransformDirection(new Vector3(0, 0, ProjectileSpeed * Time.deltaTime));
            Destroy(firedProjectile, 5f);

        }
    }

    private void TurnTowerTowardsPlayer()
    {
        if (HittingPlayer == true)
        {
            var targetLocation = Quaternion.LookRotation(PlayerTransform.transform.position - TurnTower.transform.position);
            TurnTower.transform.rotation = Quaternion.Slerp(TurnTower.transform.rotation, targetLocation, TurnTowerSpeed * Time.deltaTime);
            Invoke("FireCannon", 2f);
            
        }
    }

    private void TurnSearchRay()
    {
        if (HittingPlayer == false)
        {
            SearchRayParent.transform.Rotate(0, 1, 0);
            
        }

        RaycastHit hitLocationInfo;
        Vector3 forward = SearchRayParent.transform.TransformDirection(Vector3.forward);
        var hittingSomething = Physics.Raycast(SearchRay.transform.position, forward, out hitLocationInfo, 1000);
        if (hittingSomething)
        {
            if (hitLocationInfo.collider.transform.root.CompareTag("Player") == true)
            //  if (hitLocationInfo.collider.CompareTag("Player") == true)
            {
                PlayerTransform = hitLocationInfo.collider.transform;
                HittingPlayer = true;
            }

        }
        else
        {
            HittingPlayer = false;
        }

      //   Debug.DrawRay(SearchRay.transform.position, forward * 1000, Color.green, 10, true);
    }

    private void MoveEnemy()
    {
        var distance = Vector3.Distance(transform.position, NextLocation.position);
        if (distance < 1f)
        {
            if (NextLocation == SecondLocation)
            {
                NextLocation = FirstLocation;
            }
            else
            {
                NextLocation = SecondLocation;
            }
        }
        transform.LookAt(NextLocation);
        float step = EnemySpeed * Time.deltaTime;

        if(HittingPlayer == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, NextLocation.position, step);
        }
      
    }


    public void setDead(){
          this.alive = false;
    }
}
