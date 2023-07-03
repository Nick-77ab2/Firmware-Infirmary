VAR Mood=0
VAR NextMood=0

Twinkle: Hi, doc. I know it's been a while since I've come by. I've been doing a lot of thinking. About YPZ. About this disease, about how long we've been fighting, and about how we could get ourselves a chance.
->StartChoices

==StartChoices==
*[What sort of chance?]->Chance
*[Come on down.]->ComeDown

==Chance==
Twinkle: We can't just be silent and disconnected anymore. We're all wildly different, but we're all stuck in this death spiral together. Can't be crabs in a bucket, our only escape is connection.
->ChanceChoices

==ChanceChoices==
*[I'm intrigued, come on down.]->ComeDown

==ComeDown==
#last
Twinkle enters the room with a fire lit behind their eyes, they're more determined than ever.
->END