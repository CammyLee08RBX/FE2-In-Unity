using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    public string waterState;
    public int drainMultiplier;
    public int depthMultiplier;
    public bool noSwim;
    public Material waterMaterial;
    public Material acidMaterial;
    public Material lavaMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waterState = waterState.ToLower();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            Invoke("drainOxygen", 0f);
        }
    }

    void drainOxygen()
    {
        if (waterState == "water")
        {
            Debug.Log("Drain Oxygen by 8 per second");
        }
        else if (waterState == "acid")
        {
            Debug.Log("Drain Oxygen by 30 per second");
        }
        else if (waterState == "lava")
        {
            Debug.Log("Instantly drown the player");
        }
    }
}
