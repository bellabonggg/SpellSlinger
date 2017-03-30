using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : NetworkBehaviour {

    //public Camera followPlayerCamera;

    //stats (movement speed, spells)
    public float moveSpeed = 5;
    public List<string> spellList = new List<string>();
    public List<string> spellCooldown = new List<string>();
    string playerName;

    //private List<IBuffable> buffList = new List<IBuffable>();

    //other supporting vars
    private Vector3 moveVelocity;
 
    //objects (for reference to objects in game)
    public Rigidbody playerRigidBody;
    public Transform spawnPoint;
    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;

    //control (to control player)
    public VirtualJoystick joystick;
    private Vector3 moveInput;

    // Use this for initialization
    private void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        spellList = 

        joystick = GameObject.Find("Joystick").GetComponent<VirtualJoystick>();
        playerRigidBody = GetComponent<Rigidbody>();

        button0 = GameObject.Find("Cast0").GetComponent<Button>();
        Debug.Log("AddingListener");
        button0.onClick.AddListener(CmdCast0);

        button1 = GameObject.Find("Cast1").GetComponent<Button>();
        //button1.onClick.AddListener(CmdCast1);

        button2 = GameObject.Find("Cast2").GetComponent<Button>();
        // button2.onClick.AddListener(() => Cast(2));

        button3 = GameObject.Find("Cast3").GetComponent<Button>();
        //button3.onClick.AddListener(() => Cast(3));
    }


    // Update is called once per frame
    void Update ()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        Move();
        /*
        Vector3 cameraVector = new Vector3(playerRigidBody.transform.position.x, followPlayerCamera.transform.position.y, playerRigidBody.transform.position.z);

        followPlayerCamera.transform.position = cameraVector;
        */

    }

    public void Move()
    {
        moveInput = joystick.getInput();
        moveVelocity = moveInput * moveSpeed;
        playerRigidBody.velocity = moveVelocity;

        //make the player look at the right direction
        transform.LookAt(transform.position + 10 * moveInput);
    }

    [Command]
    public void CmdCast0()
    {
        Debug.Log("Preparing to cast");

        if (spellCooldown[0]==0)
        {
            Debug.Log("Casting");
            GameObject spellPrefab = Resources.Load(spellList[0], typeof(GameObject)) as GameObject;

            var spell = (GameObject)Instantiate(spellPrefab, spawnPoint.position, spawnPoint.rotation);

            if (!NetworkServer.localClientActive)
            {
                Debug.Log("It is not active on server");
            }

            //spellCooldown[0] = 1;
            NetworkServer.Spawn(spell);
        }
    }
 
}
