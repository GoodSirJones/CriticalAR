using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetApplianceName : MonoBehaviour
{
    public string utilityName;

    public GameObject imagePrefab;

    public SwitchTextShown recieveName;

    // Start is called before the first frame update
    void Start()
    {
        recieveName = imagePrefab.GetComponent<SwitchTextShown>();

        utilityName = recieveName.nameUtility;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(utilityName);
    }
}
