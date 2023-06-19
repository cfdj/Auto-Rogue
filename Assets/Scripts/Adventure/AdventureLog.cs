using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdventureLog : MonoBehaviour
{
    public List<Text> texts;
    public List<string> logs;
    public Text textPrefab;
    public GameObject logHolder;
    int numLogs = 0;
    public void AddLog(string log)
    {
        logs.Add(log);
        if(numLogs == 0)
        {
            Debug.Log("Starting logging");
            StartCoroutine(displayLog());
        }
        numLogs++;
    }
    public IEnumerator displayLog()
    {
        yield return new WaitForSeconds(0.5f);
        Text nText = Instantiate(textPrefab, logHolder.gameObject.transform, false);
        nText.text = logs[0];
        nText.gameObject.SetActive(true);
        nText.transform.SetAsFirstSibling();
        texts.Add(nText);
        nText.text = logs[0];
        logs.RemoveAt(0);
        numLogs--;
        if (logs.Count > 0)
        {
            StartCoroutine(displayLog());
        }
    }
    public void ClearLog()
    {
        StopAllCoroutines();
        for(int i = texts.Count - 1; i >= 0; i--)
        {
            Destroy(texts[i]);
        }
        texts.Clear();
        logs.Clear();
        numLogs = 0;
    }
}
