using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiDialouges : MonoBehaviour
{
    public GameObject dialougePanel;
    
    public Text nameText;
    public Text dialougeText;

    public string[] names;
    public UiDataDialouges[] dialougeData;

    private int dialougTracker;

    private void Start()
    {
        dialougTracker = 0;
        StartTutorial();
    }

    void StartTutorial ()
    {
        // Connecting and storing question database information in the engine from the.csv file
 
        TextAsset kerdesAdatok = Resources.Load<TextAsset>("Alkotok kerdesek");
        string[] data = kerdesAdatok.text.Split(new[] { '\n' }); //Debug.Log(data.Length);

        dialougeData = new UiDataDialouges[data.Length - 2];
        for (int i = 1; i < data.Length - 1; i++)
        {
            string[] sor = data[i].Split(new char[] { ';' });
            int.TryParse(sor[0], out dialougeData[i - 1].dialougeNum); //Debug.Log(sor[0]);
            int.TryParse(sor[1], out dialougeData[i - 1].speakerId); //Debug.Log(sor[1]);
            dialougeData[i - 1].textLine = sor[1]; //Debug.Log(sor[2]);         
        }

        dialougePanel.gameObject.SetActive(true);
        AdvanceDialouges();
    }

    public void AdvanceDialouges ()
    {
        UpdateName(dialougTracker);
        UpdateDialouge(dialougTracker);
        dialougTracker += 1;
    }

    void UpdateName (int dialougeNumber)
    {
        nameText.text = names[dialougeData[dialougeNumber].speakerId];
    }

    void UpdateDialouge (int dialougeNumber)
    {
        dialougeText.text = dialougeData[dialougeNumber].textLine;
    }
}
