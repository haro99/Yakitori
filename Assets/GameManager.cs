using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int droppointy = 9, count;
    public GameObject Droobj;
    public KusiController Kusi;
    public int[] kusis;
    public int limit;

    public GameObject[] Counts;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SozaiDrop());
        //StartCoroutine(TimeCount());
        StartCoroutine(Result());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeCount()
    {
  
        while (limit > 0)
        {
            Debug.Log(limit);
            yield return new WaitForSeconds(1);
            limit--;
        }

        Debug.Log("終了！");

        StartCoroutine(SozaiDrop());

        yield return new WaitForSeconds(5);
        Result();
    }

    IEnumerator SozaiDrop()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Droobj, new Vector3(Random.Range(-2, 3), droppointy), Quaternion.identity);
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

    IEnumerator Result()
    {
        Debug.Log("リザルト");

        yield return new WaitForSeconds(3);

        for(int i = 0; i< kusis.Length;i++)
        {
            Text text = Counts[i].GetComponent<Text>();
            text.text = kusis[i].ToString();

            Counts[i].SetActive(true);
            yield return new WaitForSeconds(2);

        }
    }
}
