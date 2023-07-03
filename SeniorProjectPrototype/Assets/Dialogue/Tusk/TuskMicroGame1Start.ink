VAR Mood = 0
VAR NextMood = 0
VAR RepairSuccess=0
VAR RepairFail=0

Tusk: I'm too damn sentimental about these cybernetics. It's old, barely holding together, have to come by every few months just to be able to use my hands. But they feel like they're a part of me, you know?
->Response

==Response==
#wait
#diverts
*[I understand]->Repair_Success
*[I wouldn't know too much about the hands, but i get where you're coming from.]->Repair_Success
*[Mhmm]->Repair_Success



==Repair_Success==
Tusk: There's been an illness going around. It's not like rejection flu, though. It's much more severe. Camilla has it, and it's causing all sorts of issues with her cybernetics. Poor girl can't even swim. ->RepairOptionsSuccess1

==MessUpRepair==
Tusk: I didn't come here to talk about me though. Camilla's in rough shape. ->RepairOptionsMessUp

==RepairOptionsMessUp==
#last
*[I'm sorry to hear that.] ->END
*[She can't perform] ->END
*[Jesus, that bad] ->END

==RepairOptionsSuccess1==
#last
*[I'm sorry to hear that.] ->END
*[She can't perform?] ->END
*[Jesus, that bad?] ->END