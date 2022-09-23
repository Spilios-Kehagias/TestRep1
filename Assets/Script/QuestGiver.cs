using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    private Animator animator;
    
    [SerializeField] private GameObject questGiverText;

    [SerializeField] private Text textComponent;

    
    [SerializeField] private string questBeginText;
    [SerializeField] private string questCompleteText;
    [SerializeField] private int amountToCollect = 40;

    // Start is called before the first frame update
    void Start()
    {
        questGiverText.SetActive(false);
        animator = gameObject.GetComponent<Animator>();

        textComponent.text = questBeginText;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (collision.GetComponent<PlayerState>().coinAmount >= 40)
            {
                textComponent.text = questCompleteText;
                collision.GetComponent<PlayerQuest>().isQuestComplete = true;
            }
            else
            {
                textComponent.text = questBeginText;
            }
            questGiverText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            //if (collision.GetComponent<PlayerState>().iceaCreamAmount >= amountToCollect)
            //{
            //textComponent.text = questCompleteText;
            //collision.GetComponent<PlayerQuest>().isQuestComplete = true;
            //}

            //else
            //{
            //textComponent.text = questBeginText;
            //}
            questGiverText.SetActive(false);
            animator.SetTrigger("Sleep");
        }
    }
}
