using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public int columnLength, rowLength;
    public float x_Space,z_Space;
    public GameObject grass;
    public GameObject[] currentGrid;
    public bool gotGrid;

    public GameObject hitted;
    public GameObject field;
    private RaycastHit _Hit;
    public bool creatingFields;

    public Texture2D basicCorsor, fieldCorsor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public GameObject goldSystem;
    public int fieldsPrice;
    void Awake() {
        Cursor.SetCursor(basicCorsor,hotSpot,cursorMode);    
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0 ; i<columnLength * rowLength; i++){
            Instantiate(grass,new Vector3(x_Space+(x_Space * (i%columnLength)),0,z_Space+(z_Space *(i/columnLength))),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gotGrid == false) {
            currentGrid  = GameObject.FindGameObjectsWithTag("gid");
            gotGrid = true;
        }

        if(Input.GetMouseButtonDown(0)){
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out _Hit)){
                if(creatingFields == true){
                    if(_Hit.transform.tag == "gid" && goldSystem.GetComponent<GoldSystem>().gold >= fieldsPrice){
                        hitted  = _Hit.transform.gameObject;
                        Instantiate(field,hitted.transform.position,Quaternion.identity);
                        Destroy(hitted);

                        goldSystem.GetComponent<GoldSystem>().gold -= fieldsPrice;
                    }

                    Cursor.SetCursor(fieldCorsor,hotSpot,cursorMode);
                }
            }
        }

        if(creatingFields== true){
            Cursor.SetCursor(fieldCorsor,hotSpot,cursorMode);
        }
    }

    public void CreateFields(){
        creatingFields = true;
    }

    public void returnToNormality(){
        creatingFields = false;
    }
}
