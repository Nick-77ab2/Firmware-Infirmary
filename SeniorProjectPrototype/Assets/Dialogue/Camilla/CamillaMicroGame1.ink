VAR Mood=0
VAR NextMood = 0
VAR RepairSuccess=0
VAR RepairFail=0

Camilla: God, I am so glad to just be seeing somebody about this. Feels like I've been adrift since I got sick. Nobody will help.
->Start_Choices

==Start_Choices==
*[Tell me more about your sickness] -> Life1
*[How has it been?] ->Life1

==Life1
Camilla: It started a few weeks ago. At first it was just nauseau, no appetite, sore all over. Felt like rejection flu, right? But then I kept forgetting things.
->Life

==Life==
#wait
#delay
#diverts
Camilla: Feels like I'm getting stupider by the day. Can't perform because I can't remember the routines, and I'm too weak to do the choreo anyways.
->Repair_Wait_Success

==Repair_Wait_Success==
non important text
->Repair_Nowhere

==Repair_Nowhere==
How here?
->END

==Repair_Success==
*[I get it, impossible situation.] -> Repair_Success2

==MessUpRepair==
*[Lord, that seems tough] -> Repair_Fail2


==Repair_Success2==
#last
Camilla: I don't know how you can help, the other mechanic said I'd need uninstallation. I could never go through with that. But just a general tune-up does seem to be helping? At least I feel way less sore than before.
~Mood+=1
->END

==Repair_Fail2==
#last
Camilla: God, I better not need this uninstallation. Camilla, the mermaid of the Night District, with no tail? Might as well cut me up and and sell me for parts.
->END