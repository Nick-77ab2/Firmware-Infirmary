VAR Mood=0
VAR NextMood=0

->PickedChoices

==PickedChoices==
#wait
*[A new name, a new color, is that a revolution?]->revolution
*[This is nice, YPZ, but people are dying..]->dying


==revolution==
YPZ: It's our first step. You can't have revolution without solidarity, you can't have a movement without people. I want a bunch of us, standing united at the gates of MEDicil, demanding they give us the dignity of treatment.
->revolution2

==revolution2
#wait
#delay
YPZ: I want us at City Hall, painting their doors with blood. We've been quiet, we've been small, and we're dying. We must act.
->GoodLuck

==dying==
YPZ: I know, I know. I'm also trying to plan out a protest. I want a bunch of us, standing in solidarity at the gates of MEDicil, demanding they give us the dignity of treatment.
->dying2

==dying2
#wait
#delay
YPZ:  You're great, of course, but it's insane that you're still the only one looking after us.
->GoodLuck

==GoodLuck==
*[Well, good luck.]->Well

==Well==
#last
YPZ: Thank you. We've gotta find the hope in all this. It's our only choice.
->END