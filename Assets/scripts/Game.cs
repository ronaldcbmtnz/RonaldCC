using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Unity.Collections;

namespace Program{
public class Game : MonoBehaviour 
{

public TMP_Text power1, power2, gamewins1, gamewins2;

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

 List <int> valcuerpoacuerpo1 = new List <int> ();
 
 List <int> valcuerpoacuerpo2 = new List <int> ();
 
 List <int> valordistancia1 = new List <int> ();
 
 List <int> valordistancia2 = new List <int> ();
 
 List <int> valorasedio1 = new List <int> ();
 
 List <int> valorasedio2 = new List <int> ();

 public Image Agrandar ;

 /*

 El metodo shuffle es el que vamos a emplear para crear los mazos de cada jugador. Este recibe un entero que sera la cantidad de cartas
 que queremos que tenga cada mazo, luego a cada mazo (Deck1 y Deck2) se le añaden todas las cartas de la lista que contiene a las cartas(Deck).
 Despues de esto se eliminan cartas al azar de cada mazo hasta tener cantidad de cartas igual al entero recibido.

*/


void shuffle(int cantidad) {
  
for (int x=0; x<Deck.Count; x++){
  System.Random random= new System.Random();
 int j = random.Next(x,Deck.Count-1);
  GameObject rr = Deck[x];
  Deck[x]=Deck[j];
  Deck[j]=rr;

  Deck1.Add(Deck[x]);
   
}
for(int x=0; x<Deck.Count;x++)
{
   System.Random random= new System.Random();
 int j = random.Next(x,Deck.Count-1);
  GameObject rr = Deck[x];
  Deck[x]=Deck[j];
  Deck[j]=rr;
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
/*

El metodo draw recibe un entero que es la cantidad de cartas de cada mano (10) y dos booleanos que representa si le toca robar a J1 o J2,
en este caso ambos booleanos comienzan en true ya que es el robo inicial(los dos roban 10 cartas). 

*/

void draw(int n, bool P1, bool P2) {

 if (P1) {

   int caux = newhand1.Count;
   int c = caux;
   if (c == hand1.Count) return ;
   c = Math.Min(n,Math.Abs(hand1.Count - c));

   for (int x=0 ; x<c; x++){

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
 
// la variable booleana turno si es true es el turno de J1 y si es false es el turno de J2
bool turn = true ; 

/* en esta variable n vamos a guardar la posicion en la mano de la carta que ha sido jugada para posteriormente 
 pasarla al campo y eliminarla de la mano */
 int n;

 // En n llevaremos el conteo de las veces que se le da al boton pass por cada jugador, el cual se reiniciara cada vez que se juegue una carta
 int count = 0;


/* Estas funciones son para jugar las cartas al campo en la faccion que les corresponde(van adjuntas a los botones que representan las cartas
   de la mano)   */
 public void playercard1(int aux)
 {  
  
   n=aux;
 }

 public void playercard2(){
  
  count = 0;

  if (turn){
 CardDataBase script = newhand1[n-1].GetComponent<CardDataBase>();

  if(script.tipe == 'c' ) 
  {
  newcuerpoacuerpo1.Add(newhand1[n-1]);
  valcuerpoacuerpo1.Add(script.power);
  }
  if(script.tipe == 'd' ) 
  {
   newdistancia1.Add(newhand1[n-1]);
    valordistancia1.Add(script.power);
  }
  if(script.tipe == 'a' ){
   newasedio1.Add(newhand1[n-1]);
    valorasedio1.Add(script.power);
   }
  if(script.tipe == 'w'){
    
  
    for(int x =0; x< valcuerpoacuerpo1.Count; x++){
     valcuerpoacuerpo1[x]++;
    }
        for(int x =0; x< valordistancia1.Count; x++){
       valordistancia1[x]++;
    }
    for(int x =0; x< newasedio1.Count; x++){
     valorasedio1[x]++;
    }

  }
  newhand1.RemoveAt(n-1);
  turn = false;
  return ;
  }

  if(!turn){
  CardDataBase script = newhand2[n-1].GetComponent<CardDataBase>();
  if(script.tipe == 'c' )
  {
    newcuerpoacuerpo2.Add(newhand2[n-1]);
    valcuerpoacuerpo2.Add(script.power);
  }
  if(script.tipe == 'd' )
  {
   newdistancia2.Add(newhand2[n-1]);
   valordistancia2.Add(script.power);
  }
  if(script.tipe == 'a' )
  {
   newasedio2.Add(newhand2[n-1]);
    valorasedio2.Add(script.power);
  }
  if(script.tipe == 'w') {
    for(int x =0; x< valcuerpoacuerpo2.Count; x++){
     valcuerpoacuerpo2[x]++;
    }
        for(int x =0; x< valordistancia2.Count; x++){
       valordistancia2[x]++;
    }
    for(int x =0; x< newasedio2.Count; x++){
     valorasedio2[x]++;
    }
    }
  newhand2.RemoveAt(n-1);
  turn = true;
  }
  
 }


/* Esta funcion va adjunta a los botones de las cartas jefe y el parametro n si es ==  1 pues la carta jefe que ha sido 
 seleccionada es Lilo y se activara su efecto el cual es elegir un numero de fila aleatorio del campo del contrario
 y si esa fila tiene monstruos pues elegira uno de ellos al azar y lo elimina del campo de batalla y sino 
 tiene monstruos pues perdiste el turno. Si m == 2 pues se activa el efecto del Hamsterviel y roba una carta.  */
 public void playerboss(int n){

  count = 0;
  
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

// Este metodo va adjunto al boton Pass y es el que permite pasar de turno


 public void passturn(){

 count++;
 if(!turn) turn = true;
 else turn = false;

 }
 public void AgrandarCarta(int n)
 {
  Button rr;
  if(turn)
  {
    rr=newhand1[n-1].GetComponentInChildren<Button>();
  }
  else
  {
    rr=newhand2[n-1].GetComponentInChildren<Button>();
  }
  Agrandar.GetComponent<Image>().enabled=true;
  Agrandar.sprite=rr.image.sprite;
 }
 public void RemoveAgrandar()
 {
  Agrandar.GetComponent<Image>().enabled=false;
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

  // Lo primero que hacemos en este metodo es desactivar la mano del jugador dos si es el turno del jugador uno y viceversa
  

  if(turn){
    
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

  // Aqui lo que hacemos es sumar los puntos de cada carta en las facciones al acumulador de poder del jugador 
 
  int c=0;

  for (int x=0; x< valcuerpoacuerpo1.Count; x++){
    c+=valcuerpoacuerpo1[x];
  }
  for (int x=0; x< valordistancia1.Count; x++){
    c+=valordistancia1[x];
  }
  for (int x=0; x<valorasedio1.Count; x++){
    c+=valorasedio1[x];
  }
  
  power1.text = c.ToString();

   
  c=0;
 
for (int x=0; x< valcuerpoacuerpo2.Count; x++){
    c+=valcuerpoacuerpo2[x];
  }
  for (int x=0; x< valordistancia2.Count; x++){
    c+=valordistancia2[x];
  }
  for (int x=0; x<valorasedio2.Count; x++){
    c+=valorasedio2[x];
  }
  
  power2.text = c.ToString();

  // Actualizacion de las manos...

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

  //Actualizacion de cuerpo a cuerpo

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

  // Actualizacion de la distancia 

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

   // Actualizacion del asedio

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
    valcuerpoacuerpo1.Clear();
    valcuerpoacuerpo2.Clear();
    valorasedio1.Clear();
    valorasedio2.Clear();
    valordistancia1.Clear();
    valordistancia2.Clear();  
   }
  
   // Cuando el boton pass se ha presionado 2 veces seguidas sin jugar ninguna carta o efecto se ejecuta el metodo win 
  void win (){
    if(count==2){

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
     count=0;
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