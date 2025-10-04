using UnityEngine;
using System;

public class UdidManager : MonoBehaviour
{
    private static System.Random _random = new System.Random();
    private static string _udid = String.Empty;
    private static string _guid = String.Empty;
    
    public static string Udid
    {
        get
        {
            if (_udid != string.Empty)
            {
                return _udid;
            }
            else
            {
                if (PlayerPrefs.HasKey("UDID"))
                    _udid = PlayerPrefs.GetString("UDID");
                else
                {
                    _udid = GenerateUdid();
                    PlayerPrefs.SetString("UDID", _udid);
                }

                return _udid;
            }
        } 
    }

    public static string Guid
    {
        get
        {
            if (_guid != string.Empty)
            {
                return _guid;
            }
            else
            {
                if (PlayerPrefs.HasKey("GUID"))
                    _guid = PlayerPrefs.GetString("GUID");
                else
                {
                    _guid = System.Guid.NewGuid().ToString();
                    PlayerPrefs.SetString("GUID", _guid);
                }

                return _guid;
            }
        } 
    }    
    
    private static string GenerateUdid()
    {
        DateTime epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
        double timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
				 
        string udid =
            Application.systemLanguage				//Language
            +"-"+Application.platform                                            //Device    
            +"-"+String.Format("{0:X}", Convert.ToInt32(timestamp))                //Time
            +"-"+String.Format("{0:X}", Convert.ToInt32(Time.time*1000000))        //Time in game
            +"-"+String.Format("{0:X}", _random.Next(1000000000));                //random number

#if UNITY_EDITOR	 
        Debug.Log("Generated Unique ID: "+udid);
#endif

        return udid;
    }

    // generate an id for a session
    public static string GetSessionId()
    {
        return DateTime.UtcNow.ToString("yyyyMMddHHmmss");
    }
    
    public static string GetTimeStamp()
    {
        return DateTime.UtcNow.ToString("yyyyMMddHHmmss");
    }
}