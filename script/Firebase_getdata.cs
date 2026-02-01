using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;

public class Firebase_getdata : MonoBehaviour
{
    public static Firebase_getdata Instance;
    DatabaseReference reference;
    private List<string> existingKeys = new List<string>();

    public int get_dB;
    public int get_HZ;
    public int get_num;
    public Color get_color;
    [SerializeField]
    public bool Create_Fairy = false;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                // Firebase 準備好後取得 Database 的參考點
                reference = FirebaseDatabase.DefaultInstance.GetReference("data");

                // 先讀取已有的資料快照
                reference.GetValueAsync().ContinueWithOnMainThread(snapshotTask =>
                {
                    if (snapshotTask.IsCompleted)
                    {
                        DataSnapshot snapshot = snapshotTask.Result;

                        // 將已有的子項目名稱儲存在 existingKeys 中
                        foreach (DataSnapshot childSnapshot in snapshot.Children)
                        {
                            existingKeys.Add(childSnapshot.Key);
                        }

                        // 設置 ChildAdded 事件監聽器來監聽新增的子項目
                        StartListeningToDatabase();
                    }
                });
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + task.Result);
            }
        });
    }


    private void Update() {

    }



    void StartListeningToDatabase()
    {
        //偵測data
        reference.ChildAdded += HandleChildAdded;
    }


    void HandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        // 如果子項目名稱不在 existingKeys 裡，表示它是執行後新增的
        if (!existingKeys.Contains(args.Snapshot.Key))
        {
            // 取得子項目的名稱
            string childName = args.Snapshot.Key;

            get_dB = args.Snapshot.HasChild("0") ? Convert.ToInt32(args.Snapshot.Child("0").Value) : 0;
            get_HZ = args.Snapshot.HasChild("1") ? Convert.ToInt32(args.Snapshot.Child("1").Value) : 0;
            get_color = args.Snapshot.HasChild("2") ? ParseColorFromHex(args.Snapshot.Child("2").Value.ToString()) : Color.black;
            get_num = args.Snapshot.HasChild("3") ? Convert.ToInt32(args.Snapshot.Child("3").Value) : 0;

            //Debug.Log($"dB: {get_dB}, Hz: {get_HZ}, color: {get_color}, rand_num: {get_num}");

            // get_dB = 原solid_radius
            // get_HZ = 原solid_count
            // get_color = 原color
            // get_num = 亂數
            if(Create_Fairy){
                Debug.Log($"新增的子項目: {childName}");
                Fairy_gen.Instance.genFairy(get_dB, get_HZ, get_HZ, get_color, get_num);
            }
        }
    }


    public void CreateFairy(){
        Create_Fairy = !Create_Fairy;
        Debug.Log("Create Fairy = " + Create_Fairy.ToString());
    }

    Color ParseColorFromHex(string hex)
    {
        if (ColorUtility.TryParseHtmlString(hex, out Color color))
        {
            return color;
        }
        else
        {
            Debug.LogWarning("Invalid color code, defaulting to black.");
            return Color.black; // 若無法解析色碼，預設使用黑色
        }
    }
}
