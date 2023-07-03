VAR Mood=0
VAR NextMood=0

Tusk: Hey, I've got something interesting that you might want to hear about.
->StartChoices

==StartChoices==
*[Is it about Neohumans?]->Neo
*[What is it?]->What

==Neo==
Tusk: No, not exactly. It's about a cure - well not a cure, exactly. A possible treatment.
->NeoChoices

==NeoChoices==
*[Come right in, tell me more.]->More

==More==
#last
Tusk enters the room, there's an intense look in his eyes.
->END

==What==
Tusk: Heard something unique through the grapevine. It's about a cure - well not a cure, exactly. A possible treatment.
->NeoChoices
