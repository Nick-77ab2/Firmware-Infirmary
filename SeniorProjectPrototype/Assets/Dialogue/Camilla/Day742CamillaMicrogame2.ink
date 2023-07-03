VAR Mood=0
VAR NextMood = 0
VAR RepairOneSuccess=0
VAR RepairOneFail=0
VAR Current=0

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

==Repair_1_Success
*[Don't stop, what'd she say?]->What
*[This is great, Camilla. Go on!]->Great

==Repair_1_Fail
*[This treatment might work, Camilla.]->Might
*[There's still hope, we have to have hope.]->Hope


==What
Camilla: She said.. "You can remake yourself however you want, you'll still be my daughter." She was angry, she didn't get it, but I thought we would be good.
->What2

==What2
#wait
#delay
#diverts
~Current=0
Camilla: But my father, he didn't approve. I was disgraceful. I was horrific. I was.. wrong. I remember that too now.
->Repair_Wait_Success

==Great
Camilla: I can't remember exactly what she said but she was angry. For sure, angry. I knew she didn't get it. But I remember the feeling when it was installed.
->Great2

==Great2
#wait
#delay
#diverts
~Current=1
Camilla: I looked at myself, and I saw me for the first time. I knew it was different, I knew I was different. But I needed to be myself, no matter how "different" it was.
->Repair_Wait_Success

==Repair_Wait_Success==
non important text
->Repair_Nowhere

==Repair_Nowhere==
How here?
->END

==Repair_Success
{Current:
-0: *[You're remembering!]->Repair_Success2
-1: *[And you deserved that.]->Repair_Success2
}

==MessUpRepair
{Current:
-0: *[You didn't deserve that.]->Repair_Fail
-1: *[Your memory! Is it working?]->Repair_Fail
}

==Repair_Success2
Camilla: I.. I came here! It was the only place that would accept me, I think. I don't remember how I heard about it but.. I was drawn here. And I had a home here, I had other people who looked at me and could see me.
->Repair_Success2_2

==Repair_Success2_2
#delay
Camilla: Not just me, but how hard I worked and how hard it was to get here. My mother didn't hate me, she'd always be family. But I couldn't call her home anymore. I needed a new home, and I found it here.
->SuccessChoices

==SuccessChoices
*[I'm proud you can call the Night District home.]->Home
*[I think it's working, Camilla.]->Working

==Home
Camilla: Me too. Where would I be without Tusk? Wait.. Tusk.. I remember him! God, this stuff really does work?
->Home2

==Home2
#delay
Camilla: I'm still fuzzy but, that felt like the clearest I've been in years. It's been rough, but you never stopped fighting for me, for us. Even when it seemed hopeless.
->HomeChoices

==HomeChoices
*[It was the right thing to do.]->Right
*[Just doing my job.]->Job


==Working
Camilla: It is! Oh my god, I'm clearer than I've been in months, if not years. It's.. it's incredible. I'm still fuzzy but it's night and day compared to even an hour or two ago.
->Working2

==Working2
#delay
Camilla: I didn't think I would make it, but you never stopped fighting for me, for us. Even when it seemed hopeless. Thank you.
->HomeChoices

==Right
#last
Camilla: A lot of other people would've done a whole lot less, a whole lot worse.
->END


==Job
#last
Camilla: And you're damn good at it. 
->END


==Repair_Fail
Camilla: I... I can't. I can't remember anything. Whoever I was when I decided to be this is slipping away if not already gone. I can't think of my mother, my father, anything. They're like old stories to me now. Images and concepts, fading fast.
->Repair_1_Fail

==Might
Camilla: If it worked, I would be happy. But I'm not holding my breath. I don't think this world wants people like me in it. I don't care to fight it any longer. It's okay. It's my time, I think.
->MightChoices

==MightChoices
*[Hold out some hope.]->Hope
*[Don't give in.]->Hope


==Hope
#wait
#last
Camilla: Hope is for the healthy. I don't even have myself anymore. It's okay, finish the repairs, I won't stop you. But I'm not fighting it anymore. Whatever this thing is, it's finished it's job with me. I'm nobody.
->END



