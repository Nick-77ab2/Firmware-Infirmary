VAR Mood=0
VAR NextMood=0
VAR RepairSuccess=0
VAR RepairFail=0

Zuri: He's bad, this is bad, he's in rough shape, this is bad.
->StartChoices

==StartChoices==
*[It's okay, it's okay, calm down. Tell me what happened.] ->WhatHappened
*[I got him now, tell me what's happened.] ->WhatHappened

==WhatHappened==
#wait
#diverts
Zuri: It was a gig, like any other, he performed, he was great, he's always great. We chatted, we danced, he was so - it was like any other day, he was really - he was - it was too normal. Now he's beaten, he's broken.
->Repair_Wait_Success

==Repair_Wait_Success==
non important text
->Repair_Nowhere

==Repair_Nowhere==
How here?
->END


==Repair_Success==
*[Keep talking, I'm listening] ->Repair_Success2

==MessUpRepair==
*[Focus now, tell me more about that night.]->Repair_Fail2

==Repair_Success2==
#last
Zuri: Him on the stage. It's why I loved him, why we fell for each other too fast and too hard. He's energy and love and passion overflowing.
->END

==Repair_Fail2==
#last
Zuri: We were drunk, we were in the alley. God, we argued. It's so stupid now. He wanted to go out, to go to another bar...
->END