VAR Mood=0
VAR NextMood=0

Zuri: You don't know me, but you know him. YPZ's been done in bad. I couldn't find him, then I found him. It's not good, it's not good. Help him, please!
->OpeningChoices

==OpeningChoices==
*[Slow down, what happened?]->SlowDown
*[Who are you?]->Who

==SlowDown==
Zuri: He was at his gig, I couldn't find him after, I looked for him all night, found him glitching in the alley behind Taboo's. I don't know who did it but he got beat bad.
->SlowDown2

==SlowDown2
#delay
Zuri: His respirator seems to be barely working, the hospital turned us away. He can barely speak, but he said your name. Please, we don't have time to chat, just let us in.
->SlowDownChoices

==Who==
Zuri: Zuri, I'm his — his friend. He was at the gig, I couldn't find him after, I looked for him all night, found him glitching in the alley behind Taboo's. Please, we don't have time to chat, just let us in.
->WhoChoices

==SlowDownChoices==
*[I can help, bring him down.]->ComeIn
*[He's going to be alright, come quick.]->ComeIn

==WhoChoices==
*[Okay, come on in.]->ComeIn
*[He's going to be alright, come quick.]->ComeIn


==ComeIn==
#last
Zuri: Thank you, thank you, thank you. God, YPZ. Don't you dare die on me. We just got here. We JUST got here.
->END
