using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterManager : MonoBehaviour {

    private static SelectCharacterManager _instance; // 7~20라인 싱글톤

    public static SelectCharacterManager GetInstance() {
        if (_instance == null) {
            _instance = FindObjectOfType<SelectCharacterManager>();

            if (_instance == null) {
                GameObject container = new GameObject("SelectCharacterManager");
                _instance = container.AddComponent<SelectCharacterManager>();
            }
        }

        return _instance;
    }


    private string[] _characterCollections = new string[4]; // 4개의 캐릭터 (logcat, rass, sheeper, teles) 저장할 배열

    private int _playerCount = 1; // 플레이어 인원수, 나중에 플레이어 선택창에서 값 넘기면 그걸로 바꿀 변수

    private int[] _selectCharacterIndex = {0, 1, 2, 3}; // 임시로 (logcat, rass, sheeper, teles)


    // Start is called before the first frame update
    void Awake() {
        _characterCollections[0] = "logcat"; // 이름
        _characterCollections[1] = "rass";
        _characterCollections[2] = "sheeper";
        _characterCollections[3] = "teles";
    }
    

    // _characterCollections, _playerCount, _selectCharacterIndex 변수는 private이기 때문에
    // 다른 클래스에서 사용할려면 Getter를 이용해야만 값 가져올 수 있음
    public string GetCharcaterCollections(int index) {
        return _characterCollections[index];
    }

    public int GetPlayerCount() {
        return _playerCount;
    }

    public int GetSelectCharacterIndex(int index) {
        return _selectCharacterIndex[index];
    }
}
