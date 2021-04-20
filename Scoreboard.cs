using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{

      public static int hitCount;
      public static int damageCount;
       public TextMeshPro hitsTXT;
       public TextMeshPro damageTXT;


    void Start()
    {
        hitCount = 0;
        damageCount = 0;
    }

    void Update()
    {
      hitsTXT.text = hitCount.ToString();
      damageTXT.text = damageCount.ToString();
    }
}
