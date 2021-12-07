using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WebSocketSharp;

public class WebSocketClientManager
{
    public static WebSocket webSocket;
    public static UnityAction<Dictionary<string, PlayerActionData>> recieveCompletedHandler;

    public static void Connect()
    {
        if (webSocket == null)
        {
            webSocket = new WebSocket("ws://54.199.217.151:3000");
            webSocket.OnMessage += (sender, e) => RecieveAllPlayerAction(e.Data);
            webSocket.Connect();
        }
    }

    public static void DisConnect()
    {
        webSocket.Close();
        webSocket = null;
    }

    public static void SendPlayerAction(string action, Vector3 pos, string way, float range)
    {
        var userActionData = new PlayerActionData
        {
            action  = action,
            way     = way,
            room_no = 1,
            user    = UserLoginData.userName,
            pos_x   = pos.x,
            pos_y   = pos.y,
            pos_z   = pos.z,
            range   = range
        };

        webSocket.Send(userActionData.ToJson());
    }

    public static void RecieveAllPlayerAction(string json)
    {
        var allUserActionHash = PlayerActionData.FromJson(json, 1);
        recieveCompletedHandler?.Invoke(allUserActionHash);
    }
}