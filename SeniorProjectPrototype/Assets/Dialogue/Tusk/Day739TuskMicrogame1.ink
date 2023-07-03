VAR Mood=0
VAR NextMood=0

Tusk: I was at that protest, for the new Neohumans thing we're doing. We were outside of MEDicil, the pharma-tech company, picketing, chanting, you know the drill.
->StartChoices

==StartChoices==
*[Sure, of course.]->Sure
*[Does that ever work?]->Work


==Sure==
Tusk: We were chanting, I took a break for a minute to get some water, and a guy came out, from the office, named Greg.
->Sure2

==Sure2
#delay
Tusk: Told me he knew that MEDicil had a treatment that helps, but were dragging their feet on getting it out there. Wasting time while people are dying.
->SureChoices

==SureChoices==
*[Did he have proof?]->Proof
*[Why would they waste time?]->Waste

==Proof==
#wait
Tusk: Not exactly, he started spouting off about memory wave isolation, and frequencies, my eyes kinda glassed over. I did mention you though.
->ProofChoices

==ProofChoices==
*[Me? Could I do it?]->Something
*[So it's not just a drug?]->Drug

==Waste==
Tusk: The only people getting sick are us broke sideshows from the other side of the tracks. They'll make more money if they can treat it as soon as the illness jumps up to their tax bracket.
->Waste2

==Waste2
#wait
#delay
Tusk: I don't know the specifics, but it's got to do with trials and drug scheduling.
->WasteChoices

==WasteChoices==
*[What's the treatment?]->Treatment
*[Is it something I could do?]->Something

==Treatment==
#wait
Tusk: I asked Greg that as well, he started spouting off about memory wave isolation, and frequencies, my eyes kinda glassed over. He did mention that, if you had the right equipment and technique, anyone would be able to perform the treatment.
->TreatmentChoices

==Something==
#wait
Tusk: I think so. Kid seemed nervous as can be, but he said that if you had the right equipment and technique, anyone would be able to perform the treatment. I'm not sure if you have the right equipment, but I'm just the messenger.
->TreatmentChoices

==Drug==
#wait
Tusk: Seemed to be a pill and a procedure, a combo deal. The pill will like get your juices flowing correctly so that when you get in there and try to unscramble their head, it would actually stick.
->TreatmentChoices

==Work==
Tusk: I was skeptical, I'll admit it. Felt good to yell, felt good to do something, but I figured it was just a bit of catharsis pointed towards deaf ears. But that's not what happened.
->Work2

==Work2
#delay
Tusk: A guy came out, from the office, named Greg. Told me he knew that MEDicil had a treatment that helps, but were dragging their feet on getting it out there.
->WorkChoices

==WorkChoices==
*[Did he have proof?]->Proof
*[Why would they waste time?]->Waste

==TreatmentChoices==
*[Finish Painting]->Final

==Final==
#last
*[You finish painting the color on Tusk's Cybernetic.]->END