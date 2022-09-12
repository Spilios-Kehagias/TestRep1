using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver2 : MonoBehaviour
{
    [SerializeField] private GameObject questGiverText;

    //[SerializeField] private int amountToCollect = 1;

    [SerializeField] private Text textComponent;

    //[SerializeField] private GameObject portalToOpenWhenQuestIsComplete;

    // Start is called before the first frame update
    void Start()
    {
        questGiverText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            questGiverText.SetActive(true);

            //if (collision.GetComponent<PlayerState>().iceaCreamAmount >= amountToCollect)
            //{
                //collision.GetComponent<PlayerQuest>().isQuestComplete = true;
                //portalToOpenWhenQuestIsComplete.SetActive(false);
            //}

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
             questGiverText.SetActive(false);
           
        }
    }
}
