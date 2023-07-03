VAR RepairSuccess=0
VAR RepairFail=0
VAR Mood = 0
VAR NextMood=0

Tusk: All her performances for the week are cancelled, and unless she can get back in working order, the Mermaid of the Night District is no more. She's been staying with me and my husband since her apartment doesn't have heat.
->Repair2Choices

==Repair2Choices==
*[Heard of her act, never gotten around to seeing it.] ->Repair2Choice1
*[Is it that serious? Doctor's can't help?] ->Repair2Choice2
*[Do you think it's her prostheses?] ->Repair2Choice3

==Repair2Choice1==
Tusk: I'm tellin' you, that girl is incredible in the tank. More at home under the water than on land! Her cybernetics, the tail and the fins, she just dances through the water, and her voice is the cream de la crème. 
->Repair2Choice1part2 

==Repair2Choice1part2==
#delay
Tusk: Hopefully you can come by and see her on stage at Tusk's Nightcap soon. But that's really why I'm here. I was wondering if you would be able to help her out, just this once.
->Repair2ExtraChoices

==Repair2Choice2==
Tusk: Doctors refuse to work on her. They've never understood or respected the performers. They see any cybernetic that isn't mimicking normalcy and write us off as freaks and voyeurs.
->Repair2Choice2part2

==Repair2Choice2part2==
#delay
Tusk: We don't have anyone but each other down here, if I'm honest. That's why I'm here today. I was wondering if you would be able to help her out, just this once.
->Repair2ExtraChoices

==Repair2Choice3==
Tusk: Could be, but it's not your normal rejection flu. It's much more aggressive, it eats away at her. She's never been a big girl, but she's gotten too thin too quick. Of course, she's a big star for me so it's partially business, but I care for the kid. 
->Repair2Choice3part2

==Repair2Choice3part2==
#delay
Tusk: I don't have another person to turn to, I was wondering if you would be able to help her out, just this once.
->Repair2ExtraChoices

==Repair2ExtraChoices==
#wait
*[I don't know what I could do..] ->Repair2ExtraChoice1
*[I'm no doc, but I can certainly try.] ->Repair2ExtraChoice2
*[Of course, anything for y'all.] ->Repair2ExtraChoice3

==Repair2ExtraChoice1==
Tusk: I know. It's a big ask, and it's not exactly fair to you. I wish I could take her to the doc, but with no insurance and her cybernetics, they'd throw her in the street or treat her like garbage.
->Repair2ExtraChoice12

==Repair2ExtraChoice12
#delay
~NextMood+=1
Tusk: Think it over tonight, I'll talk to her. She's desperate for help too.
->FinishRepairs

==Repair2ExtraChoice2==
~NextMood+=2
Tusk: Genuinely, I really appreciate it. If I knew a single doc in the city that would give her the time of day, I wouldn't be bothering you with this. But you're our only shot. I just hope she can get what she needs before it's too late.->FinishRepairs

==Repair2ExtraChoice3==
~NextMood+=3
Tusk: You know, aside from Joselito, you're the only real angel I've ever met. Seriously, you're doing some real charity work. Karma's gonna smile on you for this one. And if karma doesn't, I'll pick up the slack and buy you a drink, eh?->FinishRepairs


==FinishRepairs==
#wait
*[FINISH THE REPAIRS] ->RepairEnd


==MessUpRepair==
#wait
*[FINISH THE REPAIRS] ->RepairEnd

==RepairEnd==
#last
Tusk's hand seems to be in working order now. He steps out of the tube, flexes his fingers, then tips his hat at you. He steps out the workshop's door into the glow of the Night District.
->DONE