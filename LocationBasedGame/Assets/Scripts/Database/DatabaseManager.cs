using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using DatabaseN;
using System.Collections;
using System.Collections.Generic;
using ItemN;

namespace DatabaseN
{
    public class DatabaseManager : MonoBehaviour
    {
        public bool resetDatabaseFlag;
        private string playerName;

        void Start()
        {
            ItemDatabase itemDatabase = new ItemDatabase();
            itemDatabase.close();
            SavegameDatabase savegameDatabase = new SavegameDatabase();
            playerName = getPlayerNameFromDatabase();
            savegameDatabase.close();

            //resetDatabaseFlag = true;
            if (resetDatabaseFlag == true)
            {
                resetDatabase();
            }
        }

        void Update()
        {

        }



        public bool playerNameExists()
        {
            SavegameDatabase savegameDatabase = new SavegameDatabase();
            bool nameBool = false;
            System.Data.IDataReader reader = savegameDatabase.playerNameExists();
            while (reader.Read())
            {
                if (reader[0].ToString() != "")
                {
                    nameBool = true;
                }
            }
            savegameDatabase.close();
            return nameBool;
        }

        public void setPlayerName(string name)
        {
            SavegameDatabase savegameDatabase = new SavegameDatabase();
            savegameDatabase.savePlayerName(name);
            savegameDatabase.close();
        }

        public string getPlayerNameFromDatabase()
        {
            SavegameDatabase savegameDatabase = new SavegameDatabase();
            string name = "";
            System.Data.IDataReader reader = savegameDatabase.getPlayerName();
            while (reader.Read())
            {
                if (reader[0].ToString() != "")
                {
                    name = reader[0].ToString();
                }
            }
            savegameDatabase.close();
            return name;
        }

        public string getPlayerName()
        {
            return playerName;
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
            itemDatabase.addData(new ItemEntity("2", "Wacholder", "Juniperus sabina", "Heilpflanze"));
            itemDatabase.addData(new ItemEntity("3", "Fliegenpilz", "Juniperus sabina", "Pilz"));
            itemDatabase.addData(new ItemEntity("4", "Morchel", "Juniperus sabina", "Pilz"));
            itemDatabase.addData(new ItemEntity("5", "Kiefernschwamm", "Juniperus sabina", "Pilz"));
            itemDatabase.close();
        }

        public void newItem(Item item)
        {
            SavegameDatabase savegameDatabase = new SavegameDatabase();
            savegameDatabase.incrementAmount(item.name);
            Debug.Log(item.name);
        }

        public static List<Item> getAllItems()
        {
            ItemDatabase itemDatabase = new ItemDatabase();
            System.Data.IDataReader reader = itemDatabase.getAllData();
            List<Item> itemList = new List<Item>();
            while (reader.Read())
            {
                Item item = new Item((int)reader[0],
                                        reader[1].ToString(),
                                        reader[2].ToString(),
                                        reader[3].ToString());
                itemList.Add(item);
            }
            itemDatabase.close();
            return itemList;
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
            SavegameEntity savegame = new SavegameEntity("0", null, "1", "0", "0", "0", "0", "0", "0", "0", "0");
            savegameDatabase.addData(savegame);
            savegameDatabase.close();
        }

        public SavegameEntity getSafeGameById(int id)
        {
            SavegameDatabase savegameDatabase = new SavegameDatabase();
            System.Data.IDataReader reader = savegameDatabase.getDataById(id);
            SavegameEntity savegame = null;
            while (reader.Read())
            {
                savegame = new SavegameEntity(reader[0].ToString(),
                                        reader[1].ToString(),
                                        reader[2].ToString(),
                                        reader[3].ToString(),
                                        reader[4].ToString(),
                                        reader[5].ToString(),
                                        reader[6].ToString(),
                                        reader[7].ToString(),
                                        reader[8].ToString(),
                                        reader[9].ToString(),
                                        reader[10].ToString());
            }
            return savegame;
        }
    }
}