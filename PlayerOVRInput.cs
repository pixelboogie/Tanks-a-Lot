using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOVRInput : MonoBehaviour
{
      public bool Acceleration { get; set; } = false;

       public bool Boosting { get; set; } = false;
      public bool Reversing { get; set; } = false;
      public bool TurnLeft { get; set; } = false;
      public bool TurnRight { get; set; } = false;
      public bool TowerTurnLeft { get; set; } = false;
      public bool TowerTurnRight { get; set; } = false;

      public bool MoveBarrelUp { get; set; } = false;
      public bool MoveBarrelDown { get; set; } = false;
      public bool CannonFire { get; set; } = false;
      // Update is called once per frame
      void Update()
      {
            DriveTank();
            TurnTank();
            TurnTower();
            MoveBarrel();
            FireCannon();

      }

      private void FireCannon()
      {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) ||
                OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
            {
                  CannonFire = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) ||
               OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
            {
                  CannonFire = false;
            }
      }

      private void MoveBarrel()
      {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.LTouch))
            {
                  MoveBarrelUp = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.LTouch))
            {
                  MoveBarrelUp = false;
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.LTouch))
            {
                  MoveBarrelDown = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.LTouch))
            {
                  MoveBarrelDown = false;
            }
      }

      private void TurnTower()
      {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch))
            {
                  TowerTurnLeft = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.LTouch))
            {
                  TowerTurnLeft = false;
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch))
            {
                  TowerTurnRight = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.LTouch))
            {
                  TowerTurnRight = false;
            }
      }

      private void TurnTank()
      {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
            {
                  TurnLeft = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
            {
                  TurnLeft = false;
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
            {
                  TurnRight = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
            {
                  TurnRight = false;
            }
      }

      private void DriveTank()
      {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.RTouch))
            {
                  Acceleration = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp, OVRInput.Controller.RTouch))
            {
                  Acceleration = false;
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
            {
                  Reversing = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
            {
                  Reversing = false;
            }


            // turbo boos
            // if ((OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.RTouch))  > 0)
                if (OVRInput.GetDown(OVRInput.RawButton.X))
            {
                  Boosting = true;
                  // TankController.Speed = 30f;
                  // Debug.Log("got it -----------------------------------");
            }
                if (OVRInput.GetUp(OVRInput.RawButton.X))
            {
                  Boosting = false;
                  // TankController.Speed = 10f;
                  // Debug.Log("got it -----------------------------------");
            }


            //   if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.RTouch))
            //   {
            //        TankController.Speed = 10f;
            //   }


      }
}
