("mwhelan","kmaddocks","alexisatkinson","bstayte","Zaralus","markgerow","nathan.bedford","gtejeda","Eothain","mthadisena") | foreach-object{
  git remote add $_ "git://github.com/$_/nbdn_prep.git" 
}
