VAR Mood=0
VAR NextMood = 0
VAR RepairOneSuccess=0
VAR RepairOneFail=0
VAR RepairSuccess=0
VAR RepairFail=0

->PrevRepairs
==PrevRepairs==
{
-RepairOneSuccess==1:
    ->Repair_1_Success
-RepairOneFail==1:
    ->Repair_1_Fail
-else:
    ->PrevRepairs
}

==Repair_1_Success==
Camilla: It means a lot to me. Even if I only feel a little less sore. Every little bit helps.
->Repair_Success_Wait
    
==Repair_1_Fail==
Camilla:I don't know how I'm gonna get out from under this. Do you think it'll pass?
->Repair_Success1_Wait

==Repair_Success_Wait==
#wait
*[Start the Repairs]->Repair_Success

==Repair_Success1_Wait==
#wait
*[Start the Repairs]->Repair_Success1

==Repair_Success==
*[I'm sure it will, eventually.] ->Repair2Succeeded

==MessUpRepair==
*[I'm not sure, never seen anything like it.] ->Repair2Failed

==Repair_Success1==
*[If anything ever feels off, let me know, okay?] ->Repair2Succeeded

==MessUpRepair1==
*[I don't know if I can solve it, but hopefully this helps.] ->Repair2Failed

==Repair2Succeeded==
Camilla: Tusk and his husband haven't gotten sick while I've been living with them, so I don't think it's contagious like that. I guess we don't know though. I guess I just mean, you didn't have to do this for me, and I do appreciate that.
~Mood+=1
->Repair2FinalChoices

==Repair2Failed==
Camilla: And my memory lately has been bad. Walking into rooms and forgetting why I was there, making a cup of coffee and forgetting about it, so I make another one. Then I've got two coffees, and one is cold and gross! Feel like I'm going crazy.
->Repair2FinalChoices

==Repair2FinalChoices==
{Mood:
-0: *[How do you feel?] ->RepairNotSuccessful
-1: *[How do you feel?] ->RepairMixed
-2: *[How do you feel?] ->RepairSuccessful
}

==RepairNotSuccessful==
Camilla: You did what you could, I can't really ask for anything more, given the situation. Hopefully it'll pass soon.
->RepairNotSuccessfulChoices

==RepairNotSuccessfulChoices==
*[Wish I could've done more.]->BegrudgingThanks

==BegrudgingThanks==
#last
Camilla: Yeah, well. Thanks anyways. You did more than most people would.
->END

==RepairMixed==
Camilla: I definitely feel less sore, my mind fog hasn't cleared and the nausea is absolutely still kicking, but it's much better than nothing.
->RepairMixedChoices

==RepairMixedChoices==
*[Just don't know what we're dealing with yet.]->BegrudgingThanks
*[If you ever need anything else, don't hesitate to ring me.]->Hope

==Hope==
#last
Camilla: If I'm honest with you, I don't know if this will kill me, or it'll pass eventually, but I'm not gonna let it snuff me out easily. You'll see the Mermaid of the Night District perform again, I promise.
->END

==RepairSuccessful==
Camilla: Honestly after Ennix told me I would need uninstallation, a thousand of the worst thoughts went through my head. I don't know if it was the convo or the treatments, but this did make me feel a little better.
->RepairSuccessfulChoices


==RepairSuccessfulChoices==
*[I'm gonna send you home with rejection flu pills, could help.]->Hope