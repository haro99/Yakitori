using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRankingScript : MonoBehaviour
{
    string requesturl = "http://k013a2065.php.xdomain.jp/test.php";
    string pushulr = "";
    public GameObject Communication, RankingObject;
    public Text[] RankingTexts;
    // Start is called before the first frame update
    private void Start()
    {
        //StartCoroutine(GetMoney());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// ランキングを取ってくる
    /// </summary>
    /// <returns></returns>
    IEnumerator GetMoney()
    {
        WWW www = new WWW(requesturl);
        Debug.Log("通信中");
        Communication.SetActive(true);
        //yield return new WaitForSeconds(10f);
        yield return www;
        Communication.SetActive(false);
        string jsonString = www.text;
        string[] numbers = jsonString.Split(',');
        Debug.Log(numbers[0]);
        Debug.Log(jsonString);
        for (int i = 0; i < numbers.Length; i++)
        {
            RankingTexts[i].text = numbers[i] + "円";
        }
        RankingObject.SetActive(true);
    }

    /// <summary>
    /// ランキングにあげる
    /// </summary>
    /// <param name="money"></param>
    /// <returns></returns>
    IEnumerator PutScore(int money)
    {
        Debug.Log("通信中");
        Communication.SetActive(true);
        yield return null;
    }
}
