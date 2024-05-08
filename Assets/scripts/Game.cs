using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

namespace Program{
public class Game : MonoBehaviour 
{

public TMP_Text power1, power2, gamewins1, gamewins2;
public Image downcard1, downcard2;
public List <GameObject> Deck = new List<GameObject>();
 List <GameObject> Deck1 = new List<GameObject>();
 List <GameObject> Deck2 = new List<GameObject>();
public List <GameObject> hand1 = new List<GameObject>();
public List <GameObject> hand2 = new List<GameObject>();
 List <GameObject> newhand1 = new List<GameObject>();
 List <GameObject> newhand2 = new List<GameObject>();
public List <GameObject> distancia1 = new List<GameObject>();
public List <GameObject> distancia2 = new List<GameObject>();
List <GameObject> newdistancia1 = new List<GameObject>();
 List <GameObject> newdistancia2 = new List<GameObject>();
public List <GameObject> cuerpoacuerpo1 = new List<GameObject>();
public List <GameObject> cuerpoacuerpo2 = new List<GameObject>();
List <GameObject> newcuerpoacuerpo1 = new List<GameObject>();
List <GameObject> newcuerpoacuerpo2 = new List<GameObject>();
public List <GameObject> asedio1 = new List<GameObject>();
public List <GameObject> asedio2 = new List<GameObject>();
List <GameObject> newasedio1 = new List<GameObject>();
 List <GameObject> newasedio2 = new List<GameObject>();


void shuffle(int cantidad) {
for (int x=0; x<Deck.Count; x++){
  Deck1.Add(Deck[x]);
  Deck2.Add(Deck[x]);
}

while (Deck1.Count!=cantidad){
   System.Random random = new System.Random();
 int n = random.Next(0,Deck1.Count-1);
 Deck1.RemoveAt(n);
}

while (Deck2.Count!=cantidad){
   System.Random random = new System.Random();
 int n = random.Next(0,Deck2.Count-1);
 Deck2.RemoveAt(n);
}

}




void draw(int n, bool P1, bool P2) {

 if (P1) {

   int caux = newhand1.Count;
   int c = caux;
   if (c == hand1.Count) return ;
   c = Math.Min(n,Math.Abs(hand1.Count - c));

   for (int x=0 ;  x<c; x++){

       newhand1.Add(Deck1[0]);
       Button aux  = newhand1[newhand1.Count-1].GetComponentInChildren<Button>();
       Button aux2 = Deck1[0].GetComponentInChildren<Button>();
       aux.image.sprite = aux2.image.sprite;
      
      Deck1.RemoveAt(0);
   }
  
 }

 if (P2) {

   int caux = newhand2.Count;
   int c = caux;
   if (c == hand2.Count) return ;
   c = Math.Min(n,Math.Abs(hand2.Count - c));

   for (int x=0 ;  x<c; x++){

     newhand2.Add(Deck2[0]);
       Button aux  = newhand2[newhand2.Count-1].GetComponentInChildren<Button>();
        Button aux2 = Deck2[0].GetComponentInChildren<Button>();
       aux.image.sprite = aux2.image.sprite;

       Deck2.RemoveAt(0);
 }

}
}
 

bool turn = true ; 

 int n;
 int vict = 0;

 public void playercard1(int aux){
   
   n=aux;
  
 }

 public void playercard2(){
  
  vict = 0;

  if (turn){
 CardDataBase script = newhand1[n-1].GetComponent<CardDataBase>();
  if(script.tipe == 'c' ) newcuerpoacuerpo1.Add(newhand1[n-1]);
  if(script.tipe == 'd' ) newdistancia1.Add(newhand1[n-1]);
  if(script.tipe == 'a' ) newasedio1.Add(newhand1[n-1]);
  newhand1.RemoveAt(n-1);
  turn = false;
  return ;
  }

  if(!turn){
  CardDataBase script = newhand2[n-1].GetComponent<CardDataBase>();
  if(script.tipe == 'c' ) newcuerpoacuerpo2.Add(newhand2[n-1]);
  if(script.tipe == 'd' ) newdistancia2.Add(newhand2[n-1]);
  if(script.tipe == 'a' ) newasedio2.Add(newhand2[n-1]);
  newhand2.RemoveAt(n-1);
  turn = true;
  }
  
 }



 public void playerboss(int n){

  vict = 0;
  
  if(n==1){
    if (turn == false) return ;

    System.Random random = new System.Random();
     

   
    System.Random random2 = new System.Random();
    int aux = random2.Next(1,3);
    if(aux==1){
      if(newcuerpoacuerpo2.Count == 0 ) goto gaby;
      int elim = random.Next(0,newcuerpoacuerpo2.Count-1);
      newcuerpoacuerpo2.RemoveAt(elim);
      
    }
    if(aux==2){
      if(newdistancia2.Count == 0 ) goto gaby;
      int elim = random.Next(0,newdistancia2.Count-1);
      newdistancia2.RemoveAt(elim);
     
    }
     if(aux==3){
      if(newasedio2.Count == 0 ) goto gaby;
      int elim = random.Next(0,newasedio2.Count-1);
      newasedio2.RemoveAt(elim);
     
    }
    gaby :
    turn = false;
    return ;
  }

  if (n==2){
    if(turn == true) return ; 

    draw(1,false, true);
    turn = true;
    return ;
  }

 }


 public void passturn(){

 vict++;
 if(!turn) turn = true;
 else turn = false;

 }




 private void Start() {
 power1.text = "0";
 power2.text = "0";
 gamewins1.text = "0";
 gamewins2.text = "0";
 shuffle(24);
 draw (10 , true , true);
   
 }

 


void actualizacion(){

  

  if(turn){
    downcard1.enabled = false;
    downcard2.enabled = true;
    for(int i=0;i<hand2.Count;i++)
    {
      Button rr = hand2[i].GetComponentInChildren<Button>();
      rr.image.enabled=false;
    }
     for(int i=0;i<hand1.Count;i++)
    {
      Button rr = hand1[i].GetComponentInChildren<Button>();
      rr.image.enabled=true;
    }
    

  }
  else {
    downcard1.enabled = true;
    downcard2.enabled = false;
    for(int i=0;i<hand2.Count;i++)
    {
      Button rr = hand2[i].GetComponentInChildren<Button>();
      rr.image.enabled=true;
    }
     for(int i=0;i<hand1.Count;i++)
    {
      Button rr = hand1[i].GetComponentInChildren<Button>();
      rr.image.enabled=false;
    }
  }


 
  int c=0;

  for (int x=0; x< newcuerpoacuerpo1.Count; x++){
    CardDataBase script = newcuerpoacuerpo1[x].GetComponent<CardDataBase>();
    c+=script.power;
  }
  for (int x=0; x< newdistancia1.Count; x++){
    CardDataBase script = newdistancia1[x].GetComponent<CardDataBase>();
    c+=script.power;
  }
  for (int x=0; x< newasedio1.Count; x++){
    CardDataBase script = newasedio1[x].GetComponent<CardDataBase>();
    c+=script.power;
  }
  
  power1.text = c.ToString();

   
  c=0;
 
 for (int x=0; x< newcuerpoacuerpo2.Count; x++){
    CardDataBase script = newcuerpoacuerpo2[x].GetComponent<CardDataBase>();
    c+=script.power;
  }
  for (int x=0; x< newdistancia2.Count; x++){
    CardDataBase script = newdistancia2[x].GetComponent<CardDataBase>();
    c+=script.power;
  }
  for (int x=0; x< newasedio2.Count; x++){
    CardDataBase script = newasedio2[x].GetComponent<CardDataBase>();
    c+=script.power;
  }
  
  power2.text = c.ToString();

  

  for(int x=0 ; x<newhand1.Count ; x++){
      Button aux = hand1[x].GetComponentInChildren<Button>();
    
      Button aux2 = newhand1[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = newhand1.Count; x < hand1.Count; x++){
    Button aux = hand1[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

  

  for(int x=0 ; x<newhand2.Count ; x++){
      Button aux = hand2[x].GetComponentInChildren<Button>();
   
      Button aux2 = newhand2[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
    for(int x = newhand2.Count; x < hand2.Count; x++){
    Button aux = hand2[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

 

  for(int x=0 ; x<newcuerpoacuerpo1.Count ; x++){
      Button aux = cuerpoacuerpo1[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = newcuerpoacuerpo1[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = newcuerpoacuerpo1.Count; x < cuerpoacuerpo1.Count; x++){
    Button aux = cuerpoacuerpo1[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

   

  for(int x=0 ; x<newcuerpoacuerpo2.Count ; x++){
      Button aux = cuerpoacuerpo2[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = newcuerpoacuerpo2[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = newcuerpoacuerpo2.Count; x < cuerpoacuerpo2.Count; x++){
    Button aux = cuerpoacuerpo2[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

 

  for(int x=0 ; x<newdistancia1.Count ; x++){
      Button aux = distancia1[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = newdistancia1[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = newdistancia1.Count; x < distancia1.Count; x++){
    Button aux = distancia1[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }
  
  

  for(int x=0 ; x<newdistancia2.Count ; x++){
      Button aux = distancia2[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 =  newdistancia2[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = newdistancia2.Count; x < distancia2.Count; x++){
    Button aux = distancia2[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

   

  for(int x=0 ; x<newasedio1.Count ; x++){
      Button aux = asedio1[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = newasedio1[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = newasedio1.Count; x < asedio1.Count; x++){
    Button aux = asedio1[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

    

  for(int x=0 ; x<newasedio2.Count ; x++){
      Button aux = asedio2[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = newasedio2[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = newasedio2.Count; x < asedio2.Count; x++){
    Button aux = asedio2[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }


}
   
   void cleangame(){
    newcuerpoacuerpo1.Clear();
    newcuerpoacuerpo2.Clear();
    newdistancia1.Clear();
    newdistancia2.Clear();
    newasedio1.Clear();
    newasedio2.Clear();
   }
  
  
  void win (){
    if(vict==2){

      if(int.Parse(power1.text)>int.Parse(power2.text)){
        int c = int.Parse(gamewins1.text);
        c++;
        gamewins1.text = c.ToString();
      }
      if(int.Parse(power1.text)<int.Parse(power2.text)){
        int c = int.Parse(gamewins2.text);
        c++;
        gamewins2.text = c.ToString();
      }
      if(power1.text==power2.text){
        int c = int.Parse(gamewins1.text);
        c++;
        gamewins1.text = c.ToString();
        int c1 = int.Parse(gamewins2.text);
        c1++;
        gamewins2.text = c1.ToString();
      }
     
     cleangame();
     draw(2, true, true);
     vict=0;
     gameover ();
    }
  }

  void gameover()
{
  if(gamewins1.text == gamewins2.text && gamewins1.text == "2")
  {
    SceneManager.LoadScene("Empate");

    return ;
  }

  if(gamewins1.text == "2")
  {
    SceneManager.LoadScene("WinPlayer1");
  }

  if(gamewins2.text == "2")
  {
    SceneManager.LoadScene("WinPlayer2");
  }

}

 private void Update() {
    actualizacion();
    win();    
  }

  




}

}