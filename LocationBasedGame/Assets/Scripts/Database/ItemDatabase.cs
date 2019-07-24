using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DatabaseN
{
    public class ItemDatabase : SqliteHelper
    {
        private const String tag = "ItemDatabase:\t";
        private const String tableName = "item";
        private const String keyId = "id";
        private const String keyName = "name";
        private const String keyLatinName = "latinName";
        private const String keyDescription = "description";

        public ItemDatabase() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            String query =
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + tableName + " ( " +
                keyId + " INT PRIMARY KEY, " +
                keyName + " CHAR(25), " +
                keyLatinName + " CHAR(50), " +
                keyDescription + " TEXT) ";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(ItemEntity item)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + tableName
                + " ( "
                + keyId + ", "
                + keyName + ", "
                + keyLatinName + ", "
                + keyDescription + " ) "

                + "VALUES ( '"
                + item.id + "', '"
                + item.name + "', '"
                + item.latinName + "', '"
                + item.description + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
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