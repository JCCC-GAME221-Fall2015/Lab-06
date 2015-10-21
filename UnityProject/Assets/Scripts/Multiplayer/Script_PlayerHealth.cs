using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Script_PlayerHealth : NetworkBehaviour
{
    [SyncVar]
    public int syncHealth;              // Synced variable to hold the players health

    public string playerName;           // Holds the player name
    private int playerHealth = 100;     // Holds the players health

    public Text playerNameText;         // Text field that displays the players health.
    public Button addHealthButton;      // Button to add health
    public Button removeHealthButton;   // Button to remove health

    // @author: Nathan Boehning
    // @summary: Displays the player name and debugs the players life every two seconds.
    //           Keeps the players life synced inside of the server.
    void Start()
    {
        // Finds the various UI elements within the scene when its created
        playerNameText = GameObject.Find("TextPlayerName").GetComponent<Text>();
        addHealthButton = GameObject.Find("ButtonAddHealth").GetComponent<Button>();
        removeHealthButton = GameObject.Find("ButtonRemoveHealth").GetComponent<Button>();

        // Adds event listeneres that calls their respective functions
        // to add and remove health
        addHealthButton.onClick.AddListener(BtnAddHealth);

        removeHealthButton.onClick.AddListener(BtnRemoveHealth);

        // Sets the player name to host if it doesn't have a name
        if (playerName == "")
            playerName = "Host";

        // Sets the text of the text field to the player name
        playerNameText.text = playerName;

        // Invokes a function every 2 seconds that displays the current health of the player
        // in the console.
        InvokeRepeating("PrintHealth", 0f, 2f);
    }

    void PrintHealth()
    {
        // Debug the players health
        Debug.Log("Health: " + playerHealth);
    }

    [Client]
    void BtnAddHealth()
    {
        // Adds health to the local player, and sends a command to update the players health 
        // within the server.
        if (isLocalPlayer)
        {
            playerHealth += 10;
            CmdSendHealthToServer(playerHealth);
        }
    }

    [Client]
    void BtnRemoveHealth()
    {
        // Removes health from the loca player, and sends a command to update the players heath
        // within the server
        if (isLocalPlayer)
        {
            playerHealth -= 10;
            CmdSendHealthToServer(playerHealth);
        }
    }

    // Sets the synced variable to the updated player health
    [Command]
    void CmdSendHealthToServer(int healthToSend)
    {
        syncHealth = healthToSend;
    }
}
