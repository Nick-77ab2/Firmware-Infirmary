VAR Mood=0
VAR NextMood=0
VAR ToGoNext=""

Twinkle: How've you been, doll? Holding up okay in this place? Never see you out and about.
->FirstChoices


==FirstChoices==
*[I've got a lot of work to do.] -> Work
*[I'm doing alright. How've you been?] ->How
*[Keeping it together. You?]->DoingAlright


==Work==
Twinkle: Is it because of that sickness going around? I heard they can't even get in to see docs or mechanics outside of the Night District. I know Camilla has it, and I heard Joselito had it too. Have you seen them? Is it bad?
->WorkChoices

==How==
Twinkle: Been better, been worse... If I'm honest? I've had it up to here with this new generation in the scene. They don't know a thing about respect, they don't know how much has changed in the last ten years. 
->HowChoices

==DoingAlright==
Twinkle: Been better, been worse... If I'm honest? I've had it up to here with this new generation in the scene. They don't know a thing about respect, they don't know how much has changed in the last ten years. 
->DoingAlrightChoices

==DoingAlrightChoices==
#wait
*[That's gotta be frustrating.]->FrustratingChosen
*[Is this about YPZ?]->AboutYPZChosen

==WorkChoices==
#wait
*[Camilla isn't doing too hot.]->NotHotChosen
*[It seems pretty serious]->PrettySeriousChosen

==HowChoices==
#wait
*[That's gotta be frustrating.]->FrustratingChosen
*[Is this about YPZ?]->AboutYPZChosen

==FrustratingChosen==
#last
~ToGoNext="Frustrating"
*[Finish Repairs] ->END

==AboutYPZChosen==
#last
~ToGoNext="AboutYPZ"
*[Finish Repairs]->END

==NotHotChosen==
#last
~ToGoNext="NotHot"
*[Finish Repairs]->END

==PrettySeriousChosen==
#last
~ToGoNext="PrettySerious"
*[Finish Repairs]->END


