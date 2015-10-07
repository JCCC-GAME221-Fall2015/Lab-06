using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ScriptPlayerHealth : NetworkBehaviour {

    [SyncVar]
    int syncedHealth;

    int playerHealth = 10;

    string PlayerName
    {
        get;
        set;
    }

	// Use this for initialization
	void Start () 
    {
        StartCoroutine("PlayerHealth");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(isLocalPlayer)
        {
            TransmitHealth();
        }
	}

    IEnumerator PlayerHealth()
    {
        Debug.Log(PlayerName + " " + playerHealth);
        new WaitForSeconds(2);
        yield return StartCoroutine("PlayerHealth");
    }

    [Client]
    void TransmitHealth()
    {
        if(playerHealth != syncedHealth)
        {
            CmdSendHealth(playerHealth);
        }
    }

    [Command]
    void CmdSendHealth(int health)
    {
        syncedHealth = health;
    }

    void TakeDamage()
    {
        playerHealth--;
    }

    void TakeHealing()
    {
        playerHealth++;
    }

    void SomethingHappened(string happening)
    {

    }
}
