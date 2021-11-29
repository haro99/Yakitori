using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int droppointy = 9, count;
    public GameObject Droobj;
    public KusiController Kusi;
    public int[] kusis;
    public int limit;
    public Animator FadeAnimator;
    public AudioSource Source, DropSource;
    public AudioClip[] Clips;
    public GetRankingScript RankingScript;

    public GameObject[] Counts;
    public int[] price;
    public GameObject Message, ResultUI, End;
    public Text Timetext, totaltext;
    public int total;
    // Start is called before the first frame update
    void Start()
    {

        //StartCoroutine(Result());
        StartCoroutine(Starting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeCount()
    {
  
        while (limit >= 0)
        {
            Debug.Log(limit);
            Timetext.color = new Color(255f, 0, 0);
            Timetext.text = limit.ToString();
            yield return new WaitForSeconds(1);
            limit--;
        }

        Debug.Log("終了！");

        StartCoroutine(SozaiDrop());
        End.SetActive(true);
        yield return new WaitForSeconds(5);
        End.SetActive(false);
        StartCoroutine(Result());
    }

    IEnumerator SozaiDrop()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Droobj, new Vector3(Random.Range(-2, 3), droppointy), Quaternion.identity);
            DropSource.Play();
            yield return new WaitForSeconds(1);
        }
    }

    public void Add()
    {
        count++;
        if(3==count)
        {
            int setnumber = Kusi.setnumber;
            Kusicheck(setnumber);
            Kusi.Reset();
            count = 0;
            if(limit>0)
            {
                StartCoroutine(SozaiDrop());
            }

        }
    }

    public void Kusicheck(int number)
    {
        switch(number)
        {
            case 3:
                kusis[0]++;
                break;
            case 2:
                kusis[1]++;
                break;
            case 1:
                kusis[2]++;
                break;
            default:
                kusis[3]++;
                break;
        }
    }

    IEnumerator Starting()
    {
        yield return null;
        yield return new WaitUntil(() => FadeAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);
        Debug.Log("待機が終わりました");
        yield return new WaitForSeconds(5);
        Message.SetActive(false);
        Source.PlayOneShot(Clips[0]);
        yield return new WaitForSeconds(1);
        StartCoroutine(SozaiDrop());
        StartCoroutine(TimeCount());
    }

    IEnumerator Result()
    {
        Debug.Log("リザルト");

        yield return new WaitForSeconds(3);

        ResultUI.SetActive(true);

        for (int i = 0; i< kusis.Length;i++)
        {
            Text text = Counts[i].GetComponent<Text>();
            text.text = kusis[i].ToString();
            Counts[i].SetActive(true);
            total += price[i] * kusis[i];
            totaltext.text = total.ToString();
            yield return new WaitForSeconds(2);
        }

        yield return new WaitForSeconds(3);
        RankingScript.Push(total);

    }


}
