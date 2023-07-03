VAR Mood=0
VAR NextMood=0
VAR RepairSuccess=0
VAR RepairFail=0
VAR Current=0

Camilla: I swallowed the pill. It didn't help. I don't feel like.. I don't think it did anything.
->StartChoices

==StartChoices
*[Hold on, I need to rewire some of your hardware first, I think.]->Rewire
*[Give it time, maybe.]->Time

==Rewire
Camilla: Rewire away. I'm at the end of my line here. I don't think I'm built for this. I can't do this.
->RewireChoices

==RewireChoices
*[You're stronger than you know.]->Stronger
*[Don't give up at the finish line.]->Finish

==Stronger
#wait
#diverts
~Current=2
Camilla: Am I? What about me is strong? I'm frail, I'm crazy, I can't hold down a meal, I'm a fish from the waist down. I've always been pushed to the fringe. I've never been strong. Just myself.
->Repair_Wait_Success

==Finish
#wait
#diverts
~Current=3
Camilla: I can only take so much. I've never been a fighter. And this has been a never-ending fight. Ever since I was little, I would hide or run, not fight. I can't escape it.
->Repair_Wait_Success



==Time
Camilla: I don't have time. Running out of time.
->TimeChoices

==TimeChoices
*[Tell me what you do remember.]->Remember
*[Stay focused on what you still have.]->Focused

==Focused
#wait
#diverts
~Current=1
I don't have anything. I just.. I just ramble and I wander and I can't remember anything. I don't even know my mother's name, I just see her face.
->Repair_Wait_Success

==Remember
#wait
#diverts
~Current=0
Camilla: I.. I don't know. Not really anything. I'm me. I've lived here a while I think. I was an only child. I remember that.
->Repair_Wait_Success

==Repair_Wait_Success==
non important text
->Repair_Nowhere

==Repair_Nowhere==
How here?
->END


==Repair_Success
{Current:
-0: *[Tell me about your childhood.]->Repair_Success2
-1: *[Tell me about your childhood.]->Repair_Success2
-2: *[That's good, talk more about yourself.]->Repair_Success2
-3: *[That's good, talk about your childhood.]->Repair_Success2
}

==MessUpRepair
{Current:
-0: *[That's good, focus on that.]->Repair_Fail
-1: *[Focus on her, tell me about that.]->Repair_Fail
-2: *[It's good to focus on your history.]->Repair_Fail
-3: *[You're doing great, keep going.]->Repair_Fail
}

==Repair_Success2
#last
Camilla: I remember my mother. Her face when she saw my tail. Oh, it could've killed her! She.. hmm.. She said...
->END


==Repair_Fail
#last
Camilla: I... I can't. I can't remember anything. Whoever I was when I decided to be this is slipping away if not already gone. I can't think of my mother, my father, anything. They're like old stories to me now. Images and concepts, fading fast.
->END
