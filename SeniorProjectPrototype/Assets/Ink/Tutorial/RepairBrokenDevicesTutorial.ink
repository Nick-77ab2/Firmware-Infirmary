VAR RepairSuccess=0
VAR RepairFail=0

System: Welcome to your first Activity. This is called Repair Broken Devices. In this gamemode you'll be moving some parts into their correct outline. To start let's click on the highlighted component. Tell me when you've done so.
->StartChoices

==StartChoices
*[I've clicked on the highlighted component]->T1

==T1
System: Alright, so now you see the component and the pieces floating off to the side. Try moving one of those pieces. Tell me when you've done so.
->T1Choices

==T1Choices
*[I've moved one of the highlighted pieces]->T2

==T2
System: Did you notice the bar at the top decrease? That's right, you're limited in the amount you can move the pieces. Make sure you move each piece to their respective outlines before the bar runs out! For now though, let's just move one into place.
->T2Choices

==T2Choices
*[I've moved a piece into the correct outline.]->T3

==T3
System: I may be the system, but I'm not all knowing (my programmers are lazy, don't tell them that though). I can't tell if you did or not, but hey, I'll trust you for now.
->T3_2

==T3_2
#delay
System: If you've moved it into place you should hear a snap sound. You might hear a different one to show it's correct or incorrect depending on the game version you're playing on. Press okay to continue onwards.
->T3_2Choices

==T3_2Choices
*[Okay.]->T4

==T4
System: Some important things to note: If you run out of time you have shocked the patient and failed, the day will restart so be careful. If all pieces are on the component, but not in the correct place this will count as a soft fail. Press okay to continue.
->T4Choices

==T4Choices
*[Okay]->T5

==T5
System: A Soft fail is basically an incomplete or messed up repair that the patient can live with (in our case. This doesn't correlate with reality). Different dialogue will display for the next microgame or the rest of the current one.
->T5Choices

==T5Choices
*[That sounds interesting!]->T6

==T6
System: Anyways, lets finish the microgame. From here on out you're alone. I'll display different results depending on if you soft-failed or succeded, so look forwards to it.
->T7

==T7
#wait
#diverts
*[Cool, I'll get started]->Repair_Success

==Repair_Success
System: Hey, you've completed your repair successfully. Where do you go from here? Well, a finish button will appear after this.
->Final

==Final
#delay
#last
System: And there it is. Click it and let's move on to the next activity.
->END

==MessUpRepair
System: Hey, you either failed or soft failed. In the tutorial a hard fail will count as a soft fail for continuity purposes. After this a finish button will appear.
->Final