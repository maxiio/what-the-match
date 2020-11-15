using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : MonoBehaviour
{
    
    private bool _ignoreNextCollision = false;
    private int counter = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            if (_ignoreNextCollision == true)
                return;
            
            counter++;
            if (counter == 2)
            {
                if(gameObject.name.Equals("BaseballbatR"))
                    ParticleManager.Instance.DestroyBaseballR();
                
                else if(gameObject.name.Equals("BaseballbatL"))
                    ParticleManager.Instance.DestroyBaseballL();    

                States.Instance.playerState = States.PlayerState.Free;
                gameObject.SetActive(false);
            }
            
            _ignoreNextCollision = true;
            Invoke("AllowCollision",1f);
        }
    }
    
    
    private void AllowCollision()
    {
        _ignoreNextCollision = false;
    }
}
