using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClass : MonoBehaviour
{

    public int testID;

    public string testName;

    private GameObject testNotes;

    private UpdateNotes testScript;

    // Start is called before the first frame update
    void Start()
    {
        testNotes = GameObject.FindWithTag("InfoUpdate");

        testScript = testNotes.GetComponent<UpdateNotes>();



        testName = "Security Scanner";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendName()
    {
        testScript.GetName(testName);
    }

    public void SendID()
    {
        testID = Random.Range(1, 7);
        testScript.GetID(testID);
    }
}
