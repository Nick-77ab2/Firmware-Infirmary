VAR Mood=0
VAR NextMood=0

???: Hello? Tusk told me to come down here. I'm the guy. He told you about the guy, right? He told you about me?
->StartChoices

==StartChoices==
*[You're from MEDicil?] ->MED
*[Does "the guy" have a name?]->Name

==MED==
Greg: Hey, lower your voice, okay? Not trying to blow our cover here or anything, I'm basically on my lunch break. I don't want to get the feds called down here. Let's just play it cool.
->MEDChoices

==Name==
???: I have a name, but do you really think it's smart to be announcing it to the whole street? I'm not here on strictly above-board business. Ugh, okay look it's G-R-E-G, okay?
->NameChoices

==MEDChoices==
*[Whatever you say.]->Whatever
*[Discretion is key, I get that.]->Discretion


==Whatever==
Greg: This isn't a joke. I got a life, I'm not trying to throw it away for a bunch of nobodies from nowhere. I want to help, but I gotta protect myself first. Can I just come in?
->Yeah

==Discretion==
Greg: Okay, good. I want to do the right thing. But I'm not trying to lose my job over it. Can I come in?
->DiscChoices

==DiscChoices==
*[Yeah, of course.]->OC

==NameChoices==
*[Greg?]->Greg
*[Whatever you say.]->Whatever
*[Discretion is key, I get that.]->Discretion

==Greg==
Greg: Ssshh! Come on! I'm sticking my neck out here!
->MEDChoices

==Yeah==
*[Okay, I'm sorry.]->OC
*[Sure, sure, come on down.]->OC

==OC==
#last
Greg enters the room nervously. After the door closes he relaxes a little. You can't help but notice the hole in his chest.
->END