VAR Mood=0
VAR NextMood=0

Zuri: Hey, heard you were the place to go to get the new paint everyone's got on. I'm not one to miss out on a hot new trend.
->StartChoices

==StartChoices==
*[Sure, just the paint job?]->Paint
*[Are you with Neohumans too?]->Neo

==Paint==
Zuri: I've also got some screws loose, been a minute since I've been repaired, so two birds with one stone, really.
->ComeIn

==Neo==
Zuri: Not exactly. Haven't really protested, haven't been "fighting" like everyone else seems to be. But I am a neohuman, right? Figure I'm entitled to the look, at least.
->ComeIn

==ComeIn==
*[Gotcha, come on in.]->Last

==Last==
#last
Zuri enters the room looking much better than last time.
->END