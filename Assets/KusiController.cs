using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KusiController : MonoBehaviour
{
    public GameObject[] Sets;
    public GameManager GameManager;
    public List<GameObject> sozai = new List<GameObject>();
    public int setnumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D RB = collision.gameObject.GetComponent<Rigidbody2D>();
        RB.simulated = false;
        collision.transform.position = Sets[setnumber].transform.position;
        collision.transform.parent = this.transform;
        sozai.Add(collision.gameObject);
        setnumber++;
        GameManager.Add();
    }
    public void Reset()
    {
        foreach(var obj in sozai)
        {
            Destroy(obj);
        }
        sozai.Clear();
        setnumber = 0;
    }
}
