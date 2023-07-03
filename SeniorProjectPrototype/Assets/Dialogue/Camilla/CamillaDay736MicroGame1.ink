VAR Mood=0
VAR NextMood=0
VAR ToGoNext=""

Camilla: God, it's been a long ride. I'm so tired.
->StartChoices

==StartChoices==
*[You've fought this harder than anyone.] -> Fought
*[The memory solving helps?]->Memory

==Fought==
Camilla: I got it so early, it was barely a rumor online when I got sick. I heard some girls were sick in Berlin, I figured we were far enough that we had nothing to worry about. I figured even if it came here, I wouldn't get it. I was obviously wrong.
->Fought_Choices

==Memory==
Camilla: More than anything else. I have days where I can barely put together why I got out of bed, and days where I look at Tusk and can't remember his name. It feels like I'm slipping away. After you do some memory solving, I feel a little more myself.
->Memory_Choices

==Fought_Choices==
#wait
#next
*[But you're still here!]->StillHereChosen
*[You couldn't have known how bad it would get.]->DidNotKnowChosen

==Memory_Choices==
#wait
#next
*[I'm glad I can help, as much as I can.]->GladHelpChosen
*[Does the relief last?]->ReliefChosen


==StillHereChosen==
#last
~ToGoNext="StillHere"
*[Finish Memory Solver]->END

==DidNotKnowChosen==
#last
~ToGoNext="DidNotKnow"
*[Finish Memory Solver]->END

==GladHelpChosen==
#last
~ToGoNext="GladHelp"
*[Finish Memory Solver]->END

==ReliefChosen==
#last
~ToGoNext="Relief"
*[Finish Memory Solver]->END
