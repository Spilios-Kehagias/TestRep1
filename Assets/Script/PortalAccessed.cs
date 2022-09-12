using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalAccessed : MonoBehaviour
{
    [SerializeField] int levelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (collision.GetComponent<PlayerQuest>().isQuestComplete == true)
            {
                GameObserver.SaveCoinsToMemory(collision.GetComponent<PlayerState>().coinAmount);
                SceneManager.LoadScene(levelToLoad);
            }
            
        }
    }


}
