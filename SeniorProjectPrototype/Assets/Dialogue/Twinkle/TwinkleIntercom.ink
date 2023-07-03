VAR Mood=0
VAR NextMood=0

Twinkle: Heya, honey. You've got some spare parts? I'm in need of a tune-up and a fresh coat of paint. Can you fit me in?
->Intercom

==Intercom==
*[Sure, I can.]->Sure
*[Yeah, Twinkle, I have spares from your last tune-up.] ->Spares

==Sure==
#last
Twinkle: Gorgeous, love. I'll be right in.
->END

==Spares==
Twinkle: That's why I like you, you're reliable like that. Not a lot of people are reliable like you are anymore, it's a very unreliable business in an unreliable city.
->SparesChoices

==SparesChoices==
*[Come on in.]->Twinkle

==Twinkle==
#last
Twinkle enters. They look fatigued. The city has definitely gotten to them.
->END