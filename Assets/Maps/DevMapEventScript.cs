using UnityEngine;

public class DevMapEventScript : MonoBehaviour
{
    private Transform map;
    private MapScript mapScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        map = transform;
        mapScript = GameObject.Find("GameManager").GetComponent<MapScript>();
        Invoke("Section1", 15.0f);
        Invoke("Section2", 35.0f);
    }

    private void Section1()
    {
        Debug.Log("Beginning Water Movement");
        mapScript.MoveObject(map.Find("_Water1"), 3, 10, true);
    }
    private void Section2()
    {
        mapScript.SetWaterState(map.Find("_Water1"), "acid", false);
        mapScript.MoveObject(map.Find("_Water1"), 2, 6, true);
    }
}
