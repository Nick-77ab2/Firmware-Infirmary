VAR Mood=0
VAR NextMood=0

->FalseHope

==FalseHope==
#Go
*[Setup Memory Module] -> Why

==Why==
How?
->END

==BuiltLast
Greg: No. It wasn't built to last at all. It was initially designed to be a stop gap for my treatment, just something to keep me breathing and conscious before they restore me to my former, normative glory. But, yeah. I got held up.
->BuiltLastChoices

==BuiltLastChoices
*[Why did you keep it?]->WhyKeep2
*[It sounds like the best chance we've got.]->Chance

==WhyKeep
Greg: I kept it because...it... felt.. different. To feel the wind whistle through your heart, there isn't a feeling like that.
->WhyKeep3

==WhyKeep3
#delay
Greg: A certain emptiness and openness, it draws me into the world. I feel more connected to my world, even the vapid strange world of MEDicil. It's a wild, new, thrilling feeling.
->WhyKeepChoices

==WhyKeepChoices
*[So they built it to last?]->BuiltLast
*[It sounds like the best chance we've got.]->Chance

==WhyKeep2
Greg: It... felt.. different. To feel the wind whistle through your heart, there isn't a feeling like that. A certain emptiness and openness, it draws me into the world.
->WhyKeep4

==WhyKeep4
#delay
Greg: I feel more connected to my world, even the vapid strange world of MEDicil. It's a wild, new, thrilling feeling.
->WhyKeep2Choices

==WhyKeep2Choices
*[It sounds like the best chance we've got.]->Chance

==WhatCure
Greg: I wouldn't call it a "cure" exactly. It's a complicated treatment that will likely help. It won't hurt, I think. It won't do nothing, that's for sure.
->WhatCureChoices


==WhatCureChoices
*[Well, how does it work?]->WellWork
*[Is there a chance it does nothing?]->ChanceNothing


==WellWork
Greg: The theory is that the virus interrupts very basic memory forming connections in the brain. When you have an extra-anatomical attachment, your brain is forming new, base memories throughout your life, adapting to your new and changing body.
->WellWork2

==WellWork2
#delay
Greg: So the drug reinforces and repeats these connections, making it much more difficult for the connection to be interrupted.
->WellWorkChoices

==WellWorkChoices
*[It sounds like the best chance we've got.]->Chance
*[So, could it fail?]->ChanceNothing2

==ChanceNothing
Greg: I don't think it'll do nothing. That's very unlikely at this juncture. It might help very little, it might help a whole lot. Either way, it'll at least be better than nothing.
->ChanceNothingChoices

==ChanceNothingChoices
*[It sounds like the best chance we've got.]->Chance
*[Well, how does it work?]->WellWork

==ChanceNothing2
Greg: I don't think it'll do nothing. That's very unlikely at this juncture. It might help very little, it might help a whole lot. Either way, it'll at least be better than nothing.
->ChanceNothing2Choices

==ChanceNothing2Choices
*[It sounds like the best chance we've got.]->Chance

==Chance
Greg: I didn't expect this, but, for better or worse, I'm a Neohuman. And.. if I'm honest? I don't think I have a chance without the rest of you.
->Chance2

==Chance2
#delay
#next
#wait
Greg: So, I really hope you hear me, you trust me, and you find a way to take what I know and help all of us. I know I haven't always been one of you, but we can only reach the other side together. I'll leave the pills with you.
->Final

==Final
#last
Greg leaves the pills with you and exits the room in a hurry, looking both ways anxiously when he gets outside.
->END