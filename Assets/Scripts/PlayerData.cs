using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class PlayerData
{
    public static KeyCode CompassControl_Left = KeyCode.J;
    public static KeyCode CompassControl_Right = KeyCode.L;
    public static KeyCode CompassControl_Up = KeyCode.I;
    public static KeyCode CompassControl_Down = KeyCode.K;
    public static KeyCode CompassControl_Confirm = KeyCode.Return;
    public static int DeathCount = 0;
    public static int current_checkpoint;
    public static string path = "/config.json";
    public static bool isMobile = true;
    public static void SaveConfig()
    {
        string json = JsonUtility.ToJson(new PlayerDataHolder(CompassControl_Left,CompassControl_Right,CompassControl_Up,CompassControl_Down,CompassControl_Confirm,DeathCount));
        FileStream configfile = File.Create(Application.persistentDataPath + path);
        configfile.SetLength(0);
        byte[] data = Encoding.UTF8.GetBytes(json);
        configfile.Write(data, 0, data.Length);
        configfile.Close();
    }
    public static void LoadConfig()
    {
        if(!File.Exists(Application.persistentDataPath + path))
        {
            SaveConfig();
        }
        StreamReader configfile = new StreamReader(Application.persistentDataPath + path);
        PlayerDataHolder pdh = JsonUtility.FromJson<PlayerDataHolder>(configfile.ReadToEnd());
        CompassControl_Left = pdh.CompassControl_Left;
        CompassControl_Right = pdh.CompassControl_Right;
        CompassControl_Up = pdh.CompassControl_Up;
        CompassControl_Down = pdh.CompassControl_Down;
        CompassControl_Confirm = pdh.CompassControl_Confirm;
        DeathCount = pdh.DeathCount;
        configfile.Close();
    }

    public static void SetKeybindByID(int id, KeyCode to_change)
    {
        switch(id)
        {
            case 1: CompassControl_Down = to_change; break;
            case 2: CompassControl_Up = to_change; break;
            case 3: CompassControl_Left = to_change; break;
            case 4: CompassControl_Right = to_change; break;
            case 5: CompassControl_Confirm = to_change; break;
            default: break;
        }
    }
    public static KeyCode GetKeybindByID(int id)
    {
        switch (id)
        {
            case 1: return CompassControl_Down;
            case 2: return CompassControl_Up;
            case 3: return CompassControl_Left;
            case 4: return CompassControl_Right;
            case 5: return CompassControl_Confirm;
            default: return KeyCode.None;
        }
    }

    [Serializable]
    class PlayerDataHolder
    {
        public KeyCode CompassControl_Left = KeyCode.J;
        public KeyCode CompassControl_Right = KeyCode.L;
        public KeyCode CompassControl_Up = KeyCode.I;
        public KeyCode CompassControl_Down = KeyCode.K;
        public KeyCode CompassControl_Confirm = KeyCode.Return;
        public int DeathCount = 0;
        public PlayerDataHolder(KeyCode cc_l, KeyCode cc_r, KeyCode cc_u, KeyCode cc_d, KeyCode cc_c,int dc)
        {
            CompassControl_Left = cc_l;
            CompassControl_Right = cc_r;
            CompassControl_Up = cc_u;
            CompassControl_Down = cc_d;
            CompassControl_Confirm = cc_c;
            DeathCount = dc;
        }
    }
}
