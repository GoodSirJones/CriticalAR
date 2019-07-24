using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

public class ShowcaseNotes : MonoBehaviour
{
    public Text notesText;

    public string nameAppliance;

    public string noteField;

    private string connectString;
    // Start is called before the first frame update
    void Start()
    {
        //nameAppliance = "Fire Extinguisher";

        connectString = "URI=file:" + Application.streamingAssetsPath + "/WallUtilityData.db";

        GetData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetData()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectString))
        {
            dbConnection.Open();

            using (IDbCommand dbCommand = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM WallUtilities WHERE Name = '" + nameAppliance + "'";

                dbCommand.CommandText = sqlQuery;

                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        noteField = reader.GetString(9);

                        
                        
                        ShowNotes(noteField);
                    }

                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
    }

    private void ShowNotes(string noteData)
    {
        this.notesText.GetComponent<Text>().text = noteData;
    }

    public void GetName(string nameData)
    {
        nameAppliance = nameData;

        GetData();
        
    }

    public void SetData(string newData)
    {
        this.notesText.GetComponent<Text>().text = newData;
    }
}
