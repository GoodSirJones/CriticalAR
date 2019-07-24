using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System;
using UnityEngine.XR.iOS;


public class UpdateNotes : MonoBehaviour
{

    
    public Text enterNotes;

    public Text nameChanger;

    public Text noteHolder;

    public GameObject editHolder;

    public string utilityName;

    public int UNI;

    public ShowcaseNotes noteScript;

    public EditFieldData editScript;


    

    private string connectString;
    // Start is called before the first frame update
    void Start()
    {

        connectString = "URI=file:" + Application.streamingAssetsPath + "/WallUtilityData.db";

        


        noteScript = noteHolder.GetComponent<ShowcaseNotes>();

        editScript = editHolder.GetComponent<EditFieldData>();

        utilityName = nameChanger.text;

        noteScript.GetName(utilityName);

        //SwitchNames();
        
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetName(string name)
    {

       
        utilityName = name;

        //nextDebug.text = utilityName;

    }

    public void EnterString()
    {
        if (enterNotes.text != string.Empty)
        {
            InsertNotes(enterNotes.text);
            enterNotes.text = string.Empty;
            enterNotes.text = " ";
        }
    }

    public void InsertNotes(string notes)
    {
        noteScript.SetData(notes);

        using (IDbConnection dbConnection = new SqliteConnection(connectString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE WallUtilities SET Notes = '" + notes + "' WHERE Name = '" + utilityName + "'";

                dbCommand.CommandText = sqlQuery;
                dbCommand.ExecuteScalar();

                
                
                dbConnection.Close();
                
            }

           
        }

       

        //EditFieldData.UpdateNow?.Invoke();

    }



    public void GetID(int imageID)
    {
        //int holdID;

        UNI = imageID;

        //numberHolder.text = UNI.ToString();

        //SwitchNames();
        
    }

    public void SwitchNames()
    {
        switch (UNI)
        {
            case 1:
                utilityName = "Fire Extinguisher";
                break;
            case 2:
                utilityName = "Thermostat";
                break;
            case 3:
                utilityName = "Emergency Door Release";
                break;
            case 4:
                utilityName = "Security Scanner";
                break;
            case 5:
                utilityName = "Door Release Switch";
                break;
            case 6:
                utilityName = "Fire Alarm Trigger";
                break;
            case 7:
                utilityName = "Wall Clock";
                break;
            default:
                utilityName = "Fire Extinguisher";
                break;
        }

        //noteScript.GetName(utilityName);

        //editScript.GetName(utilityName);
    }

    public void UpdateNoteName()
    {
        utilityName = nameChanger.text;


        noteScript.GetName(utilityName);
    }

    public void CheckUpdate()
    {

    }

   
}
