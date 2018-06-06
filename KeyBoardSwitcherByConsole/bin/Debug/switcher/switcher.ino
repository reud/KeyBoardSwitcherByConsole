#include <DigiKeyboard.h>

const int key1 = 1;
const int key2 = 0;
const int key3 = 2;
bool state = false;
void setup() {
  pinMode(key1,INPUT);
  pinMode(key2,INPUT);
  pinMode(key3,INPUT);
}
void loop(){
  if(digitalRead(key1) == LOW && digitalRead(key2) == LOW && digitalRead(key3) == LOW){
    state = false;}
    else {
      state = true;
    }
    DigiKeyboard.delay(10);
    //2018.04.08 Firmware for Extension Keyboard powered by DigiSpark USB Development Board
    //Written by Atsushi Kambayashi All Rights Reserved.
    
  }
