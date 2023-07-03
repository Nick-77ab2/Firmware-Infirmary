VAR Mood=0
VAR NextMood=0
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
#wait
#next
#diverts
Zuri: I wanted to show him my world, show him Femmebot where I dance, and.. I don't know. He needed the work, and I wanted our world's to be one.
->Repair_Wait_Success

==Repair_Wait_Success==
non important text
->Repair_Nowhere

==Repair_Nowhere==
How here?
->END

==Repair_1_Fail==
#wait
#next
#diverts
Zuri: Gemini was with him, they wanted to go together, but I was tired. I wanted YPZ to go home with me. We yelled. Well, I yelled. My stupid temper...
->Repair_Wait_Fail

==Repair_Wait_Fail==
non important text
->Repair_Nowhere

==Repair_Success==
*[That's beautiful, Zuri.]->Repair_Success2

==Repair_Success1==
*[It's not your fault]->Repair_Success_Final

==MessUpRepair==
*[You really care about him.]->MessUpRepair2

==MessUpRepair1==
*[You didn't know.]->MessUpRepair_Final


==MessUpRepair_Final==
Zuri: But I knew something. I knew he was drunk, I knew he was sick. He didn't tell anyone that he was sick, but he told me.
->MessUpRepair_Final2

==MessUpRepair_Final2
#delay
Zuri: I knew he had such a long night and I knew I wanted him home with me. I knew I could make him feel bad by arguing, and that's what I did. And now.. now it's our last moment.
->MessUpRepairChoices

==MessUpRepair2==
Zuri: There's nothing scarier than this. Here one moment, on the brink in the next. I know what we have is messy, I know I'm not the perfect girl for him.
->MessUpRepair21

==MessUpRepair21
#delay
Zuri: Honestly I know I might not even be the only girl for him. There's no guidebook for living like us. I just want it all to be okay.
->MessUpRepair2_Choices

==MessUpRepair2_Choices==
#Lives
*[He's in rough shape, but I've got his breathing regulated.] ->YPZLives
*[Well, you're here now. And I've got him stabilized, for now.] ->YPZLives

==Repair_Success2==
Zuri: Beauty's all I had for a long time. He's changing that, though. I thought if I made myself perfect, I wouldn't need anyone else.
->Repair_Success21

==Repair_Success21
#delay
Zuri: But now I see what I was doing. I had to become the person that I've always wanted to be, before I could fit anyone else into mine. How's he doing?
->Repair_Success2_Choices

==Repair_Success2_Choices==
#Lives
*[He's stable and breathing. I think he's going to be alright.]->YPZActuallyLives
*[The respirator's pumping, all vitals are good, YPZ's going to be okay.] ->YPZActuallyLives


==Repair_Success_Final==
Zuri: I didn't do this to him, but I wish I was there. I wish I could've been between them, or at least got him out of the cold.
->Repair_Success_Final1

==Repair_Success_Final1
#delay
Zuri: All night he was there. The sweetest, happiest boy I've ever been with, lying there alone, all night. He doesn't have family anymore, I'm supposed to be there.
->Repair_Success_Choices


==MessUpRepairChoices==
#Dies
*[I'm sorry. I think I've done all I can.] ->YPZDies
*[His breathing isn't coming back. You should say goodbye.] ->YPZDies

==YPZDies==
#last
Zuri: No, no, no, no, no! It's not fair, it's not fair, it's - I'm - I just - all we needed was more time. YPZ, despite it all, I still love you. I'll love you as long as I can bear it. I'm sorry.
->END

==Repair_Success_Choices==
#Lives
*[He's in rough shape, but I've got his breathing regulated.] ->YPZLives
*[Well, you're here now. And I've got him stabilized, for now.] -> YPZLives

==YPZLives==
#last
Zuri: Oh god, I wish we could've gone to a hospital. Please be okay, please let us be okay. We have so much more life to see together. I'm so, so sorry. For everything.
->END

==YPZActuallyLives==
#last
You're a miracle worker, genuinely. We couldn't go anywhere else, but we came to the right place.
->END


