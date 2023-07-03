
System: Welcome to the Tutorial on First-contact with a patient. This toturial will show you how to interact with the patient through selecting dialogue choices. Click one of the below choices in order to continue.
->Continue

==Continue
*[Hey hey! click me!]->T2
*[Psst. Click this buttom to move onwards.]->T2

==T2
System: When you select a dialogue choice, the next dialogue will display. Sometimes there will be a delay due to dialogue length.
->T2_2

==T2_2
#delay
System: An example of split-text due to dialogue length has occurred. There are also some cases where clicking a different dialogue option will result in more than the baseline information being given to you, so make sure to select different choices sometimes!
->T2Choices

==T2Choices
*[See what information you get from this.]->Info
*[No, no, click this one instead!]->Info2


==Info
System: Did you know that this game was made by a team of 12 people? Cool right?
->Info_2


==Info_2
#delay
System: Another thing to keep in mind is that sometimes the patient has a mood, be careful as some choices might ruin the mood of the patient or a future patient! Though you can purposefully ruin their mood to see the results.
->InfoChoices

==Info2
System: Heh. What the people that selected the other option don't know is that the game was made in about 8 months. Welcome to the cool club.
->Info_2

==InfoChoices
*[Okay.]->Final

==Final
#last
System: Make sure to click that exit button at the top left to finish this dialogue. The next tutorial will start on the tube. Once you click exit the patient will come in and enter the tube. Click the buttons on the tube to continue from there.
->END