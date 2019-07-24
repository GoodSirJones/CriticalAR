using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetUtilityName : MonoBehaviour
{
    public string nameUtility;

    public GameObject namePrefab;
    // Start is called before the first frame update
    void Start()
    {
        nameUtility = namePrefab.GetComponent<TextMesh>().text.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(nameUtility);
    }

    public void SetName()
    {
        
    }
}
