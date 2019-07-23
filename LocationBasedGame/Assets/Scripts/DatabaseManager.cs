using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using DataBank;
using System.Collections;
using System.Collections.Generic;

public class DatabaseManager : MonoBehaviour
{
    public bool resetDatabaseFlag;

    // Use this for initialization
    void Start()
    {
        if (resetDatabaseFlag == true)
        {
            resetDatabase();
        }
        //Fetch All Data
        ItemDatabase itemDatabase1 = new ItemDatabase();
        System.Data.IDataReader reader = itemDatabase1.getAllData();

        int fieldCount = reader.FieldCount;
        List<ItemEntity> myList = new List<ItemEntity>();
        while (reader.Read())
        {
            ItemEntity item = new ItemEntity(reader[0].ToString(),
                                    reader[1].ToString(),
                                    reader[2].ToString(),
                                    reader[3].ToString());
            Debug.Log("id: " + item._id);
            myList.Add(item);
        }
        itemDatabase1.close();

        SavegameDatabase savegameDatabase = new SavegameDatabase();
        System.Data.IDataReader sreader = savegameDatabase.getAllData();

        int sfieldCount = sreader.FieldCount;
        List<SavegameEntity> smyList = new List<SavegameEntity>();
        while (sreader.Read())
        {
            SavegameEntity savegame = new SavegameEntity(sreader[0].ToString(),
                                    sreader[1].ToString(),
                                    sreader[2].ToString(),
                                    sreader[3].ToString(),
                                    sreader[4].ToString(),
                                    sreader[5].ToString(),
                                    sreader[6].ToString(),
                                    sreader[7].ToString(),
                                    sreader[8].ToString(),
                                    sreader[9].ToString());
            Debug.Log("id: " + savegame._id);
            smyList.Add(savegame);
        }
        itemDatabase1.close();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void resetDatabase()
    {
        initalizeItemDatabase();
        initalizeSavegameDatabase();
    }

    private void initalizeItemDatabase()
    {
        deleteItemDatabase();
        insertDefaultItems();
    }

    private void deleteItemDatabase()
    {
        ItemDatabase itemDatabase = new ItemDatabase();
        itemDatabase.deleteAllData();
        itemDatabase.close();
    }

    public void insertDefaultItems()
    {
        ItemDatabase itemDatabase = new ItemDatabase();
        itemDatabase.addData(new ItemEntity("0", "Alraune", "Mandragora", "Heilpflanze"));
        itemDatabase.addData(new ItemEntity("1", "Tollkirsche", "Atropus belladonna", "Heilpflanze"));
        itemDatabase.addData(new ItemEntity("2", "Wachholder", "Juniperus sabina", "Heilpflanze"));
        itemDatabase.addData(new ItemEntity("3", "Fliegenpilz", "Juniperus sabina", "Pilz"));
        itemDatabase.addData(new ItemEntity("4", "Morchel", "Juniperus sabina", "Pilz"));
        itemDatabase.addData(new ItemEntity("5", "Kiefernschwamm", "Juniperus sabina", "Pilz"));
        itemDatabase.close();
    }

    private void initalizeSavegameDatabase()
    {
        deleteSavegameDatabase();
        insertDefaultSavegame();
    }

    private void deleteSavegameDatabase()
    {
        SavegameDatabase savegameDatabase = new SavegameDatabase();
        savegameDatabase.deleteAllData();
        savegameDatabase.close();
    }

    private void insertDefaultSavegame()
    {
        SavegameDatabase savegameDatabase = new SavegameDatabase();
        SavegameEntity savegame = new SavegameEntity("0", "1", "0", "0", "0", "0", "0", "0", "0", "0");
        savegameDatabase.addData(savegame);
        savegameDatabase.close();
    }
}