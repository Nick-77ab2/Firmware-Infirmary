VAR Mood=0
VAR NextMood=0
VAR NewColor=""

Twinkle: My idea is that we're not only performers, or a scene , or "extra-anatomical" or whatever the doctors are saying.
->Start

==Start
#delay
Twinkle: We need a name for our people, something to stand together under. We're people, of course, but not just people. We're new people, we're Neohumans.
->StartChoices

==StartChoices==
*[Okay, I dig it.]->Dig
*[It's a good name, but just a name.]->More
*[The name is.. not my favorite]->NotFavorite

==Dig==
Twinkle: We're a sort of community, sure. But we don't have each other's backs. We need to codify this, we need everyone to know that community care is how we escape this. If YPZ wasn't alone that night... we need to care for each other.
->DigChoices

==DigChoices==
*[Do you have any idea of how to start?]->More
*[What's next steps?]->More

==More==
Twinkle: Power lies in imagery, learned that years ago in art school. Can you believe I went to art school? Thought I could change the world with beauty.
->More2

==More2
#delay
Twinkle: But that's aside from the point - we need an image. You do paint jobs. If we all had the same vibrant color on our cybernetics, we would be bonded, and formidable.
->MoreChoices

==MoreChoices==
#wait
*[Which color?]->Color

==NotFavorite==
Twinkle: It's from the Greek, darling. We should be sophisticated. We're not lowlifes, we are here to establish culture, not debase it.
->NotChoices

==NotChoices==
*[I see the vision. So, how do we get started?]->More
*[Aside from a name, what do you want to do?]->More


==Color==
Twinkle: It has to be something that is very noticeable. Something shocking, something that inspires a certain feeling in people.
->ColorChoices

==ColorChoices==
*[I think yellow is the most shocking primary.]->Yellow
*[How about red?]->Red
*[White has feelings, I think.]->White

==Yellow==
#last
#color
~NewColor="Yellow"
Twinkle: Well, that's not something I've ever heard before, but it's certainly bright. Maybe a moment of hope? I think a yellow is kind of agitating, could inspire some civic agitation. You've got a good eye for this. We'll do yellow.
->END


==Red==
#color
~NewColor="Red"
Twinkle: Red. I like red. It's rich, in history and in hue. Color of blood, spilled and still flowing. I like red. maybe we take a red with a hit of yellow, just to stay different.
->Red2

==Red2
#delay
#last
Twinkle: We wouldn't want to be too on the nose, now would we? Yes, I agree, a blood orange sort of color would really pop.
->END

==White==
#color
~NewColor="Purple"
Twinkle: It really doesn't. You're spectacularly wrong about that. This sort of thing doesn't come easy to everyone, nothing to be ashamed of!
->White2

==White2
#delay
#last
Twinkle: But white is like pure innocence, no feelings, no viewpoints. You want a color with a viewpoint? Violet's full of specific perspective. Maybe too much. Yes, we'll go with purple.
->END