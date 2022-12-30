using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    public Scrollbar scrolbarr;
    public Scrollbar scrolbarrx;
    public Scrollbar scrolbarz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(1 + scrolbarrx.value * 5, 1+scrolbarr.value*5, scrolbarz.value*5+ 1);
    }
}
