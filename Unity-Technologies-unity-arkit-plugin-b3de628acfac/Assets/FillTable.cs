using System.Collections;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using TMPro;


public class FillTable : MonoBehaviour
{
    private string connectionString;

    public string utilityName;

    public int utilityID;
    public int height;
    public int width;

    public string description;

    public string namePlace;

    public TextMeshPro heightText;
    public TextMeshPro widthText;
    public TextMeshPro manufacturerText;
    

    public TextMeshPro DescriptionText;

    public string manufacturer;
    // Start is called before the first frame update
    void Start()
    {
        connectionString = "URI=file:" + Application.streamingAssetsPath + "/WallUtilityData.db";
        GetData();
    }
    void OnEnable()
    {
        EditFieldData.UpdateNow += GetData;
    }

    void OnDisable()
    {
         EditFieldData.UpdateNow += GetData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetData()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM WallUtilities WHERE Name = '" + namePlace + "'";
                

                dbCommand.CommandText = sqlQuery;

                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        Debug.Log(reader.GetString(1));
                        width = reader.GetInt32(2);
                        height = reader.GetInt32(3);
                        manufacturer = reader.GetString(4);
                        description = reader.GetString(5);

                        ShowData(width.ToString(), height.ToString(), manufacturer, description);
                    }

                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }

    public void SetData()
    {

    }

    public void GetName(string nameData)
    {
        namePlace = nameData;
        GetData();
    }

    private void ShowData(string widthData, string heightData, string manufacturerData, string descriptionData)
    {
       this.widthText.GetComponent<TextMeshPro>().text = "Width: " + widthData;
       this.heightText.GetComponent<TextMeshPro>().text = "Height: " + heightData;
       this.manufacturerText.GetComponent<TextMeshPro>().text = "Manufacturer: " + manufacturerData;
       this.DescriptionText.GetComponent<TextMeshPro>().text = "Description: " + descriptionData;
    }
}
