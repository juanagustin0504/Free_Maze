using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour { 

    private static CreateManager _instance;

    public static CreateManager GetInstance() {
        if (_instance == null) {
            _instance = FindObjectOfType<CreateManager>();

            if (_instance == null) {
                GameObject container = new GameObject("CreateManager");
                _instance = container.AddComponent<CreateManager>();
            }
        }

        return _instance;
    }

    public Transform wallParent;
    public Transform bushParent;

    private int _bushNum = 0;



    private int _mapHeight;
    private int _mapWidth;

    private float _blockHeight;
    private float _blockWidth;

    private float _posX;
    private float _posY;

    void Start() {
        SetMapHeight(100);
        SetMapWidth(100);
        GameObject wall = Instantiate(Resources.Load("Prefabs/walls/wall_wood"), new Vector3(0, 0, 0), Quaternion.identity, wallParent) as GameObject;
        SetBlockHeight(wall.transform.localScale.y * 2);
        SetBlockWidth(wall.transform.localScale.x * 2);
        CreateMap();
    }

    public void SetMapHeight(int mapHeight) {
        this._mapHeight = mapHeight;
    }

    public int GetMapHeight() {
        return _mapHeight;
    }

    public void SetMapWidth(int mapWidth) {
        this._mapWidth = mapWidth;
    }

    public int GetMapWidth() {
        return _mapWidth;
    }

    public void SetBlockHeight(float blockHeight) {
        this._blockHeight = blockHeight;
    }

    public float GetBlockHeight() {
        return _blockHeight;
    }

    public void SetBlockWidth(float blockWidth) {
        this._blockWidth = blockWidth;
    }

    public float GetBlockWidth() {
        return _blockWidth;
    }

    public void SetPosX(float posX) {
        this._posX = posX;
    }

    public float GetPosX() {
        return _posX;
    }

    public void SetPosY(float posY) {
        this._posY = posY;
    }

    public float GetPosY() {
        return _posY;
    }

    public void SetBushNum(int num) {
        this._bushNum += num;
    }

    public int GetBushNum() {
        return _bushNum;
    }

    public void CreateMap() {

        while (true) {
            if (_posX < _mapWidth) {
                SetPosX(_posX + _blockWidth);
            }
            if (_posY < _mapHeight) {
                SetPosY(_posY + _blockHeight);
            }

            Instantiate(Resources.Load("Prefabs/walls/wall_wood"), new Vector3(_posX, 0, 0), Quaternion.identity, wallParent);
            Instantiate(Resources.Load("Prefabs/walls/wall_wood"), new Vector3(0, _posY, 0), Quaternion.identity, wallParent);
            Instantiate(Resources.Load("Prefabs/walls/wall_wood"), new Vector3(_mapWidth + GetBlockWidth() - _posX, _mapHeight, 0), Quaternion.identity, wallParent);
            Instantiate(Resources.Load("Prefabs/walls/wall_wood"), new Vector3(_mapWidth, _mapHeight + GetBlockHeight() - _posY, 0), Quaternion.identity, wallParent);




            if (_posX >= _mapWidth && _posY >= _mapHeight) {
                break;
            }
        }

    }



}
