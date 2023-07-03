VAR Mood=0
VAR NextMood=0

YPZ: Just a general tune-up, nothing fancy. Can't have me sounding flat before a gig, you know?
->FirstChoices

==FirstChoices==
#wait
*[Tell me about this gig.]->TellMe
*[How have you been?]->HowHave

==TellMe==
YPZ: This dancer I met at Femmebot is putting it on, she doesn't usually promote and book her own stuff, but we like hit it off and really vibe creatively.
->TellMe2

==TellMe2
#delay
YPZ: Like she likes my music and wants to get me more out there as like a headliner, you know, not just someone who is performing.
->SecondChoices

==HowHave==
YPZ: I'm good, real good. I feel like I'm entering a new era with my music, you know? I want to get more out there as like an actual headliner, not just someone who happens to be performing at an event.
->HowHave2

==HowHave2
#delay
YPZ: Like the gig tomorrow is my first YPZ event, I'm putting it on at Femmebot with the help of this girl I met.
->SecondChoicesTwo


==SecondChoices==
#wait
*[Are you still seeing Twinkle?]->CallEnd
*[That's great, she sounds good for you.]->SoundsGood

==SecondChoicesTwo==
#wait
*[That's great, she sounds good for you.]->SoundsGood
*[How's the money on a deal like that?]->MoneyDeal

==MoneyDeal==
YPZ: I'm splitting the door fifty-fifty with the venue, and Zuri didn't even ask for any extra! She said she was happy to do it.
->MoneyDealChoices

==MoneyDealChoices==
*[Does Twinkle know about Zuri?] ->CallEnd
*[I don't mean to  pry, but are y'all strictly engaged in... business?]->CallEnd

==SoundsGood==
YPZ: She's gotta be, honestly. Been a minute since I had a real cheerleader in my corner, you know? My energy only really flows in the right direction if I got the right people around me. I'm like a sponge of vibes or something, I don't know that's dumb.
->SoundsGoodChoices

==SoundsGoodChoices==
*[I don't think it's that dumb.]->CallEnd
*[Yea, I agree with you.]->CallEnd

==CallEnd==
#last
You finish doing YPZ's paint.
->DONE