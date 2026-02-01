using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class model_control : MonoBehaviour
{
    public Button startButton;
    public Button finishButton;
    public List<GameObject> objects; //物件
    public float interval = 10f; // 間隔時間
    private Coroutine showObjectsCoroutine;
    
    void Start()
    {
        startButton.onClick.AddListener(StartSequence);
        finishButton.onClick.AddListener(FinishSequence);
    }

    public void StartSequence() //開始依序顯示物件
    {
        if (showObjectsCoroutine == null) // 確保不會重複執行
        {
            showObjectsCoroutine = StartCoroutine(ShowObjectsInSequence());
        }
    }

    public void FinishSequence() //全部物件一起消除
    {
        if (showObjectsCoroutine != null)
        {
            StopCoroutine(showObjectsCoroutine);
            showObjectsCoroutine = null;
        }

        // 隱藏所有物件
        foreach (var obj in objects)
        {
            obj.SetActive(false);
        }
    }

    private IEnumerator ShowObjectsInSequence() //物件依序出現
    {
        foreach (var obj in objects)
        {
            obj.SetActive(true); 
            yield return new WaitForSeconds(interval); 
        }

        // 重置 Coroutine
        showObjectsCoroutine = null;
    }
   


}
