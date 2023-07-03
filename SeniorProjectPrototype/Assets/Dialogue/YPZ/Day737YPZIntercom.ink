VAR Mood=0
VAR NextMood=0

YPZ: Hey there. I've been doing a lot of thinking. I've got an idea I'm working on. I owe you a lot, obviously, and I want to get you involved.
->StartChoices

==StartChoices==
*[What sort of idea?]->Idea
*[Come on down.]->ComeDown

==Idea==
YPZ: The short version of it is that we need branding. We need a name, we need a banner for all of us to be under. We've been stepped on for too long.
->IdeaChoices

==IdeaChoices==
*[I'm intrigued, come down.]->ComeDown

==ComeDown==
#last
YPZ Comes in and enters the tank, they're looking much better than they did the last time you saw them.
->END

