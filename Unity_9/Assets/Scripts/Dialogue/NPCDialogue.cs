using UnityEngine;
using System.Collections;

public class NPCDialogue : MonoBehaviour
{
    [Tooltip("Set this to the Canvas Group component on your message canvas.")]
    public CanvasGroup canvasGroup;

    [Tooltip("Set Typer component location.")]
    public Typer typer;

    private Animator anim;

    void Start()
    {
        // Find animator component in a child of the parent gameobject.
        anim = transform.parent.GetComponentInChildren<Animator>();
    }
    
    // Using collision layers, so a tag is not needed to determine if collider belongs to player.
    void OnTriggerEnter2D(Collider2D other)
    {
        typer.Talk();
        anim.SetTrigger("dialogueIn");

        // Make canvas visible.
        canvasGroup.alpha = 1;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        typer.Reset();
        anim.SetTrigger("dialogueOut");

        // Hide canvas.
        canvasGroup.alpha = 0;
    }
}
