VAR Mood = 0
VAR NextMood=0

Tusk: Hey, it's Tusk. Got a problem with these old things again, wondering if you got a minute for a tune-up and to talk some things over.
*[ANSWER THE INTERCOM] ->IntercomChoice

==IntercomChoice==
*[Yeah, come on up.] ->IntercomChoice1
*[How'd you even manage to push the button to buzz me?] ->IntercomChoice2
*[What do you need to talk about?] ->IntercomChoice3

==IntercomChoice1==
#last
Tusk enters your workshop, and gets into the work station. A tall tank, it allows for total hygiene control even in a semi-basement in the Night District.
->END

==IntercomChoice2==
Tusk: Do you really need to — I used my nose, okay?
->IntercomChoice

==IntercomChoice3==
Tusk: It's about Camila, and her sickness. I don't think it's just rejection flu.
->IntercomChoice