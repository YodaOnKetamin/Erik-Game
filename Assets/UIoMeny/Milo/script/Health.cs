using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    // det b�rjar p� full health s� det beh�vs bara 2 i script
    public Sprite twoHealth;
    public Sprite oneHealth;
    
    // byt ut detta med vad den faktiska variabeln f�r att �ndra health �r
    int tempHealth;

    // Update is called once per frame
    void Update()
    {
        // om health �r x/3 s� byter det sprite till vi skrev d�r uppe. 
        if (tempHealth == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = twoHealth;
        }

        if (tempHealth == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = oneHealth;
        }
    }
}
