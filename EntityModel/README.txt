about models and relations between them

//main Tables


Plan :1  <----->  OptionPlan :1
Plan :1  <----->  OfficeOptionPlan :n
Plan :1  <----->  Turn :n
Plan :1  <----->  Plan :n  //for set dependencies - each plan has list of dependent plans


Office :1  <----->  OfficeOptionPlan :1
Office :1  <----->  Turn :n


Citizen :1  <----->  Turn :n


//option Tables


OfficePlanOption :1  <----->  WeeKPlan :1
OfficePlanOption :1  <----->  TurnPool :1


TurnPool :1  <------>  AvailableTurn :n
