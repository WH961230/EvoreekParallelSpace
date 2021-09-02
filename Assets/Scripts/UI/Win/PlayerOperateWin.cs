using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOperateWin : MonoBehaviour {
    public Text Tip;
    public List<Image> CrossAndPot;

    public void SetCrossAndPotColor(Color color)
    {
        foreach (var c in CrossAndPot)
        {
            c.color = color;
        }
    }
}