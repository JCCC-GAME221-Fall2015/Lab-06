using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Script_PlayerHealth : NetworkBehaviour 
{
    int playerHealth;

    public Text playerHealthText;

	// Use this for initialization
	void Start () 
    {
        if (isLocalPlayer)
        {
            playerHealth = 100;
        }
        InvokeRepeating("SendHealthDebug", 0f, 2f);
	}
	
	// Update is called once per frame
	void Update () 
    {
        DisplayHealth();
	}

    void DisplayHealth()
    {
        playerHealthText.text = playerHealth.ToString();
    }

    void SendHealthDebug()
    {
        Debug.Log("Player Name " + playerHealth.ToString());
    }

    [Command]
    void CmdSendHealthToServer(int damageToSend, int healToSend)
    {
        playerHealth -= damageToSend;
        playerHealth += healToSend;
    }

    public void TakeDamage()
    {
        if (isLocalPlayer)
        {
            if (playerHealth > 0)
            {
                CmdSendHealthToServer(10, 0);
            }
        }
    }

    public void HealPlayer()
    {
        if (isLocalPlayer)
        {
            if (playerHealth < 100)
            {
                CmdSendHealthToServer(0, 10);
            }
        }
    }
}
