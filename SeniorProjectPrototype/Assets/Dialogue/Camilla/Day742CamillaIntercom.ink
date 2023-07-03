VAR Mood=0
VAR NextMood=0

Camilla: Please.. can you help me?
->StartChoices

==StartChoices
*[Yes, of course, Camilla.]->course
*[Are you alright?]->alright

==course
Camilla: It doesn't help. It doesn't.. Nothing helps. Can you help me? Nothing helps!
->courseChoices


==courseChoices
*[Calm down, I can help.]->Help
*[I have something new.]->new

==Help
Camilla: I don't know. I think I'm lost. I think I need help.
->HelpChoices

==HelpChoices
*[Come in, Camilla.]->Comein
*[I have something that can help.]->new


==new
Camilla: I don't want another. I just want it to be over. I just want to be over. I'm sorry, I do. I'm not even sure who I am anymore.
->newChoices

==newChoices
*[You're Camilla, and I can help you.]->Comein
*[Just come in, let's work through it together.]->Comein

==alright
Camilla: I don't.. I don't think so. I'm not sure, I've just been wandering. I think I'm lost but I'm not sure. I'm looking for something. I'm looking for...
->alrightChoices

==alrightChoices
*[Come in, Camilla.]->Comein
[[Let me help you.]->Comein

==Comein
#last
Camilla enters. She's frail and constantly looking around for something that doesn't exist. She takes the pill you hand her and immediately swallows it. You better do your best today.
->END