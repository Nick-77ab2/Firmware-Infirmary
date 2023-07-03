System: Sadly There's no differences generated at the start for the tutorials. Let's focus on what you're seeing here. It's spray painting. On the far left you have the color that is wanted and the color that you currently have.
->Start

==Start
*[Okay. What does this entail?]->T1

==T1
System: On the right of that you have Reg, Green, Blue, White, and Black. Red, Green and Blue add 2 of their respective color to your color's rgb values. White adds 2 to every color, and black removes 2 from every color.
->T1_2

==T1_2
#delay
System: Lastly, you can also reset the paint with the reset paint button. By matching the values at the bottom to within 2 you'll be able to continue to the next part. Let's start with doing that. Press okay when you're done.
->T1Choices

==T1Choices
*[Okay, I've created the color]->Next

==Next
System: Alright, now that you're done, let's click accept color and move on to the painting section.
->NextChoices

==NextChoices
#wait
*[I have accepted the color, now let's get painting.]->Painting

==Painting
#wait
System: Painting is quite simple, you hold left click to spraypaint onto the part, you have a paint bar at the bottom. You cannot fail this game, so if you click accept paint it will stop, or you can choose to run out of paint completely, it's up to you.
->PaintingFinished

==PaintingFinished
*[I have completed the painting]->finish

==finish
#last
System: Alright, let's move on to the next game.
->END
