#include <DigiKeyboard.h>
#define KEY_ESCAPE 0x29

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
    else if(digitalRead(key1)==HIGH){
      DigiKeyboard.delay(10);
      if(!state){
        DigiKeyboard.update();
        DigiKeyboard.sendKeyStroke(KEY_ESCAPE,MOD_CONTROL_LEFT | MOD_SHIFT_LEFT);
        DigiKeyboard.delay(200);
        state=true;
      }
    }
    else if(digitalRead(key2)==HIGH){
      DigiKeyboard.delay(10);
      if(!state){
        DigiKeyboard.update();
        DigiKeyboard.sendKeyStroke(KEY_U,MOD_CONTROL_LEFT | MOD_ALT_LEFT);
        DigiKeyboard.delay(200);
        state=true;
      }
    }
    else if(digitalRead(key3)==HIGH){
      DigiKeyboard.delay(10);
      if(!state){
        DigiKeyboard.update();
        DigiKeyboard.sendKeyStroke(KEY_W,MOD_CONTROL_LEFT | MOD_ALT_LEFT);
        DigiKeyboard.delay(200);
        state=true;
      }
    }
    else {
      state = true;
    }
    DigiKeyboard.delay(10);
    //2018.04.08 Firmware for Extension Keyboard powered by DigiSpark USB Development Board
    //Written by Atsushi Kambayashi All Rights Reserved.
    
      }

