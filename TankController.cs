using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
      //Sound
      public AudioSource TurnTowerSource;
      public AudioSource BarrelSource;
      public AudioSource CannonSource;
      public AudioClip TurnTowerSound;
      public AudioClip BarrelSound;
      public AudioClip CannonSound;

      public AudioSource BoostSource;
      public AudioClip BoostSound;

      public AudioSource SteerSource;
      public AudioClip SteerSound;



      //GameObjects
      public GameObject CannonSmoke;
      public GameObject BarrelExit;
      public GameObject Projectile;
      public GameObject TurnTower;
      public GameObject Barrel;
      //input
      //private PlayerKeyBoardInput PlayerInput;
      private PlayerOVRInput PlayerInput;
      //Float variables
      public static float Speed;
      public float TurnSpeed = 8f;
      private float ProjectileSpeed = 10000f;

      //Cannon Timer
      private float CannonTimer = 2f;
      private float nextCannon = 0;


      void Start()
      {
            //PlayerInput = GetComponent<PlayerKeyBoardInput>();
            PlayerInput = GetComponent<PlayerOVRInput>();
      }


      void Update()
      {
            DriveTank();
            TurnTurnTower();
            MoveBarrel();
            FireCannon();

      }

      private void FireCannon()
      {
            if (PlayerInput.CannonFire == true && nextCannon < Time.time)
            {
                  CannonSource.PlayOneShot(CannonSound);
                  CreateCannonSmoke();
                  nextCannon = Time.time + CannonTimer;
                  var firedProjectile = Instantiate(Projectile, BarrelExit.transform.position, BarrelExit.transform.rotation);
                  firedProjectile.GetComponent<Rigidbody>().velocity = BarrelExit.transform.TransformDirection(new Vector3(0, 0, ProjectileSpeed * Time.deltaTime));
                  Destroy(firedProjectile, 5f);
            }
            if (PlayerInput.CannonFire == false)
            {
                  //Fire cannon

            }
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

      private void MoveBarrel()
      {
            if (PlayerInput.MoveBarrelUp == true)
            {
                  if (BarrelSource.isPlaying == false)
                  {
                        BarrelSource.PlayOneShot(BarrelSound);
                  }

                  Barrel.transform.Rotate(0, 0, TurnSpeed / 2 * Time.deltaTime);
            }
            else if (PlayerInput.MoveBarrelDown == true)
            {
                  if (BarrelSource.isPlaying == false)
                  {
                        BarrelSource.PlayOneShot(BarrelSound);
                  }

                  Barrel.transform.Rotate(0, 0, -TurnSpeed / 2 * Time.deltaTime);
            }
            else
            {
                  BarrelSource.Stop();
            }
      }

      private void TurnTurnTower()
      {
            if (PlayerInput.TowerTurnLeft == true)
            {
                  if (TurnTowerSource.isPlaying == false)
                        TurnTowerSource.PlayOneShot(TurnTowerSound);

                  TurnTower.transform.Rotate(0, -TurnSpeed * Time.deltaTime, 0);
            }
            else if (PlayerInput.TowerTurnRight == true)
            {
                  if (TurnTowerSource.isPlaying == false)
                        TurnTowerSource.PlayOneShot(TurnTowerSound);

                  TurnTower.transform.Rotate(0, TurnSpeed * Time.deltaTime, 0);
            }
            else
            {
                  TurnTowerSource.Stop();
            }
      }

      private void DriveTank()
      {
            if (PlayerInput.Boosting)
            {
                  Speed = 25f;


                  if (BoostSource.isPlaying == false)
                  {
                        BoostSource.PlayOneShot(BoostSound);
                  }
            }
            else
            {
                  if (BoostSource.isPlaying == true)
                  {
                        BoostSource.Stop();
                  }
                  Speed = 10f;
            }

            if (PlayerInput.Acceleration == true)
            {

                  // Debug.Log("speed ========================== " + Speed);
                  transform.position += transform.forward * Speed * Time.deltaTime;
                  // if (SteerSource.isPlaying == true)
                  // {
                  //       SteerSource.Stop();
                  // }



            }
            if (PlayerInput.Reversing == true)
            {
                  transform.position += -transform.forward * Speed * Time.deltaTime;
            }
            if (PlayerInput.TurnLeft == true)
            {
                  transform.Rotate(0, -TurnSpeed * Time.deltaTime, 0);
            }

            if (PlayerInput.TurnRight == true)
            {
                  transform.Rotate(0, TurnSpeed * Time.deltaTime, 0);
            }


            if ((PlayerInput.TurnRight == true) || (PlayerInput.TurnLeft == true))
            {
                  if (SteerSource.isPlaying == false)
                  {
                        SteerSource.PlayOneShot(SteerSound);
                  }
            }
            else
            {
                  SteerSource.Stop();
            }


      }
}
