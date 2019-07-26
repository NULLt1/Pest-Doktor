using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemN;
// NULLt1
public class ReagentController : MonoBehaviour
{
    Vector2[] buttonPosition = new Vector2[3];
    int positionCounter = 0;
    private ItemProvider itemProvider;
    private SoundController soundController;

    void Start()
    {
        buttonPosition[0] = new Vector2(-50, -226);
        buttonPosition[1] = new Vector2(-150, 169);
        buttonPosition[2] = new Vector2(144, 50);

        if (GameObject.Find("ItemProvider") != null)
        {
            itemProvider = GameObject.Find("ItemProvider").GetComponent<ItemProvider>();
        }
    }

    void Update()
    {

    }

    public void spawnReagentButtons()
    {
        GameObject reagent = GameObject.FindWithTag("Collision");
        int[] randomItems = reagent.GetComponent<ReagentRandomizer>().getRandomItems();
        foreach (int index in randomItems)
        {
            CreateButton(index);
        }
        positionCounter = 0;
    }

    public void CreateButton(int index)
    {
        Item item = itemProvider.getReagentItem(index);
        GameObject buttonGameobject = new GameObject();
        buttonGameobject.tag = "Reagent";
        buttonGameobject.AddComponent<Button>();
        buttonGameobject.AddComponent<Image>();
        buttonGameobject.AddComponent<Shadow>();
        buttonGameobject.GetComponent<Image>().sprite = item.sprite;
        buttonGameobject.name = item.name;
        buttonGameobject.GetComponent<RectTransform>().sizeDelta = new Vector2(190, 190);
        buttonGameobject.transform.SetParent(GameObject.Find("ReagentUI").transform);
        buttonGameobject.transform.localPosition = buttonPosition[positionCounter++];
        buttonGameobject.GetComponent<Button>().onClick.AddListener(() => PlaySound());
        buttonGameobject.GetComponent<Button>().onClick.AddListener(() => DebugTester());
        buttonGameobject.GetComponent<Button>().onClick.AddListener(() => AddItem(item));
        buttonGameobject.GetComponent<Button>().onClick.AddListener(() => DestroyButton(buttonGameobject));
    }

    private void AddItem(Item item)
    {
        GameObject.Find("Inventory").GetComponent<Inventory>().AddItem(item.id);
    }

    private void DestroyButton(GameObject button)
    {
        Destroy(button);
        if (GameObject.FindGameObjectsWithTag("Reagent").Length == 1)
        {
            randomizeAndHideReagent();
            GameObject.Find("Player").GetComponent<PlayerCollisionScript>().toggleReagentCanvas();
        }
    }

    public void DebugTester() {
        Debug.Log("TEEEEST");
    }

    private void PlaySound() {
        Debug.Log("PlaySound1");
        GameObject.Find("SoundController").GetComponent<SoundController>().playSound();
    }

    private void randomizeAndHideReagent()
    {
        GameObject reagent = GameObject.FindWithTag("Collision");
        reagent.SetActive(false);
        reagent.GetComponent<ReagentRandomizer>().reagentRandomizerTrigger();
        StartCoroutine(LateCall(reagent));
    }

    IEnumerator LateCall(GameObject reagent)
    {
        yield return new WaitForSeconds(30f);
        reagent.SetActive(true);
    }
}
