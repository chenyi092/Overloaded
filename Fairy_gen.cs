using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fairy_gen : MonoBehaviour
{
    public static Fairy_gen Instance;
    public GameObject _Fairy;
    public Vector3 rand;
    int rand_posy;

    private void Awake()
    {
        Instance = this;

    }

    public void genFairy(int SolidRadiuus, int SolidCount, int OrbitingCount, Color color, int RandNum)
    {
        if (_Fairy == null)
        {
            Debug.LogError("_Fairy is null. Please assign it a valid GameObject before using it.");
            return;
        }

        Transform fairyChild = _Fairy.transform.Find("fairy");
        Fairy prefabScript = _Fairy.GetComponent<Fairy>();

        if (prefabScript == null)
        {
            Debug.LogError("Fairy component not found on _Fairy GameObject.");
            return;
        }

        //分貝數據->控制小圓點外擴範圍
        prefabScript.solidCircleOrbitRadius = SolidRadiuus;

        //頻率數據->控制小圓點數量
        double circle_count = MapToRange(SolidCount, 50, 800, 2, 7);
        prefabScript.solidCircleCount = (int)Math.Round(circle_count);

        //外部圓圈數量
        prefabScript.orbitingCircleCount = 5;

        //色號
        prefabScript.red = color.r;
        prefabScript.green = color.g;
        prefabScript.blue = color.b;

        //外部圈的邊數
        if(RandNum == 0)
        {
            prefabScript.cicccSegmentCount = 50;
        }
        else
        {
             prefabScript.cicccSegmentCount = RandNum;
        }
       
        // Debug.Log($"dB: {SolidRadiuus}, Hz1: {SolidCount}, Hz2: {OrbitingCount}, color: {color}");

        //生成
        rand = UnityEngine.Random.insideUnitCircle * 1000; //在半徑1000內的地方生成
        int rand_posx = UnityEngine.Random.Range(-1000,1000);
        int rand_posz = UnityEngine.Random.Range(-1000,1000);
        int pattern = UnityEngine.Random.Range(0,4);

        switch(pattern)
        {
            case 0:
            case 1:
                rand_posy = UnityEngine.Random.Range(1200,2000);
                break;
            case 2:
            case 3:
                rand_posy = UnityEngine.Random.Range(400,1200);
                break;
            case 4:
                rand_posy = UnityEngine.Random.Range(-400,400);
                break;
        }
        //Debug.Log("position" + rand_posx +  rand_posy + rand_posz);
        //_Fairy = Instantiate(_Fairy, new Vector3(rand.x, rand.y, rand.z), Quaternion.identity);
        GameObject newFairyInstance = Instantiate(_Fairy, new Vector3(rand.x + rand_posx, rand.y + rand_posy, rand.z + rand_posz), Quaternion.identity);
        Destroy(newFairyInstance, 30.0f);
        //測試
    }

    double MapToRange(int value, int inputMin, double inputMax, double outputMin, double outputMax)
    {
        return value * (outputMax - outputMin) / (inputMax - inputMin);
    }

}
