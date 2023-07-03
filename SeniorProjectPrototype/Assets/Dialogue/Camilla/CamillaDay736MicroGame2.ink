VAR Mood=0
VAR NextMood=0

->FalseHope

==FalseHope==
#Go
*[Start Repairs] -> Why

==Why==
How?
->END

==StillHere==
Camilla: For now, but think of all those we've lost. All the freaks and beauties lost, bleeding on the edge. The scene has shrunk to half the size it was a year and a half ago.
->StillHere2

==StillHere2
#delay
Camilla: People die, or they uninstall. I went to the MEDicil clinic, and they recommended I go for uninstallation. I can't imagine it, but what choice do I have?
->StillDidChoices

==DidNotKnow==
Camilla: But I knew who was getting it. It wasn't just anybody, it was us. The dancers, singers, artists, freaks and beauties on the edge.
->DidNotKnow2

==DidNotKnow2
#delay
Camilla: I went to the MEDicil clinic, and they were talking about uninstallation. I can't imagine it, but what choice do I have?
->StillDidChoices

==GladHelp==
Camilla: You're still one of the only mechanics who'll see us. I know Joselito is going to the clinic at MEDicil, but they don't really treat him. Just do tests on him. I only went once, they kept talking about uninstallation.
->StillDidChoices

==Relief==
Camilla: Maybe for a day or two, used to be a week or so, but I guess we can only fight so long. I tried the clinic at MEDicil, they didn't help.
->Relief2

==Relief2
#delay
Camilla: I only went once, but they kept talking about uninstallation. At the very least you get that that's not an option.
->StillDidChoices

==StillDidChoices==
#wait
*[You wouldn't be yourself without your tail!] ->WithoutTail
*[I think you have to consider every possibility.]->EveryPossibility

==WithoutTail==
#last
Camilla: Yeah.. My old life only comes back to me in fits and starts, but when I move my tail? It does feel like home. It's hard to accept your only option is to fight, especially after fighting so so long. I'll probably be seeing you soon.
->END

==EveryPossibility==
#last
Camilla: I guess I do. Can't imagine it. God, maybe I do.
->END