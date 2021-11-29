using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRankingScript : MonoBehaviour
{
    string requesturl = "http://k013a2065.php.xdomain.jp/GetRequest.php";
    string pushulr = "http://k013a2065.php.xdomain.jp/PushRequest.php";
    public GameObject Communication, RankingObject;
    public Text[] RankingTexts;
    // Start is called before the first frame update
    private void Start()
    {
        //StartCoroutine(GetMoneyRanking());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// ランキングを取ってくる
    /// </summary>
    /// <returns></returns>
    IEnumerator GetMoneyRanking()
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
            if(i==20)
            {
                break;
            }
            if (numbers[i] != "")
            {
                RankingTexts[i].text = numbers[i] + "円";
            }
        }
        RankingObject.SetActive(true);
    }

    /// <summary>
    /// ランキングにデータをあげる
    /// </summary>
    /// <param name="money"></param>
    /// <returns></returns>
    IEnumerator PutScore(int score)
    {
        Debug.Log("通信中");
        Communication.SetActive(true);
        WWW www = new WWW(pushulr + "?PushMoney=" + score);

        yield return www;
        Debug.Log("データを送れました");
        Debug.Log(www.text);
        StartCoroutine(GetMoneyRanking());
    }
    public void Push(int score)
    {
        StartCoroutine(PutScore(score));
    }
}
