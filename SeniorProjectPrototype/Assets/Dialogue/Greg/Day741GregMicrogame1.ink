VAR Mood=0
VAR NextMood=0
VAR ToGoNext=""

Greg: So, the reason I knew to come down here was because of that protest at our office. The reason I wanted to come down here was the illness. I think, somehow, I got it.
->StartChoices

==StartChoices
*[How did you get this cybernetic?]->Cybernetic
*[Is that how you know the cure?]->Cure


==Cybernetic
Greg: I was in an accident. Bad accident. A lot of my organs were lost, I wasn't expected to survive. This cybernetic, as strange as it is, was the quickest way to keep blood flowing to my brain, to keep me alive.
->CyberneticChoices

==Cure
Greg: I wouldn't call it a "cure" exactly. It's a complicated treatment that will likely help. It certainly won't hurt.
->CureChoices

==CyberneticChoices
*[Was it built to last?]->Last
*[Why keep it?]->Keep

==Last
#wait
Greg: No. Not at all. It was initially designed to be a stop gap for my treatment, just something to keep me breathing and conscious before they restore me to my former, normative glory. But, yeah. I got held up.
->LastChoices

==LastChoices
*[Why keep it?]->Keep
*[What does this have to do with a cure?]->WhatCure

==Keep
Greg: It... felt.. different. To feel the wind whistle through your heart, there isn't a feeling like that. A certain emptiness and openness, it draws me into the world.
->Keep2

==Keep2
#delay
Greg: I feel more connected to my world, even the vapid strange world of MEDicil. It's a wild, new, thrilling feeling.
->KeepChoices

==KeepChoices
#wait
*[Was it built to last?]->BuiltLast
*[What does this have to do with a cure?]->WhatCure

==CureChoices==
*[How does it work?]->Work
*[So there's a chance it does nothing?]->Nothing


==Work
#wait
Greg: The theory is that the virus interrupts very basic memory forming connections in the brain. When you have an extra-anatomical attachment, your brain is forming new, base memories throughout your life, adapting to your new and changing body.
->Work2

==Work2==
#delay
Greg: So the drug reinforces and repeats these connections, making it much more difficult for the connection to be interrupted.
->WorkChoices

==WorkChoices
*[So, how did you end up with a cybernetic?]->HowCyber
*[Is there a chance it fails?]->Nothing2


==Nothing==
#wait
Greg: I don't think it'll do nothing. That's very unlikely, at this juncture. It might help very little, it might help a whole lot. Either way, it'll at least be better than nothing.
->NothingChoices

==Nothing2
Greg: I don't think it'll do nothing. That's very unlikely, at this juncture. It might help very little, it might help a whole lot. Either way, it'll at least be better than nothing.
->Nothing2Choices

==NothingChoices
*[How does it work?]->Work
*[So, how did you end up with a cybernetic?]->HowCyber

==Nothing2Choices
*[So, how did you end up with a cybernetic?]->HowCyber

==HowCyber
Greg: I was in an accident. Bad accident. A lot of my organs were lost, I wasn't expected to survive. This cybernetic, as strange as it is, was the quickest way to keep blood flowing to my brain, to keep me alive.
->HowCyberChoices

==HowCyberChoices
*[So they built it to last?]->BuiltLast
*[Why did you keep it?]->WhyKeep


==WhatCure
#last
~ToGoNext="WhatCure"
*[Finish Repairs.]->END

==BuiltLast
#last
~ToGoNext="BuiltLast"
*[Finish Repairs.]->END

==WhyKeep
#last
~ToGoNext="WhyKeep"
*[Finish Repairs.]->END


