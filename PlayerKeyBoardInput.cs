using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyBoardInput : MonoBehaviour
{
    public bool Acceleration { get; set; } = false;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CannonFire = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CannonFire = false;
        }
    }

    private void MoveBarrel()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            MoveBarrelUp = true;
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            MoveBarrelUp = false;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            MoveBarrelDown = true;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            MoveBarrelDown = false;
        }
    }

    private void TurnTower()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TowerTurnLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            TowerTurnLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            TowerTurnRight = true;
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            TowerTurnRight = false;
        }
    }

    private void TurnTank()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TurnLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            TurnLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            TurnRight = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            TurnRight = false;
        }
    }

    private void DriveTank()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Acceleration = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Acceleration = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Reversing = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Reversing = false;
        }
    }
}
