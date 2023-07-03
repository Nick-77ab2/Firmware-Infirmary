VAR Mood=0
VAR NextMood=0

Camilla: Everytime you've dug into my head, it's helped. But every time after that? It's helped less. We're running out of time, doc.
->WorryChoices

==WorryChoices==
*[I'm not a doctor, Camilla.]->NotDoctor
*[I'll buy you as much time as I can.]->BuyTime

==NotDoctor==
#wait
#next
Camilla: You're not? Weren't you who Joselito was seeing?
->NotDoctorChoices

==NotDoctorChoices==
*[That was MEDicil.]->Joselito
*[I've never met Joselito.]->Joselito

==BuyTime==
#wait
#next
Camilla: Did you hear Joselito died? Just overnight. His boyfriend walked in and found him, lying in bed. He didn't even remember his boyfriend's name the night before. I'm not far from that.
->BuyTimeChoices

==BuyTimeChoices==
*[I never knew Joselito.]->Joselito

==Joselito==
#last
Camilla: He used to work at.. Well, I don't know. And now he's dead and gone. His whole life, my whole relationship with him, my whole life. Fading, fading away.
->END