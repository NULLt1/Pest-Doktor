using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReagentButtonSpawn : MonoBehaviour
{
    Vector2[] buttonPosition = new Vector2[3];
    int positionCounter = 0;
    private ItemProvider itemProvider;

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
        GameObject button = new GameObject();
        button.tag = "Reagent";
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        button.AddComponent<Shadow>();
        button.GetComponent<Image>().sprite = item.sprite;
        button.name = item.name;
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(190, 190);
        button.transform.SetParent(GameObject.Find("ReagentUI").transform);
        button.transform.localPosition = buttonPosition[positionCounter++];
        button.GetComponent<Button>().onClick.AddListener(() => AddItem(item));
        button.GetComponent<Button>().onClick.AddListener(() => DestroyButton(button));
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
            GameObject.Find("Player").GetComponent<PlayerCollisionScript>().toggleCanvas();
        }
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
