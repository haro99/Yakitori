using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yakitori : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
        if(transform.position.y<-7)
        {
            transform.position = new Vector3(Random.Range(-3, 4), 10, 0);
        }
    }
}
