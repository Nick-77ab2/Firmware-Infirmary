VAR Mood=0
VAR NextMood=0

->FalseHope

==FalseHope==
#Go
*[Start Painting] -> Why

==Why==
How?
->END

==NotHot==
Twinkle: Poor thing. She's a joy, always has been. Of all the people on this scene, she doesn't deserve this. Is there anything to be done?
->NotHotChoices


==PrettySerious==
Twinkle: That's too bad. We sort of had peace, you remember, for a few years. Some folks didn't want the extra-anatomical freaks around, most folks ignored us.
->PrettySerious2

==PrettySerious2
#delay
Twinkle: We had our little corner of the world down here. If this is a plague, just hitting us? Seems like our peace has ended.
->PrettySeriousChoices

==Frustrating==
Twinkle: It's the way things go. I was one of the firsts, you know? Nobody in this forsaken town had gone as far as I had. I knew I would be a sideshow.
->Frustrating2

==Frustrating2
#delay
Twinkle: That's our lot in life. That has to be our role. I want it to be better, but these kids are so loud about it. Big mouths, big consequences.
->FrustratingChoices

==AboutYPZ==
Twinkle: Maybe it is. Why? Do you know something?
->AboutYPZChoices


==NotHotChoices==
#wait
*[Tusk has been taking care of her.]->HowToHelp
*[I just don't know how to help.]->HowToHelp

==PrettySeriousChoices==
#wait
*[I wish I could do more.]->HowToHelp
*[You all deserve peace, I think.] ->Peace
*[Peace never lasts.]->UndeniablyTough

==FrustratingChoices==
#wait
*[YPZ had a big mouth yesterday. Told me about another woman.]->HereYesterday
*[That's undeniably tough.]->UndeniablyTough

==AboutYPZChoices==
#wait
*[Nothing that I shouldn't.]->HereYesterday
*[He was here yesterday.]->HereYesterday

==Peace==
Twinkle: Deserve? You're funny. We don't deserve a thing. Nobody deserves what they get in life. We're here, we're not hiding, and we have to deal with the consequences. That's life.
->PeaceChoices

==PeaceChoices==
*[It doesn't seem fair.]->UndeniablyTough
*[Life doesn't have to be pain.]->UndeniablyTough
*[I suppose you're right.]->UndeniablyTough

==HereYesterday==
Twinkle: That boy can't keep a secret to save his life. I've known about him and Zuri. Our relationship is opening up.
->HereYesterday2

==HereYesterday2
#delay
Twinkle: It's not what I signed up for, but if it was between this and him doing it behind my back, what was I to do? We had different ideas of our future together.
->HereYesterdayChoices

==HereYesterdayChoices==
#wait
*[That's undeniably tough.]->UndeniablyTough

==HowToHelp==
Twinkle: You're here, you're trying. That's more than anybody outside of the Night District has done. We can't know how to fix her, but we can the road less bumpy. It's all we can do. You're doing enough.
->HowToHelpChoices

==HowToHelpChoices==
*[Yeah, I guess so.]->UndeniablyTough
*[It's pretty rough, tough.]->UndeniablyTough

==UndeniablyTough==
Twinkle: Seems to me you've got a heart. Add as many cybernetics as you want, talk as much as you want, you can't change a heart.
->UndeniablyTough2

==UndeniablyTough2
#delay
Twinkle: I've been around this block a thousand times, I could talk your ear off with advice, but all I really should say is you've got to hold onto that heart. Keeps you human.
->CallEnd

==CallEnd==
#wait
*[I always make sure I have my heart on me these days.]->Final
*[I thought I was hiding it quite well.]->Final
*[Thanks, I'll take that advice.]->Final


==Final==
#last
Twinkle smiles and takes their leave.
->DONE