using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityDlc : MonoBehaviour {

    public string dlcListUrl;


    public string[] dlcNames;
    public string[] dlcUrls;

    public static string dlcPath;

	// Use this for initialization
    IEnumerator Start () {
        using (WWW www = new WWW(dlcListUrl))
        {
            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError(www.error);
                yield break;
            }

            string[] lines = www.text.Split(new string[] { System.Environment.NewLine },System.StringSplitOptions.RemoveEmptyEntries);
            dlcNames = System.Array.ConvertAll(lines, dlc => dlc.Split(new string[] { "<url>" }, System.StringSplitOptions.None)[0]);
            dlcUrls = System.Array.ConvertAll(lines, dlc => dlc.Split(new string[] { "<url>" }, System.StringSplitOptions.None)[1]);
            //Debug.Log();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
