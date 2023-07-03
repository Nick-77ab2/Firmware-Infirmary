VAR Mood=0
VAR NextMood=0

Camilla: Hi. It's me again.
->StartChoices

==StartChoices==
*[You were here yesterday, Camilla.]->HereYesterday
*[Already?]->Already


==HereYesterday==
Camilla: I don't want to bother you everyday. It's just it's getting worse. I forget everything and the only thing that seems to help is you getting into my memory banks and cleaning things up. You're the only relief I get from this thing.
->ComeDown

==Already==
Camilla: I'm sorry, I know you have other work to do. I just can't keep myself together. The only thing that seems to help is you getting into my memory banks and cleaning things up. You're the only relief I get from this thing.
->ComeDown

==ComeDown==
*[Alright, come on down.]->Last


==Last==
#last
Camilla comes down. She looks way worse than the last time you saw her. There has to be something more you can do.
->END