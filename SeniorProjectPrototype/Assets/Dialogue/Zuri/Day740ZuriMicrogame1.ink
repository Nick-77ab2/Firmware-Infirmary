VAR Mood=0
VAR NextMood=0
VAR YPZ=""
VAR Direction = ->Alive
VAR ToGoNext=""

Zuri: I've been working a lot. Thinking a lot. It's getting scary out here. Not sure what we're supposed to do.
->StartChoices

==StartChoices==
*[Isn't that why everyone's organizing?]->Organizing
*[Nothing we can do, I suppose.]->Suppose
*[What do you mean by scary?]->Scary


==Organizing==
Zuri: What does that organizing do? We protest at city hall or at pharmatech companies, but we're not fighting a company or a government, we're fighting a disease. And a disease can't be protested. We don't even know how this thing spreads!
->OrganizingChoices

==OrganizingChoices==
*[Tusk said he had a lead on a treatment.]->Treatment
*[You have to have hope.]->Hope

==Hope==
#wait
Zuri: Do I? I try to. But do I have to? No, I don't think so. I think hope can be earned, and it can be taken away. The odds are so stacked against us, why make a bet on the slim margins?
->HopeChoices

==HopeChoices==
*[The most likely outcome doesn't have to happen.]->Happen
*[We have to imagine the world as hopeful.]->Hopeful

==Suppose==
Zuri: You shouldn't say we. We are not the same. We do not have that much in common. I appreciate what you've done for Camilla, for YPZ, for all of us, but that doesn't make you one of us. You are not we.
->SupposeChoices

==SupposeChoices==
*[Okay, I'm sorry.]->Sorry
*[I've tried my best to help.]->Help

==Scary==
Zuri: Everytime I go up on stage at FEMMEBOT, it doesn't feel like I'm dancing for tips anymore. I can't shake what I've seen happening, it's weighing on me like a ton of bricks.
->Scary2

==Scary2
#delay
Zuri: All of my people, dead and dying, and they all just want to gawk at me, to take in my neohuman body while they still can. Feels like a sick joke. Feels like the end times.
->ScaryChoices

==ScaryChoices==
{
    - YPZ=="alive":
        ~ Direction = ->Alive
    - else:
        ~ Direction = ->Dead
}
*[Is this about what happened to YPZ?]->Direction
*[Is it the dancing? Or something else?]->Dancing

==Sorry==
Zuri: It's just annoying. These kids at a party think they know us because they saw a documentary online or something.

->Sorry2

==Sorry2
#wait
#delay
Zuri: The more people hear about us, the less it seems like they know us. And it's all leading to us being lost to time, a minor subculture for a few decades.
->SorryChoices

==SorryChoices==
*[The most likely outcome doesn't have to happen.]->Happen
[[They might be annoying, but at least they have your back.]->Backs

==Help==
Zuri: I know, I know. It's just.. stressful. Feel like I'm at the end of a rope here, and people can't even talk to us right. The people who care, can't do anything right. And the people that don't, want us all gone.
->HelpChoices

==HelpChoices==
#wait
*[I think you all have each other's backs, at least.]->Backs
*[We have to imagine the world as hopeful.]->Hopeful

==Treatment==
Zuri: Tusk is not a doctor, I'm sorry. He's a sweet guy, he's booked my act many times, and I love him and his husband, but he's not a doctor!
->Treatment2

==Treatment2
#wait
#delay
Zuri: What does he know about treatments? And do we really think any treatment could help Camilla at this point? The girl doesn't know left from right anymore.
->TreatmentChoices

==TreatmentChoices==
*[The most likely outcome doesn't have to happen.]->Happen
*[We have to imagine the world as hopeful.]->Hopeful


==Alive==
Zuri: By an absolute miracle, he survived that horrible night. You helped too, of course, but I thought he was done for. But he lived.
->Alive2

==Alive2
#wait
#delay
Zuri: And now, he gets to watch his world crumble, he can't stand being around me anymore, and all his friends are dying. But he's still YPZ, so he'll still rage, against all odds. With or without me.
->HelpChoices

==Dead==
Zuri: Before the disease, we all thought we would go like that. We'd never say it out loud, but it seemed like our ultimate fate was beaten and bloody in the street.
->Dead2

==Dead2
#wait
#delay
Zuri: It's selfish, but it's nice that I never had to see him fade like that. He was YPZ until the end. And without him, what do we do?
->HelpChoices

==Dancing==
Zuri: I've been a dancer since I left home, since before I even got these cybernetics installed. It's how I make my money, it's how I've survived.

->Dancing2

==Dancing2
#wait
#delay
Zuri: I'm used to the bad parts, I'm used to the way it weighs on you the morning after, how hard relationships can be. But death never entered the conversation. Safety was always on my mind, but death? That's new.
->HelpChoices

==Happen==
#last
~ToGoNext="Happen"
*[Finish Repairs]->END

==Hopeful==
#last
~ToGoNext="Hopeful"
*[Finish Repairs]->END

==Backs==
#last
~ToGoNext="Backs"
*[Finish Repairs]->END


