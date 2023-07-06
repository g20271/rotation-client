using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OscCore;

public class OscSender : MonoBehaviour
{
    [SerializeField] string IpAddress = "10.2.0.247";
    OscClient client;

    public void OscStart()
    {
        client = new OscClient(IpAddress, 9000);
    }

    void Update()
    {
        if (!(client is null))
        {
            var rotRH = Input.gyro.attitude;
            var rot = new Quaternion(-rotRH.x, -rotRH.z, -rotRH.y, rotRH.w) * Quaternion.Euler(90f, 0f, 0f);

            client.Send("/sensor/w", rot.w);
            client.Send("/sensor/x", rot.x);
            client.Send("/sensor/y", rot.y);
            client.Send("/sensor/z", rot.z);

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Send");
                client.Send("/hoge", 1.0f);
            }
        }
    }

    public void ChangedIpAddress(string InputIp)
    {
        IpAddress = InputIp;
    }
}