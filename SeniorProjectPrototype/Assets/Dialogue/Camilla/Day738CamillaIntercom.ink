VAR Mood=0
VAR NextMood=0

Camilla: Hi. It's Camilla. I'm just, I'm sorry, I'm back again. It's, it's worse by the day. I think I heard someone talking about you painting us all for the cause?
->Start

==Start
#delay
Camilla: Like as a sign? Or.. not a sign, I mean like.. I don't know. But, if you have the time, I wouldn't mind a paint job.
->StartChoices

==StartChoices==
*[For the Neohumans thing?]->Neo
*[Of course, Camilla, anytime.]->anytime
*[Back already?]->Back


==Neo==
Camilla: Yes! Neohumans! I remember that word! Is that what I am? They've got a name for us now?
->NeoChoices

==NeoChoices==
*[We're trying to get it to catch on.]->catchon
*[Call yourself whatever you'd like, I'm just the mechanic.]->mechanic


==catchon==
Camilla: It's not my favorite, but it's not bad either. Doesn't matter much, I'll forget it in a few minutes anyways.
->catchonChoices

==catchonChoices==
*[Sounds like you're in need of a memory solve.]->anytime
*[I wish I could help more.]->anytime

==mechanic==
Camilla: You're not just the mechanic. You're our mechanic. I probably wouldn't even be here if it wasn't for you.
->mechanicChoices

==mechanicChoices==
*[I just try to do whatever I can to help.]->anytime
*[I'm not a doctor, though. I can only help so much.]->anytime

==anytime==
Camilla: Hopefully you can get my head working long enough that I can get back home.
->anytimeChoices

==anytimeChoices==
*[I hope so too.]->hope

==hope==
#last
Camilla looks very disheveled and out of it. You're no doctor, but you'll do your best.
->END

==Back==
It's embarassing. I got confused, I couldn't remember.. I couldn't remember where I lived. But, I came here. Maybe you can help me remember?
->backChoices

==backChoices==
*[I'll do whatever I can to help.]->anytime
*[This is progressing badly, but I'll try.]->anytime