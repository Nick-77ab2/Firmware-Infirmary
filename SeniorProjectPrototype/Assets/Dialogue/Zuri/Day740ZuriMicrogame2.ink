VAR Mood=0
VAR NextMood=0

->FalseHope

==FalseHope==
#Go
*[Start Painting] -> Why

==Why==
How?
->END

==Happen==
Zuri: I don't gamble, I have enough vices already. But if I was a gambling woman, I would only make the crazy bet when I have nothing left to lose.
->Happen2

==Happen2
#delay
Zuri: I still have something to lose, so why take that bet? Well. Maybe I've got to take a chance before I go broke. I don't know.
->HappenChoices

==HappenChoices==
*[If you gotta roll the dice, bet on the people who know you.]->Chance

==Backs==
Zuri: Who has my back? The movement lead by the remnants of my previous failed relationship? Who I'm not even on speaking terms with? That's my salvation? It's nice to try to build something, but I don't have people like that.
->BacksChoices

==BacksChoices==
*[More people care for you than you think.]->Care
*[Give Neohumans a chance. Maybe it'll be good to be in that environment.]->Chance

==Chance==
#wait
Zuri: I came here for their paint job, didn't I? I'll give them a shot. I guess I talk a big game, but I'm stuck with a bit of hope in me after all.
->CareChoices

==Hopeful==
Zuri: Or... you have to give up on hope entirely. Every part of my brain is telling me to give up, and something is keeping me from it. I'm totally split down the middle. It's a lot of stress.
->BacksChoices

==Care==
#wait
Zuri: I know. I guess I do. Independence isn't a virtue in this world, it's a bit of a handicap. We probably do need people to get through this.
->CareChoices

==CareChoices==
*[I'm glad to hear that, Zuri.]->Glad

==Glad==
#wait
Zuri: Hey, who died and made you my therapist? I appreciate the chat, but god, I really spilled my guts, huh. Guess I needed to get that out. Thanks, doc. Have a better one than me.
->theEnd

==theEnd==
*[Finish Paint]->Final

==Final==
#last
Zuri leaves, she's looking much lighter than when she walked in, there's hope in her eyes.
->END