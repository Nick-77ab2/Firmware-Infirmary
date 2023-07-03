VAR Mood=0
VAR NextMood=0

YPZ: Yo, what's up? I know I haven't totally paid down my last enhancement, but I really need a tune-up. I got a killer gig tomorrow night and I can't be looking bummy at the time, you know?
->FirstChoices

==FirstChoices==
*[You know I can't say no to you, YPZ.] ->YouKnow
*[You're paying today in full before I do any work.] ->YourePaying

==YouKnow==
YPZ: A sweet face like mine? No, of course you can't! But you're the one working on it so keep it sweet and likeable okay?
->YouKnowChoices


==YouKnowChoices==
*[I couldn't make you uglier.] ->YPZFunny
*[I'll do my worst, just for you.] ->YPZFunny

==YourePaying==
YPZ: Of course I am, I get it, I get it. You're running a respectable business, and you've got no space for freeloaders. Though a little birdie told me Camilla got a free tune-up yesterday.
->YourePayingChoices

==YourePayingChoices==
*[That was different.] ->YPZAnnoys
*[Frankly it's none of your business.] ->YPZAnnoys

==YPZFunny==
YPZ: Oh, you got jokes now? Service and a show, I like it, keeps me on my toes. We good for me to get that work done? The gig's gonna be fire, I swear.
->YPZChoices

==YPZAnnoys==
YPZ: Damn, alright forget I said it. Could you just open up already? It's cold out here.
->YPZChoices

==YPZChoices==
*[Yeah, come on down.]->YPZ

==YPZ==
#last
YPZ Comes down and enters the tube full of the confidence they held in their voice.
->END