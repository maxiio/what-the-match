using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : MonoBehaviour
{
    
    private int counter = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            
            /*if(gameObject.name.Equals("BaseballbatR"))
                ParticleManager.Instance.DestroyBaseballR();
                
            else if(gameObject.name.Equals("BaseballbatL"))
                ParticleManager.Instance.DestroyBaseballL();*/

            StartCoroutine(DestroyObject());
        }
    }
    
    public IEnumerator DestroyObject()
    {
        yield return  new WaitForSeconds(.7f);
        
        States.Instance.playerState = States.PlayerState.Free;
        gameObject.SetActive(false);
        
    }
}
