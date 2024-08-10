# Tanks-a-Lot

## Description
**Tanks-a-Lot** is a Virtual Reality (VR) first-person tank game that I developed to explore the dynamics of tank combat in a VR environment. In this action-oriented tactical game, you operate and drive a tank, using strategy and terrain to battle enemy tanks. The game is built using Unity, C#, and Oculus Integration, and it is fully playable on Oculus Rift and Quest devices.

Key features include the ability to hunt and keep score against enemy tanks, the use of basic artificial intelligence for enemy tanks, and immersive VR controls for operating the tank and its weaponry.

## Features
- **Fully Playable VR Game**: Engage in tank battles in a VR environment.
- **Operate and Drive a VR Tank**: Control the tank's movement, turret, and cannon using intuitive VR controls.
- **Hunt and Keep Score**: Track your success as you battle enemy tanks.
- **Supported on Oculus Rift & Quest**: Optimized for popular VR devices.
- **Basic AI for Enemy Tanks**: Enemy tanks use basic AI to challenge the player.

## Installation
To use the C# scripts in your own Unity project, follow these steps:

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/Tanks-a-Lot.git
   cd Tanks-a-Lot


2. **Integrate into Unity::**

    - Open your Unity project.
    - Copy the C# scripts from this repository into your project's Assets/Scripts directory.

3. **Configure the Scene::**

    - Set up your scene with the necessary game objects, such as the tank, environment, and enemy tanks.
    - Assign the scripts to the appropriate game objects in the Unity Editor.

4. **Build and Deploy:**

    - Build the project for the Oculus Rift or Quest.
    - Deploy and test the game in your VR environment.

## Example Code: FireCannon ##

Here’s a code sample to help explain the technology and techniques used in the game:

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
    }

This function controls the firing of the tank's cannon, including playing sound effects, generating smoke, and managing the timing and trajectory of fired projectiles.

## License ##
This project is licensed under the MIT License. See the LICENSE file for more information.
