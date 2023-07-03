VAR Mood=0
VAR NextMood=0

Camilla: I feel myself slipping away. Barely know who I am anymore.
->StartChoices

==StartChoices==
*[What do you mean?]->What
*[You're still the Mermaid of the Night District to me.]->Mermaid

==What==
Camilla: I can't really remember what I've done, who I've been, or what my life was. Who am I?
->WhatChoices

==WhatChoices==
#wait
*[I can't answer that for you.]->CantAnswer
[[You were a performer, you were beloved..]->Swim

==CantAnswer==
Camilla: Well, then what am I supposed to do? I can't be nobody. I'm being erased by this virus. Is this it for me?
->CantAnswerChoices

==CantAnswerChoices==
*[Don't give up on me yet.]->EndCall
[[You were somebody, everyone else knows you.]->Swim

==Mermaid==
Camilla: Mermaid of the... what do you mean? Did they call me that? Because of the tail?
->MermaidChoices

==MermaidChoices==
#wait
*[It was the name of your act.]->Act
*[Well, you're a mermaid and this is the Night District.]->Night

==Act==
Camilla: My act? Like a performance? I was an actress?
->ActChoices

==ActChoices==
*[Not an actress, you would dance and swim.]->Swim
*[I wouldn't worry about it.]->EndCall

==Night==
Camilla: Okay, yeah, I guess that does make sense. Everything is just so confusing these days.
->NightChoices

==NightChoices==
*[Well, people still care about you.]->Swim
*[You had a very thrilling life, I can promise you that.]->Swim

==Swim==
Camilla: I wish I could like, remember any of this. It all sounds so wonderful. But it feels as distant to me as a story I read once. I don't know, I don't know.
->SwimChoices

==SwimChoices==
*[Hopefully I can give you some relief.]->EndCall
*[Soon, I think. Or I hope.]->EndCall

==EndCall==
#wait
*[Finish Painting]->Final

==Final==
#last
You finish painting the color on the cybernetic.
->END