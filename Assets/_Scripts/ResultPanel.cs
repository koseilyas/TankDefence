using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Text _resultText;

    public void WinScreen()
    {
        _canvas.gameObject.SetActive(true);
        _resultText.text = "You win Next level";
    }
    
    public void LoseScreen()
    {
        _canvas.gameObject.SetActive(true);
        _resultText.text = "You Lose restart level";
    }
    
    public void DisablePanel()
    {
        _canvas.gameObject.SetActive(false);
    }
}
