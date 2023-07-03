VAR RepairSuccess=0
VAR RepairFail=0

System: This Activity will be a little different. You're given a monitor of the patient's vitals and you must press the serum buttons to increase the relevant vitals (shown next to the buttons in order of vitals).
->T1

==T1
#delay
System: This will be a time attack, so I cannot help you fully through once it starts. If a vital drops below 60 it will turn blue and the the System Shutdown timer will start. This will be the same if the vitals rise over 90, so be careful.
->T1C

==T1C
#next
*[Alright, I'm ready, let's start]->T2

==T2
System: If you've clicked the start button you should see the vitals moving. For now the Stabilizing rate timer should be decreasing, once that hits 0 you've succeeded. There's a winning strategy here, so go ahead and look for it. keep those vitals stable!
->T2C

==T2C
#wait
#diverts
*[Let's do this!]->Repair_Success

==Repair_Success
System: Congratulations, you saved the patient from shock. Each iteration of this activity will be a tad harder than the last, keep that in mind. If you have a good strategy, make sure to use it!
->Final

==MessUpRepair
System: Dang, you shocked the patient. In normal circumstances the day would either restart or the patient would be lost forever. but since we're in a tutorial we'll still be moving forwards and our "patient" is still alive.
->Final

==Final
#delay
#last
System: This is the last type of activity you'll have to deal with. After this just follow the instructions on screen and move on to the real thing. You've passed the exam, congratulations, you are now a certified Cybernetic Mechanic!
->END