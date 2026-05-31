using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private variables
    private Rigidbody playerRb;

    // Public variables
    public float oxygen = 100.0f;
    public float walkSpeed = 6.0f;
    public float jumpPower = 10.0f;
    public float gravityModifier = 2f;
    public bool isOnGround = true;
    public GameObject map;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Sets information for map name, difficulty, map creator, links rigidbody to its variable, & gravity is modified.
        int curDif;
        string info;
        curDif = map.GetComponent<MapSettings>().difficulty;
        info = map.GetComponent<MapSettings>().mapName + " [" + map.GetComponent<DifficultyBehavior>().difficultyNames[curDif] + "] by " + map.GetComponent<MapSettings>().creator;
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        Debug.Log(info);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Apply force to the Rigidbody to move the player.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * walkSpeed * verticalInput);
        playerRb.AddForce(Vector3.right * walkSpeed * horizontalInput);
        // Detects when the player hits the space bar to jump.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    // Detects when the player hits the ground
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
