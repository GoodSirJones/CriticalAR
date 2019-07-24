using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System;

public class EditFieldData : MonoBehaviour
{
    public static event Action UpdateNow;
    public Text changeField;

    public Text changeData;

    public string nameUtility;

    public Text utilityGet;

    private string connectString;

    public string fieldName;

    private GameObject imageAnchor;

    private GenerateImageAnchor anchorScript;

    // Start is called before the first frame update
    void Start()
    {
        
        imageAnchor = GameObject.FindWithTag("ImageGenerator");

        anchorScript = imageAnchor.GetComponent<GenerateImageAnchor>();

        nameUtility = utilityGet.text;

        fieldName = changeField.text;

        connectString = "URI=file:" + Application.streamingAssetsPath + "/WallUtilityData.db";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterString()
    {
        if (changeData.text != string.Empty)
        {
            InsertData(changeData.text);
            changeData.text = string.Empty;
            changeData.text = " ";
        }
    }

    public void InsertData(string newData)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = "UPDATE WallUtilities SET " + fieldName + " = '" + newData + "' WHERE Name = '" + nameUtility + "'";

                dbCommand.CommandText = sqlQuery;
                
                dbCommand.ExecuteScalar();
                dbConnection.Close();
            }
        }



        UpdateNow?.Invoke();
    }

    public void UpdateName()
    {
        nameUtility = utilityGet.text;
    }

    public void GetName(string nameRecieve)
    {
        nameUtility = nameRecieve;
    }

    public void UpdateField()
    {
        fieldName = changeField.text;
    }
}
