using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int[] id;
    public string[] productName;
    public int[] price; 
    public int numberOfProducts;
    public GameObject shopWindow;
    // public GameObject productPrefab;
    public GameObject[] products;
    public int pageNumber;
    
    void Start()
    {
         for(int i =0; i <numberOfProducts;i++){
            products[i].SetActive(false);
         }

         Refesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenShop(){
        shopWindow.SetActive(true);

        Refesh();
    }

    public void CloseShop(){
        shopWindow.SetActive(false);
    }

    public void Refesh()
    {
        for(int i=0; i< numberOfProducts; i++){
            products[i].SetActive(false);
        }

        if(pageNumber == 1){
            for(int i=0; i<numberOfProducts; i++){
                products[i].GetComponent<Product>().id = id[i];
                products[i].SetActive(true); 
            }
        }
    }

    public void Left(){

    }

    public void Right(){

    }
}
