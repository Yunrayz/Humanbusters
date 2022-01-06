using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class doorCanvas : MonoBehaviour
{
    public Canvas helperCanvas;
    public TMP_Text helperText;
    protected virtual void Start()
    {
        helperCanvas.gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        helperText.text = "Press SPACE to move to the " + this.name;
        helperCanvas.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        helperCanvas.gameObject.SetActive(false);
    }


}
