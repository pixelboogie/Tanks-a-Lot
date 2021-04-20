using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateEnemyTracks : MonoBehaviour
{
   
    public GameObject[] Track;
    private float SwitchTrackTime = 0.2f;
    private float NextSwitch = 0;

 

    // Update is called once per frame
    void Update()
    {
       
            if (NextSwitch < Time.time)
            {
                NextSwitch = Time.time + SwitchTrackTime;
                if (Track[0].activeSelf == true)
                {
                    Track[0].SetActive(false);
                    Track[1].SetActive(true);
                }
                else if (Track[1].activeSelf == true)
                {
                    Track[1].SetActive(false);
                    Track[0].SetActive(true);
                }
            }
    }
}
