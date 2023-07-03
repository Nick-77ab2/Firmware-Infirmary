VAR Mood=0
VAR NextMood=0

YPZ: I know what you mean but it's not like that with Zuri. I'm still with Twinkle, but like I changed and she changed and what we had isn't all the way there. I'm not cheating though. Not at all. 
->ThirdChoices

==ThirdChoices==
*[Okay, if you say so.]->OkayIf
*[Well, does Zuri know about Twinkle?]->WellDoes
*[You could break both their hearts, if this got messy.]->GotMessy


==OkayIf==
YPZ: I feel like we gotta rewrite the rules or something. I'm not a cheater, I'm just trying to find my zone. I want to be creative, get in my flow, but I'm not trying to hurt anyone along the way.
->OkayIfChoices

==OkayIfChoices==
#wait
*[Hey, it's your life. I trust you.]->Trust
*[You do you.]->Trust


==Trust==
#last
YPZ: Yeah, yeah, yeah. Man, I wanted a tune-up and I got a therapy session. You are an absolute trip, you know that?
->END

==WellDoes==
YPZ: She does. I'm not messy like that, I don't need secrets spilling all over the place. I don't have time for all that. And we have like.. mechanic-client confidentiality, right? That's a thing?
->WellDoesChoices

==WellDoesChoices==
*[Sure, mum's the word.]->OkayIf
*[You could break both their hearts, if this got messy.]->GotMessy


==GotMessy==
#wait
YPZ: No hearts to break, you know? No hearts to break, nothing happening. I can know more than one person! That's nothing wrong, there's nothing wrong with that.
->Trust