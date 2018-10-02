using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System;

public class MQTTManager : MonoBehaviour {

    private MqttClient Client;

    public string SubscriberURL;
    // Use this for initialization
    void Start () {
        Client = new MqttClient("iot.eclipse.org");
        Client.Connect(Guid.NewGuid().ToString());

        Client.MqttMsgPublishReceived += MessageArrivedCallback;
        Client.Subscribe(new string[] { SubscriberURL }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
    }

    private void MessageArrivedCallback(object sender, MqttMsgPublishEventArgs e)
    {
        if (e.Topic == "/i5/hololens/instructions")
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {
                TextMesh t = (TextMesh)GetComponent(typeof(TextMesh));
                t.text = System.Text.Encoding.UTF8.GetString(e.Message);
            });
        }
        else if (e.Topic == "/i5/hololens/car/ldoor")
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {

                OpenElement t = (OpenElement)GetComponent(typeof(OpenElement));
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "open")
                {
                    t.Opening.SetInteger("EtatAnim", 1);
                }
                else
                {
                    t.Opening.SetInteger("EtatAnim", 2);
                }
            });
        }
        else if (e.Topic == "/i5/hololens/car/rdoor")
        {
            UnityMainThreadDispatcher.Instance().Enqueue(() =>
            {

                OpenElement t = (OpenElement)GetComponent(typeof(OpenElement));
                if (System.Text.Encoding.UTF8.GetString(e.Message) == "open")
                {
                    t.Opening.SetInteger("EtatAnim", 1);
                }
                else
                {
                    t.Opening.SetInteger("EtatAnim", 2);
                }
            });
        }
    }
}
