using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var rotRH = Input.gyro.attitude;
        var rot = new Quaternion(-rotRH.x, -rotRH.z, -rotRH.y, rotRH.w) * Quaternion.Euler(90f, 0f, 0f);
        Debug.Log(rotRH);
        Debug.Log(rot);

        transform.localRotation = rot;
        
        //https://qiita.com/fuqunaga/items/b1a3e38af71f062f0781
    }
}
