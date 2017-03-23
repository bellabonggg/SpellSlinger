using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : NetworkBehaviour {

    public GameObject bulletPrefab;

    //stats (movement speed, spells)
    public float moveSpeed = 5;
    public string[] spellList = new string[4] { "Fireball", "Iceball", "Earthwall", "Debuff" };
    public float[] spellCooldown = new float[4] { 0, 0, 0, 0 };

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

        joystick = GameObject.Find("Joystick").GetComponent<VirtualJoystick>();
        playerRigidBody = GetComponent<Rigidbody>();

        button0 = GameObject.Find("Cast0").GetComponent<Button>();
        Debug.Log("AddingListener");
        button0.onClick.AddListener(CmdCast0);

        button1 = GameObject.Find("Cast1").GetComponent<Button>();
        button1.onClick.AddListener(CmdCast1);

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
 
    [Command]
    public void CmdCast1()
    {
        Debug.Log("Preparing to cast");

        if (spellCooldown[0] == 0)
        {
            Debug.Log("Casting");
            //GameObject spellPrefab = Resources.Load("Spell", typeof(GameObject)) as GameObject;

            var spell = (GameObject)Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            spell.GetComponent<Rigidbody>().velocity = spell.transform.forward * 6;

            //spellCooldown[0] = 1;
            NetworkServer.Spawn(spell);
            Destroy(spell, 2.0f);
        }
    }
}
