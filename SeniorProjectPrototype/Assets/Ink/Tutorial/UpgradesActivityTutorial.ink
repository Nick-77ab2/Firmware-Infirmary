VAR RepairSuccess=0
VAR RepairFail=0

System: Now that you're starting to get the hang of these activities, let's move on to a more precise one. The upgrade and replace activity is all about precision, you'll be the doctor of cybernetics!
->StartChoices

==StartChoices
*[Okay, so how do I play?]->T1

==T1
System: Good question. You're given two tools. Your goal is to remove the screws you see on that 3D cybernetic's hatch, move the hatch and then replace the component inside with the one you see in your toolbar. After that it's just replacing everything.
->T1C

==T1C
*[Okay. I'm good to start then]->T2

==T2
System: Good, let's start by left clicking the red screwdriver. Once you've done that you can use the tool on one of the screws by left clicking on that screw. Once you've completed that you should be able to right click in the toolbar to place the screw down.
->T2C

==T2C
*[Cool. I've just finished doing that]->T3

==T3
System: While holding the tools you can click on the dialogue choices, so don't worry about having to drop the tool in order to continue the dialogue. Oh right, to drop the tool you can right click, it cannot be holding a screw, if it is you'll drop the screw first.
->T3C

==T3C
*[I got it, let's continue]->T41

==T41
System: Click on an area next to a screw while holding the screwdriver, or anywhere on the cybernetic. Notice that the green bar; the patient's cybernetic stability, drops. Be careful as when you make a mistake with any tool it can drop.
->T41C

==T41C
*[I better be careful then.]->T4
*[Sounds like fun.]->T4

==T4
System: Anyways, you can now do the same with the rest of the screws. Once you're done, place the screwdriver down and left click the hatch they were on. You can now drag the hatch over to the side and reveal the broken component on the inside.
->T4C

==T4C
*[Oh yea, I see it. It looks pretty broken]->T5
*[Looks normal to me, yep, totally fine.]->T51

==T5
System: The poor patient has been dealing with this for a while. Let's help them. The forceps work exactly the same as the screwdriver. Carefully grab the old component from inside of the cybernetic and place it into the toolbar.
->T5C

==T51
System: ...Right... Anyways the customers trust your judgement, but you also kinda need to do this, so follow my instructions anyways.
->T512

==T512
#delay
System: The forceps work exactly the same as the screwdriver. Carefully grab the old component from inside of the cybernetic and place it into the toolbar.
->T5C

==T5C
*[The old component has been succesfully removed!]->T6
*[I removed the old component, but did some damage...]->T61

==T6
System: Nice, now just grab the new one using the forceps, place it where the old one was and drop the forceps into the toolbar. After that all you need to do is replace the cover and drop the screws back into it in any order. I'll be back when you're done.
->T6C

==T61
System: Hey, that's okay. We're here to learn, no one's perfect. Now just grab the new component using the forceps, place it where the old one was and drop the forceps into the toolbar.
->T62

==T62
*[Mission Complete.]->T63

==T63
System: Cool, after that all you need to do is replace the cover and drop the screws back into it in any order. I'll come back to you once you're done.
->T6C

==T6C
#wait
#diverts
*[Okay.]->Repair_Success

==Repair_Success
System: Congrats, you successfully saved your patient from further issues with the cybernetic. Feel proud, not many can do what you've done!
->Final

==MessUpRepair
System: You've made it here. How'd you get here you ask? Well the patient's cybernetic stability either hit 0 or it was between 20-40%. Be careful next time.
->Final

==Final
#delay
#last
System: That's it for this activity, let's move on to the next one, I think you'll enjoy it!
->END






