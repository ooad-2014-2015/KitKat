short d1,d2,d3;
void setup() {
  // put your setup code here, to run once:
pinMode(2,INPUT_PULLUP);
pinMode(3,INPUT_PULLUP);
pinMode(4,INPUT_PULLUP);
d1=0;
d2=0;
d3=0;
Serial.begin(9600);
}

void loop() {
  int vrijednost=digitalRead(2);
  if(vrijednost==LOW)
 {
  delay(90);
  vrijednost=digitalRead(2);
  if(vrijednost==LOW) Serial.print('1');
  }
  vrijednost=digitalRead(3);
  if(vrijednost==LOW)
  {
  delay(90);
  vrijednost=digitalRead(3);
  if(vrijednost==LOW) Serial.print('2');
  }
  vrijednost=digitalRead(4);
  if(vrijednost==LOW)
 {
  delay(90);
  vrijednost=digitalRead(4);
  if(vrijednost==LOW) Serial.print('3');
  }
  // put your main code here, to run repeatedly:

}
