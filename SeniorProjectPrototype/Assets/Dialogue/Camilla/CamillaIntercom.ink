//Note: Camilla's Mood is based upon Your interactions with Tusk, sections are missing right now, make sure to add them later.VAR myNumber = 5
VAR NextMood=0
VAR Mood=1
{Mood:
- 1: -> Start_Angry
- 2: -> Start_Neutral
- 3: -> Start_Happy
    
}

==Start_Angry==
Camilla: I know you don't want to see me, and frankly, I don't care what your opinion is. Nobody else will help. You're the only mechanic in the Night District. You know us, we've been in and out of this shop for years. And now, we need you. 
-> Angry_Choices

==Angry_Choices==
*[I haven't seen you in here, ever.] -> Angry_Argue
*[Yeah, I get it, I can try.] -> Angry_Agree

==Angry_Argue==
Camilla: I've been seeing Ennix for years. They installed my tail, they increased my breath capacity. I thought they understood me, what I needed. When I went to them for this, they told me to think about uninstallation. I'm telling you, I can't go back.
->Angry_Argue_Choices

==Angry_Argue_Choices==
*[Why'd Ennix want to uninstall your parts?] ->Angry_Argue_More
*[come on in.] -> Invite

==Angry_Argue_More==
Camilla: The only ones who are getting sick are us, anyone with extra-anatomical attachments. I don't know why.
->Angry_Argue_More2

==Angry_Argue_More2
#delay
Camilla:  God is punishing us, or whatever the conspira-sites are saying. Ennix said an uninstallation would probably help. I want to be clear, it is not an option.
-> Angry_Argue_More_Choices


==Angry_Argue_More_Choices==
*[I see. Let me take a look, see what I can do.]->Invite

==Angry_Agree==
Camilla: Ok, good. This thing feels like hell. Can't eat, can barely think, I'm cold all the time. I was getting desperate.
-> Neutral_Invite

==Start_Neutral==
Camilla: Tusk said you might be able to help. I'm really hoping you can.
-> Neutral_Choices

==Neutral_Choices==
*[What's going on?] -> Neutral_Questions
*[He said you were sick.] -> Neutral_Inquire
*[Come on down.] -> Invite


==Neutral_Questions==
Camilla: I'm sick, doc. Can't eat, can barely think, I'm cold all the time. I went to Ennix, they didn't get it. They told me to think about uninstallation.
->Neutral_Questions2

==Neutral_Questions2
#delay
Camilla:  Me, without my tail? I'm telling you, I can't go back. The hospital folks think I'm contagious. You're my only hope.
->Neutral_Invite

==Neutral_Inquire==
Camilla: It's not been good. This thing feels like hell. Can't eat, can barely think, I'm cold all the time. I was getting desperate.
->Neutral_Invite

==Start_Happy==
Camilla: It's Camilla. Tusk sent me your way, he said you'd help. I'm real sick. The hospital folks think I'm contagious.
->Start_Happy2

==Start_Happy2
#delay
Camilla: Can't eat, can barely think, other mechanics told me I'd need uninstallation. Me, without my tail? I'm telling you, I can't go back. You're my only hope.
->Happy_Choices

==Happy_Choices==
*[Of course, I want to help anyway I can.] ->Invite

==Neutral_Invite==
*[Okay, let me take a look at you.] ->Invite

==Invite==
~Mood= 0
#last
Camilla enters your workshop. Up close she definitely looks worse than you originally thought. This might be hard, but you've got a job to do.
->END

