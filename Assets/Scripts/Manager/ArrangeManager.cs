using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangeManager : MonoBehaviour {

    private static ArrangeManager _instance; // 7~20라인 싱글톤

    public static ArrangeManager GetInstance() {
        if (_instance == null) {
            _instance = FindObjectOfType<ArrangeManager>();

            if (_instance == null) {
                GameObject container = new GameObject("ArrangeManager");
                _instance = container.AddComponent<ArrangeManager>();
            }
        }

        return _instance;
    }
    [SerializeField]
    GameObject[] _players; // 게임 플레이하는 플레이어를 저장할 배열

    void Start() {
        _players = new GameObject[SelectCharacterManager.GetInstance().GetPlayerCount()];
        // Instantiate: (원본, 위치, 방향)
        // Instantiate(리소스폴더에 있는 Prefabs/player/경로로 들어가 4개의 캐릭터들 중 플레이어가 선택한 캐릭터로 게임 오브젝트를 가져온다.
        for(int i = 0; i < _players.Length; i++) {
            _players[i] = Instantiate(Resources.Load("Prefabs/player/"
                + SelectCharacterManager.GetInstance()
                .GetCharcaterCollections(SelectCharacterManager.GetInstance()
                .GetSelectCharacterIndex(i)))
                , new Vector3(0, 0, 0)
                , Quaternion.identity)
                as GameObject;
        }

        Arrange(); // 플레이어 위치 설정
        SetInfo(); // 플레이어 정보 설정
    }

    public void Arrange() { // 플레이어 위치 설정하는 함수
        //_players[0].transform.position = new Vector3(MazeMake.mapSize / 2, 1.5f, 0); // 화면 하단 가운데
        //_players[1].transform.position = new Vector3(MazeMake.mapSize, MazeMake.mapSize / 2 + 0.5f, 0); // 화면 중단 오른쪽
        //_players[2].transform.position = new Vector3(MazeMake.mapSize / 2, MazeMake.mapSize + 0.5f, 0); // 화면 상단 가운데
        //_players[3].transform.position = new Vector3(1, MazeMake.mapSize / 2 + 0.5f, 0); // 화면 중단 왼쪽
        _players[0].transform.position = new Vector3(1, 1.5f, 0);

    }

    public void SetInfo() { // 플레이어 정보 설정하는 함수
        for(int i = 0; i < SelectCharacterManager.GetInstance().GetPlayerCount(); i++) { // 인원수 만큼 반복
            // 태그 설정 : Player1, Player2...
            _players[i].tag = "Player"; 
            // 이름 설정 : Player1(logcat)
            _players[i].name = _players[i].tag + "(" + SelectCharacterManager.GetInstance().GetCharcaterCollections(SelectCharacterManager.GetInstance().GetSelectCharacterIndex(i)) + ")"; 

        }
    }

    public GameObject GetPlayer(int index) {
        return _players[index];
    }
}
