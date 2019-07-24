using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;


namespace DataBank
{
    public class SavegameDatabase : SqliteHelper
    {
        private const String tag = "SavegameDatabase:\t";
        private const String tableName = "savegame";
        private const String keyId = "id";
        private const String keyLevel = "level";
        private const String keyExperience = "experience";
        private const String keyInfection = "infection";
        private const String keyAlrauneAmount = "alrauneAmount";
        private const String keyTollkirscheAmount = "tollkirscheAmount";
        private const String keyWachholderAmount = "wachholderAmount";
        private const String keyFliegenpilzAmount = "fliegenpilzAmount";
        private const String keyMorchelAmount = "morchelAmount";
        private const String keyKiefernschwammAmount = "kiefernschwammAmount";


        public SavegameDatabase() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            String query =
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " ( " +
                keyId + " INT PRIMARY KEY, " +
                keyLevel + " INT, " +
                keyExperience + " INT, " +
                keyInfection + " INT, " +
                keyAlrauneAmount + " INT, " +
                keyTollkirscheAmount + " INT, " +
                keyWachholderAmount + " INT, " +
                keyFliegenpilzAmount + " INT, " +
                keyMorchelAmount + " INT, " +
                keyKiefernschwammAmount + " INT) ";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(SavegameEntity savegame)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + tableName
                + " ( "
                + keyId + ", "
                + keyLevel + ", "
                + keyExperience + ", "
                + keyInfection + ", "
                + keyAlrauneAmount + ", "
                + keyTollkirscheAmount + ", "
                + keyWachholderAmount + ", "
                + keyFliegenpilzAmount + ", "
                + keyMorchelAmount + ", "
                + keyKiefernschwammAmount + " ) "

                + "VALUES ( '"
                + savegame.id + "', '"
                + savegame.level + "', '"
                + savegame.experience + "', '"
                + savegame.infection + "', '"
                + savegame.alrauneAmount + "', '"
                + savegame.tollkirscheAmount + "', '"
                + savegame.wachholderAmount + "', '"
                + savegame.fliegenpilzAmount + "', '"
                + savegame.morchelAmount + "', '"
                + savegame.kiefernschwammAmount + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public void incrementAmount(string identifier)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "UPDATE " + tableName +
                " SET " + identifier.ToLower() + "Amount = " + identifier.ToLower() + "Amount + 1 " +
                "WHERE id = '0'";
            Debug.Log(dbcmd.CommandText);
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataById(int id)
        {
            IDbCommand dbcmd = dbConnection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + tableName + " WHERE id='" + id + "'";
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

        public override void deleteDataById(int id)
        {
            base.deleteDataById(id);
        }

        public override void deleteAllData()
        {
            Debug.Log(tag + "Deleting Table");

            base.deleteAllData(tableName);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(tableName);
        }
    }
}
