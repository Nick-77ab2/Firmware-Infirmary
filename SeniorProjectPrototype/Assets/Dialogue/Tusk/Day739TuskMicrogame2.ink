VAR Mood=0
VAR NextMood=0

->TreatmentChoices
==TreatmentChoices==
*[I would gladly do it, if I could.]->Gladly

==Gladly==
Tusk: I gave him your address, could come down in the next few days. I don't know if he could bring you the pills or just to talk, but it seemed like an actual chance for us. Didn't want to waste it.
->GladlyChoices

==GladlyChoices==
#wait
*[Can we trust him?]->Trust
*[You've never given up the fight.]->Fight

==Fight==
#last
Tusk: Me? Aren't you the one who's been treating Camilla for free for years? It's my fight, I have to be in it. You don't. You could wash your hands of us and go make better money in any other neighborhood. I'm glad you're fighting with us.
->END

==Trust==
#last
Tusk: That's a good question. I don't rightly know. He seemed legit, he's definitely from MEDicil. Is there a chance they're sending psyops to mess with us now that Neohumans is making noise? Sure, there is. But do we have any other chance?
->END