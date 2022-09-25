using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver3 : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private GameObject questGiverText;

    [SerializeField] private Text textComponent;

    [SerializeField] private string questCompleteText;

    // Start is called before the first frame update
    void Start()
    {
        questGiverText.SetActive(false);
        animator = gameObject.GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            questGiverText.SetActive(true);
            textComponent.text = questCompleteText;
            collision.GetComponent<PlayerQuest>().isQuestComplete = true;

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
