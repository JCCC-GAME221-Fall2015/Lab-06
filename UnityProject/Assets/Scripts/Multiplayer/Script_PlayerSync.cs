using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Script_PlayerSync : NetworkBehaviour {

    [SyncVar]
    Vector3 syncedPosition;
    [SyncVar]
    Quaternion syncedRotation;

    #region variables
    [Header("\tReference Values")]
    public Transform myTransform;

    [Header("\tValues for Client Management")]
    [Header("Player")]
    public Rigidbody myRigidbody;
    public CapsuleCollider myCollider;
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController myController;
    [Header("Camera")]
    public GameObject myCameraObject;
    public Camera myCamera;
    public AudioListener myListener;

    [Header("\tSync Values")]
    [Header("Rotation")]
    public float rotationLerpRate = 15f;
    public float rotationThreshold = 5f;
    [Header("Position")]
    public float positionLerpRate = 15f;
    public float positionThreshold = 0.3f;

    Quaternion lastPlayerRotation;
    Vector3 lastPlayerPosition;
    #endregion

    void Start()
    {

    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update ()
    {

	}

    #region rotation
    [Client]
    void TransmitRotation()
    {

    }

    [Command]
    void CmdSendRotationToServer(Quaternion rotationToSend)
    {
    }


    void LerpRotation()
    {
    }
    #endregion

    #region position
    [Client]
    void TransmitPosition()
    {

    }

    [Command]
    void CmdSendPositionToServer(Vector3 positionToSend)
    {
    }

    void LerpPosition()
    {

    }
    #endregion
}
