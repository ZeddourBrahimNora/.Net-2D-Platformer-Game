using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isInRange;
    

    void Update()
    {
        // si player est a coté du pnj et si on clique sur E
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // vérifier si le player est entré dans la zone
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
    // lancer le système de dialogue
    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }






}
