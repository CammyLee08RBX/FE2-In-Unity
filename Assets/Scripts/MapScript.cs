using UnityEngine;
using DG.Tweening;

public class MapScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetWaterState(Transform water, string state, bool noColorChange)
    {
        state = state.ToLower();
        Material newMat = null;
        if (water.GetComponent<WaterBehavior>() == null){
            water.gameObject.AddComponent<WaterBehavior>();
        }
        if (water.GetComponent<WaterBehavior>() != null && !noColorChange)
        {
            if (state == "water")
            {
                newMat = water.GetComponent<WaterBehavior>().waterMaterial;
            } else if (state == "acid")
            {
                newMat = water.GetComponent<WaterBehavior>().acidMaterial;
            } else if (state == "lava")
            {
                newMat = water.GetComponent<WaterBehavior>().lavaMaterial;
            }
            water.GetComponent<Renderer>().material = newMat;
            water.GetComponent<WaterBehavior>().waterState = state;
        }
    }

    public void MoveObject(Transform obj, float move, float duration, bool useLocalSpace){
        if (obj != null){
            if (useLocalSpace == false){
                obj.DOMoveY(obj.position.y * move, duration);
            }else{
                obj.DOMoveY(obj.position.y + move, duration);
            }
        }
    }
}
