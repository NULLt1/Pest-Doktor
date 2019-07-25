using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using DatabaseN;
using ItemN;

public class PlayerInventoryScript : MonoBehaviour
{
    //public List<Item> inv = new List<Item>();
    private string alraune, tollkirsche, wachholder, fliegenpilz, morchel, kiefernschwamm, itemName, itemBezeichnung, itemDescription;
    private Text alrauneText, tollkirscheText, wachholderText, fliegenpilzText, morchelText, kiefernschwammText, itemText;
    public Sprite alrauneSprite, tollkirscheSprite, wachholderSprite, fliegenpilzSprite, morchelSprite, kiefernschwammSprite;
    public Image itemSprite;
    DatabaseManager databaseManager;
    Sprite spriteToUse;
    private GameObject itemInfoUI;


    // Start is called before the first frame update
    void Start()
    {
        //inv = GameObject.Find("Inventory").GetComponent<Inventory>().inventory;
        databaseManager = FindObjectOfType<DatabaseManager>();
        itemText = GameObject.Find("ItemText").GetComponent<Text>();
        itemInfoUI = GameObject.Find("ItemInfo");

        itemInfoUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        getAmountFromDatabase();
        setAmountText();
    }

    public void getAmountFromDatabase() {
        alraune = databaseManager.getSafeGameById(0).alrauneAmount;
        tollkirsche = databaseManager.getSafeGameById(0).tollkirscheAmount;
        wachholder = databaseManager.getSafeGameById(0).wachholderAmount;
        fliegenpilz = databaseManager.getSafeGameById(0).fliegenpilzAmount;
        morchel = databaseManager.getSafeGameById(0).morchelAmount;
        kiefernschwamm = databaseManager.getSafeGameById(0).kiefernschwammAmount;
    }

    public void setAmountText() {
        alrauneText = GameObject.Find("TextAlraune").GetComponent<Text>();
        tollkirscheText = GameObject.Find("TextTollkirsche").GetComponent<Text>();
        wachholderText = GameObject.Find("TextWachholder").GetComponent<Text>();
        fliegenpilzText = GameObject.Find("TextFliegenpilz").GetComponent<Text>();
        morchelText = GameObject.Find("TextMorchel").GetComponent<Text>();
        kiefernschwammText = GameObject.Find("TextKiefernschwamm").GetComponent<Text>();

        alrauneText.text = "x " + alraune;
        tollkirscheText.text = "x " + tollkirsche;
        wachholderText.text = "x " + wachholder;
        fliegenpilzText.text = "x " + fliegenpilz;
        morchelText.text = "x " + morchel;
        kiefernschwammText.text = "x " + kiefernschwamm;
    }

    public void showToolTip() {
        itemInfoUI.SetActive(true);
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "ItemAlraune":
            spriteToUse = alrauneSprite;
            itemName = "Alraune";
            itemBezeichnung = "Mandragora officinarum";
            itemDescription = "Die Alraune aus der Gattung Mandragora ist eine giftige Heil- und Ritualpflanze, die seit der Antike als Zaubermittel gilt, vor allem wegen ihrer besonderen Wurzelform, die der menschlichen Gestalt ähneln kann.";
            break;
            case "ItemTollkirsche":
            spriteToUse = tollkirscheSprite;
            itemName = "Schwarze Tollkirsche";
            itemBezeichnung = "Atropa belladonna";
            itemDescription = "Die Schwarze Tollkirsche ist eine giftige Pflanzenart aus der Familie der Nachtschattengewächse (Solanaceae). Der Gattungsname Atropa entspringt der griechischen Mythologie. Die griechische Göttin Atropos gehört zu den drei Schicksalsgöttinnen und ist diejenige, die den Lebensfaden durchschneidet.";
            break;
            case "ItemWachholder":
            spriteToUse = wachholderSprite;
            itemName = "Wachholder";
            itemBezeichnung = "Juniperus communis";
            itemDescription = "Der Gemeine Wacholder, auch Heide-Wacholder, ist eine Pflanzenart, die zur Gattung Wacholder aus der Familie der Zypressengewächse (Cupressaceae) gehört.";
            break;
            case "ItemFliegenpilz":
            spriteToUse = fliegenpilzSprite;
            itemName = "Fliegenpilz";
            itemBezeichnung = "Amanita muscaria";
            itemDescription = "Der Fliegenpilz ist eine giftige Pilzart aus der Familie der Wulstlingsverwandten. Die auch als Roter Fliegenpilz bezeichnete Spezies erscheint in Mitteleuropa von Juni bis zum Winter, hauptsächlich von Juli bis Oktober.";
            break;
            case "ItemMorchel":
            spriteToUse = morchelSprite;
            itemName = "Morchel";
            itemBezeichnung = "Morchella";
            itemDescription = "Die Morcheln sind eine Gattung der Schlauchpilze.";
            break;
            case "ItemKiefernschwamm":
            spriteToUse = kiefernschwammSprite;
            itemName = "Kiefernschwamm";
            itemBezeichnung = "Poria cocos";
            itemDescription = "Gemäß der Traditionellen Chinesischen Medizin hat der Poria cocos einen großen Organbezug zu den Nieren, der Milz und dem Herz. Damit verbunden ist sein hoher therapeutischer Wert bei Beschwerden und Krankheiten, die auf Störungen der Funktionskreise dieser Organe beruhen.";
            break;
        }
        itemSprite.GetComponent<Image>().sprite = spriteToUse;
        itemText.text = "Name: " + itemName + "\n\n" + "Bezeichnung: " + itemBezeichnung + "\n\n" + "Beschreibung: " + itemDescription;
    }

    public void closeItemInfo(){
        itemInfoUI.SetActive(false);
    }

}
