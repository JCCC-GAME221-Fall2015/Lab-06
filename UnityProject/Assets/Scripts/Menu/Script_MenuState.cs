﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

public enum MenuStates
{
    MENU_MAIN,
    MENU_CONNECT,
    MENU_SETUP,
    MENU_QUITTING,
    SETUP_STARTING_HOST,
    SETUP_STARTING_SERVER,
    CONNECT_CONNECTING_TO_SERVER
}

public enum MenuCommands
{
    GOTO_CONNECT,
    GOTO_SETUP,
    GOTO_MAIN,
    QUIT_APPLICATION,
    SETUP_HOST,
    SETUP_SERVER,
    CONNECT_CLIENT
}

public class Script_MenuState : MonoBehaviour {

    Dictionary<MenuTransitions, MenuStates> allTransitions; //A  dictionary for all state transitions

    Dictionary<string, MenuCommands> enumParse;

    public MenuStates CurrentState { get; private set; }    //A property to store the current state of the machine
    public MenuStates PreviousState { get; private set; }   //A property to store the previous state of the machine

    public GameObject mainMenu;                             //A reference to the main menu game object for menu navigation
    public GameObject connectMenu;                          //A reference to the connect menu game object for menu navigation
    public GameObject setupMenu;                            //A reference to the setup menu game object for menu navigation
    public NetworkManager manager;                          //A reference to the network manager for managing connections

    // Use this for initialization
    void Start () {

        //Setup the current state to be main
        CurrentState = MenuStates.MENU_MAIN;

        //Setup the previous state to be connect
        PreviousState = MenuStates.MENU_CONNECT;

        //Create the dictionary 
        allTransitions = new Dictionary<MenuTransitions, MenuStates>
        {
            //Defines the state transitions where
            //{ new MenuTransition(actual state of the machine, transition state/command), final state of the machine) }

        };

        //Create the dictionary where
        //{string that is passed by the button, command the string represets}
        enumParse = new Dictionary<string, MenuCommands>
        {

        };

        Debug.Log("Curr state = " + CurrentState);
    }

    /// <summary>
    /// Gets the next state if a given command/transition is run
    /// </summary>
    /// <param name="command">The command (or transition) to run</param>
    /// <returns></returns>
    MenuStates GetNext(MenuCommands command)
    {
        //Construct the new transition based on the machines current state, and the supplied transition/command

        //Location to store the new state for the machine to go into

        //Make sure that the transition is valid, using the dictionary lookup

        //If at this point we have not broken anything, return the new state
    }

    /// <summary>
    /// Moves the state machine into the next state given a specific command/transition and triggers the transition
    /// </summary>
    /// <param name="command">The command/transition to run the machine through</param>
    public void MoveNextAndTransition(string command)
    {
        //Record the previous state for transition purposes
        
        //Location for the new command

        //Try to get the value

        //Setup the next state 

        //Transition to the next state
    }

    /// <summary>
    /// Will run any neccessary code for the transition from one state to the next
    /// </summary>
    void Transition()
    {

    }

    /// <summary>
    /// Updates the IP on the manager
    /// </summary>
    /// <param name="message">The IP to update to</param>
    public void UpdateIP(Object message)
    {

    }

    public void UpdatePort(Object message)
    {

    }

    public void UpdateName(Object message)
    {

    }
}
