using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tennis : MonoBehaviour
{
    private bool _ignoreNextCollision = false;
    private int counter = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            if (_ignoreNextCollision == true)
                return;
            
            
            if(gameObject.name.Equals("TennisRacketR"))
                ParticleManager.Instance.DestroyBaseballR();
                
            else if(gameObject.name.Equals("TennisRacketL"))
                ParticleManager.Instance.DestroyBaseballL();    

            States.Instance.playerState = States.PlayerState.Free;
            gameObject.SetActive(false);
            
            
            _ignoreNextCollision = true;
            Invoke("AllowCollision",1f);
        }
    }
    
    
    private void AllowCollision()
    {
        _ignoreNextCollision = false;
    }
}
