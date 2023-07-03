VAR Mood=0
VAR NextMood=0
VAR NewColor=""

YPZ: My idea is that we're not just performers, or "extra-anatomical", or even freaks or whatever else people have called us.
->Start

==Start
#delay
YPZ: I figure we need a name for our little community, something to have pride in, to stand under in opposition to the way everyone else seems to hate us. I came up with Neohumans.
->StartChoices

==StartChoices==
*[Okay, I dig it.]->Dig
*[How do we make this more than an idea?]->More
*[The name is.. not my favorite.]->NotFavorite

==Dig==
YPZ: Right? Like I feel like this is what we've been needing! Like we're such a community, but people don't know that, they see us as like outcasts on the margin. I think if they know us, it'll be harder to not care about us.
->DigChoices

==DigChoices==
*[Do you have any idea of how to start?]->More
*[What's next steps?]->More

==More==
YPZ: I was figuring we could do like, color coords, you know? Those uptown girls who post their fits on their Repo pages always have a piece that matches.
->More2

==More2
#delay
YPZ: It's how you know which clique they're part of. Would be cool if you could paint all our cybernetics the same color.
->MoreChoices

==MoreChoices==
#wait
*[Which color?]->Color

==NotFavorite==
YPZ: I figure that we've been saying "extra-anatomical" for so long just because it's what doctors and mechanics call us. It's so clinical.
->NotFavorite2

==NotFavorite2
#delay
YPZ: Calling ourselves neohumans is like a statement of intent, of politics, of an actual future! We have to imagine a future is possible.
->NotChoices

==NotChoices==
*[I see the vision. So, how do we get started?]->More
*[Aside from a name, what do you want to do?]->More


==Color==
YPZ: >Not totally sure. Orange, maybe? What do you think?
->ColorChoices

==ColorChoices==
*[Orange works fine for me.]->Orange
*[Violet would be striking.]->Violet
*[Green is so versatile.]->Green

==Orange==
#last
#color
~NewColor="Orange"
YPZ: Like a sun rising on a new world. Or comforting warmth, family, that sort of thing, you know I really dig it.
->END


==Violet==
#last
#color
~NewColor="Violet"
YPZ: It's eye-catching! Royal purple, rare and coveted. I love, love, love that.
->END

==Green==
#last
#color
~NewColor="Green"
YPZ: Hmm, yeah, I agree. Green is spring, it's new beginnings, it's growth. It works for us, I think.
->END



