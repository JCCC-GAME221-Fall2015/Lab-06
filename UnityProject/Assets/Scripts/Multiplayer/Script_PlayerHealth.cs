using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Script_PlayerHealth : NetworkBehaviour
{
    [SyncVar]
    public int syncHealth;

    public string playerName;  // Holds the player name
    private int playerHealth = 100;     // Holds the players health

    public Text playerNameText;         // Text field that displays the players health.
    public Button addHealthButton;      // Button to add health
    public Button removeHealthButton;   // Button to remove health

    void Start()
    {
        playerNameText = GameObject.Find("TextPlayerName").GetComponent<Text>();
        addHealthButton = GameObject.Find("ButtonAddHealth").GetComponent<Button>();
        removeHealthButton = GameObject.Find("ButtonRemoveHealth").GetComponent<Button>();

        addHealthButton.onClick.AddListener(BtnAddHealth);

        removeHealthButton.onClick.AddListener(BtnRemoveHealth);

        if (playerName == "")
            playerName = "Host";

        playerNameText.text = playerName;

        InvokeRepeating("PrintHealth", 0f, 2f);
    }

    void PrintHealth()
    {
        Debug.Log("Health: " + playerHealth);
    }

    void BtnAddHealth()
    {
        playerHealth += 10;
        CmdSendHealthToServer(playerHealth);
    }

    void BtnRemoveHealth()
    {
        playerHealth -= 10;
        CmdSendHealthToServer(playerHealth);
    }

    [Command]
    void CmdSendHealthToServer(int healthToSend)
    {
        syncHealth = healthToSend;
    }
}
