select
First_Name,Last_Name,username,user_role,
Street_Address_1,Street_Address_2,City,State,Zip,
Pet_Name, Species,Breed,Size,Personality,
Approval_Status,Accepted,
Date_Time,Number_Of_Attendees
from users
left join Address_User on users.user_id = Address_User.User_ID
left join Address on Address.Address_ID = Address_User.Address_ID
left join Pet on pet.Owner_ID = users.user_id
left join Playdate_Pet on Pet.Pet_ID = Playdate_Pet.Pet_ID
left join Playdate on Playdate_Pet.Playdate_ID = Playdate.Playdate_ID

