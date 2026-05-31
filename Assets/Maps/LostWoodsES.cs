using UnityEngine;

public class LostWoodsES : MonoBehaviour
{
    private Transform map;
    private MapScript mapScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        map = transform;
        mapScript = GameObject.Find("GameManager").GetComponent<MapScript>();
        Invoke("Section1", 4.0f);
        Invoke("Section2", 16.0f);
        Invoke("Section3", 50.0f);
        Invoke("Section4", 68.0f);
    }

    private void Section1()
    {
        Debug.Log("Beginning Water Movement");
        mapScript.MoveObject(map.Find("_Water1"), 2.45f, 11, true);
    }
    private void Section2()
    {
        mapScript.MoveObject(map.Find("_Water1"), 2.4f, 28, true);
    }
    private void Section3()
    {
        mapScript.SetWaterState(map.Find("_Water1"), "acid", false);
        mapScript.MoveObject(map.Find("_Water1"), 2.5f, 16, true);
    }
    private void Section4()
    {
        mapScript.MoveObject(map.Find("_Water1"), 2.5f, 20, true);
    }
}