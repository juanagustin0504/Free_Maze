using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager _instance;

    public static ItemManager GetInstance() {
        if (_instance == null) {
            _instance = FindObjectOfType<ItemManager>();

            if (_instance == null) {
                GameObject container = new GameObject("ItemManager");
                _instance = container.AddComponent<ItemManager>();
            }
        }

        return _instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBush() {
        GameObject bush = Instantiate(Resources.Load("Prefabs/bush"), new Vector3(0, 0, 0), Quaternion.identity, CreateManager.GetInstance().bushParent) as GameObject;
        bush.name = "bush" + CreateManager.GetInstance().GetBushNum(); // 복제된 bush 에 번호부여
        CreateManager.GetInstance().SetBushNum(1); // 1증가
    }

    public void DestroyBush() {

    }

}
