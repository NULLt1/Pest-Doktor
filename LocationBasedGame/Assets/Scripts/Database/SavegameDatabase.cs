using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;
// NULLt1
namespace DatabaseN
{
    public class SavegameDatabase : SqliteHelper
    {
        private const String tag = "SavegameDatabase:\t";
        private const String tableName = "savegame";
        private const String keyId = "id";
        private const String keyName = "name";
        private const String keyLevel = "level";
        private const String keyExperience = "experience";
        private const String keyInfection = "infection";
        private const String keyAlrauneAmount = "alrauneAmount";
        private const String keyTollkirscheAmount = "tollkirscheAmount";
        private const String keyWachholderAmount = "wacholderAmount";
        private const String keyFliegenpilzAmount = "fliegenpilzAmount";
        private const String keyMorchelAmount = "morchelAmount";
        private const String keyKiefernschwammAmount = "kiefernschwammAmount";


        public SavegameDatabase() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            String query =
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " ( " +
                keyId + " INT PRIMARY KEY, " +
                keyName + " CHAR(25), " +
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
                + keyName + ", "
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
                + savegame.name + "', '"
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
                "WHERE " + keyId + "  = '0'";
            dbcmd.ExecuteNonQuery();
        }

        public IDataReader playerNameExists()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT " + keyName + " FROM " + tableName +
               " WHERE " + keyId + "  = '0'";
            //dbcmd.ExecuteNonQuery();
            return dbcmd.ExecuteReader();
        }

        public void savePlayerName(string name)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "UPDATE " + tableName +
                " SET " + keyName + " = '" + name +
                "' WHERE " + keyId + " = '0'";
                Debug.Log(dbcmd.CommandText);
            dbcmd.ExecuteNonQuery();
        }

        public IDataReader getPlayerName()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT " + keyName +
                " FROM " + tableName +
                " WHERE " + keyId + "  = '0'";
            //dbcmd.ExecuteNonQuery();
            return dbcmd.ExecuteReader();
        }

        public override IDataReader getDataById(int id)
        {
            IDbCommand dbcmd = dbConnection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + tableName + " WHERE " + keyId + " = " + id;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

        public override void deleteDataById(int id)
        {
            base.deleteDataById(id);
        }

        public override void deleteAllData()
        {
            base.deleteAllData(tableName);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(tableName);
        }
    }
}
