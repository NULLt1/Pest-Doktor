using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class DatabaseManager : MonoBehaviour {
	private string saveGameTableQuery =  "CREATE TABLE IF NOT EXISTS saveGame (id AUTOINCREMENT PRIMARY KEY, level INTEGER, amountAlraune INTEGER, amountTollkirsche INTEGER, amountWachholder INTEGER, amountFliegenpilz INTEGER, amountMorchel INTEGER, amountKiefernschwamm INTEGER)";
	private string itemTableQuery = "CREATE TABLE IF NOT EXISTS item (id AUTOINCREMENT PRIMARY KEY, name CHAR(25), latinName CHAR(50), description TEXT)";
	
	private String alrauneString="INSERT INTO item (name, latinName, description) VALUES ('Alraune' , 'Mandragora' , 'Heilpflanze' )";
	private String tollkirschString;
	private String wachholderString;
	private String fliegenpilzString;
	private String morchelString;
	private String kiefernschwammString;

	public boolean deleteDatabase;
	public boolean initializeValues;

	// Use this for initialization
	void Start () {

		// Create database
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "Game";
		if(deleteDatabase==true){

		}
		CreateTables();
		if(initializeItems==true){
			InsertItems();
		}
		//FillWithDefaultValues();
		// Open connection
		IDbConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();
		IDbCommand dropDatabase;
		dropDatabase = dbcon.CreateCommand();		
		dropDatabase.CommandText = "DROP TABLE my_table";
		dropDatabase.ExecuteReader();
		// Create table
		IDbCommand dbcmd;
		dbcmd = dbcon.CreateCommand();
		string q_createTable = "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val INTEGER )";
		
		dbcmd.CommandText = q_createTable;
		dbcmd.ExecuteReader();

		// Insert values in table
		IDbCommand cmnd = dbcon.CreateCommand();
		cmnd.CommandText = "INSERT INTO my_table (id, val) VALUES (0, 5)";
		cmnd.ExecuteNonQuery();

		// Read and print all values in table
		IDbCommand cmnd_read = dbcon.CreateCommand();
		IDataReader reader;
		string query ="SELECT * FROM my_table";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();

		while (reader.Read())
		{
			Debug.Log("id: " + reader[0].ToString());
			Debug.Log("val: " + reader[1].ToString());
		}

		// Close connection
		dbcon.Close();

	}

	private void CreateTables(){
		CreateTable(saveGameTableQuery);
		CreateTable(itemTableQuery);
	}



	private void CreateTable(string Query){
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "Game";
		IDbConnection dbcon = new SqliteConnection(connection);
		dbcon.Open();
		IDbCommand dbcmd;
		dbcmd = dbcon.CreateCommand();		
		dbcmd.CommandText = Query;
		dbcmd.ExecuteReader();
		dbcon.Close();

	}

	private void InsertItems(){
		insertItem(alrauneString);
		insertItem(tollkirschString);
		insertItem(wachholderString);
		insertItem(fliegenpilzString);
		insertItem(morchelString);
		insertItem(kiefernschwammString);
	}

	private void insertItem(string Item){
		string connection = "URI=file:" + Application.persistentDataPath + "/" + "Game";
		IDbCommand cmnd = dbcon.CreateCommand();
		cmnd.CommandText = Item;
		cmnd.ExecuteNonQuery();

	}
	

	// Update is called once per frame
	void Update () {
		
	}
}