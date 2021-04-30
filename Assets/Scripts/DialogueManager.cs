using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator; 

    private Queue<string> sentences; // semblable a une liste comme une fil d'attente elements qui arrivent a un moment et qui partent/disparaissent a un autre moment
    
    public static DialogueManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            return;
        }

        instance = this;

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true); // ouvrir le dialogue
        nameText.text = dialogue.name;

        sentences.Clear(); // s'assurer "la fil d'attente" est vide

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); // on fait passer les phrases dans la fil d'attente ca va se faire en ordre
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // vérifier si on a deja passer tt les phrases du dialogues
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); // on recupere le prochain element de la fil d'attente
        StopAllCoroutines(); // arrete l'execution de tt les coroutines si jamais le joueur skip une des phrases
        StartCoroutine(TypeSentence(sentence));
    }

    // utilisation d'une coroutine pour créer un effet de machine a écrire et faire apparaitre les lettres unes a unes
    
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false); // fermer le dialogue

    }
}
