/*****************************************************\
*
*  Copyright (C) 2016, Douglas Knowman 
*  douglasknowman@gmail.com
*
*  Distributed under the terms of GNU GPL v3 license.
*  Always KISS.
*
\*****************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public struct Record
{
    public string name;
    public int score;
}
public class HighScoreBoard : MonoBehaviour
{
    // Public variables.
    public int maxScoreRecords = 6;
    public GameObject playerRecordPrefab;
    // Private variables.
    int recordsSaved = 0;
    Transform table;

    //SortedDictionary<string,int> board = new SortedDictionary<string,int>();
    List<Record> board = new List<Record>();
    // Unity functions.
    void Update ()
    {
    }
    void Start()
    {
        table = transform.FindChild("high_score").transform;
        for (int i=1; i< maxScoreRecords+1; i++)
        {
            if (PlayerPrefs.HasKey(i+"_Name"))
            {
                recordsSaved = i;
            }
        }

        FillBoardWithScores();
    }
      
    // HighSoreBoard functions.
    //Sort all keys on dictionary;
    void SortBoard()
    {
        board.Sort((x,y) => x.score.CompareTo(y.score));
        board.Reverse();
    }

    public void SaveHighScoreBoard(string nick, int score)
    {
        Record rec;
        rec.name = nick;
        rec.score = score;
        board.Add(rec);
        SortBoard();

        if (recordsSaved == maxScoreRecords)
        {
            board.Remove(board[board.Count -1]);
        }
        ClearBoard();
        PlayerPrefs.DeleteAll();
        SaveBoard();

        FillBoardWithScores();
    }
    void SaveBoard()
    {
        int count = 0;
        foreach(Record x in board)
        {
            count += 1;
            PlayerPrefs.SetString(count+"_Name",x.name);
            PlayerPrefs.SetInt(count+"_Score",x.score);
        }
    }
    public void DeleteAllRecords()
    {
        ClearBoard();
        board.Clear();
        PlayerPrefs.DeleteAll();
    }

    void ClearBoard()
    {
        foreach(Transform x in table)
        {
            Destroy(x.gameObject);
        }
    }

    void FillBoardWithScores()
    {
        board.Clear();
        for (int i=1; i< maxScoreRecords+1; i++)
        {
            if (PlayerPrefs.HasKey(i+"_Name"))
            {
                GameObject obj = Instantiate(playerRecordPrefab,Vector3.zero,Quaternion.identity) as GameObject;
                obj.transform.SetParent(table,false);

                //filling record with information
                Text name = obj.transform.GetChild(0).GetComponent<Text>();
                Text score =  obj.transform.GetChild(1).GetComponent<Text>();
                
                name.text = PlayerPrefs.GetString(i+"_Name");
                score.text = PlayerPrefs.GetInt(i+"_Score").ToString();
                
                Record rec;
                rec.name = PlayerPrefs.GetString(i+"_Name");
                rec.score = PlayerPrefs.GetInt(i+"_Score");
                board.Add(rec);
            }
        }
    }

}
