VAR Mood=0
VAR NextMood=0

->PickedChoices

==PickedChoices==
#wait
*[A new name, a new color, is that enough?]->enough
*[People need treatment..]->treatment


==enough==
Twinkle: No, no, of course not. We need to be together. We need to fight together, to love together, to heal together, and, when we go, we should be dying together.
->enough2

==enough2
#wait
#delay
Twinkle: We can't let our brothers and sisters die bruised in the street, or succumb to the stigma. But I think this is a good start. At least we can stand together.
->GoodLuck

==treatment==
Twinkle: I know, honey, I do. But there isn't a treatment that works! It's relief, sure, but it's delaying the inevitable. Talked to Camilla last week, poor thing couldn't remember the word for dishwasher.
->treatment2

==treatment2
#wait
#delay
Twinkle: I don't know if the memory solving or the virus is scrambling her brain, but she's not coming out of this the same. We won't get treatment until people know how badly we need treatment.
->GoodLuck


==GoodLuck==
*[Well, good luck.]->well

==well==
#last
Twinkle: Thanks. The more that I live through, the more convinced I am that the only way out is through. And I believe this is how we live through it. Or at least, this is our best shot yet.
->END