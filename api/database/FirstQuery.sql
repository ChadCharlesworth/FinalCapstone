--User profile information
select
First_Name,Last_Name,username,user_role,users.user_id, -- User information
Address.Address_ID, --User information
pet.Pet_ID, --Pet information
Approval_Status,Accepted, --Playdate information
Playdate.Playdate_ID --Playdate information
from users
left join Address_User on users.user_id = Address_User.User_ID
left join Address on Address.Address_ID = Address_User.Address_ID
left join Pet on pet.Owner_ID = users.user_id
left join Playdate_Pet on Pet.Pet_ID = Playdate_Pet.Pet_ID
left join Playdate on Playdate_Pet.Playdate_ID = Playdate.Playdate_ID
where users.Is_Active = 1 and Address.Is_Active = 1 and Playdate.Is_Active = 1

--post new user
insert into users (username,password_hash,salt,user_role,First_Name,Last_Name) values (@username,@passwordHash,@salt,@userRole,@firstName,@lastName)
insert into address (Street_Address_1,Street_Address_2,City,State,Zip) values (@streetAdress1,@streetAddress2,@city,@state,@zip)
insert into Address_User (User_ID,Address_ID) values (@userID,@addressID)

--update(put) user
select Address_ID from Address_User where User_ID = @userID
update users set First_Name = @firstName,Last_Name = @lastName where user_id = @userID --do we want to be able to change passwords/usernames/roles?
update address set Street_Address_1 = @streetAdress1,Street_Address_2 = @streetAddress2,City = @city,State = @state,Zip = @zip where Address_ID = @addressID

--delete user
select Address_ID from Address_User where User_ID = @userID
update users set Is_Active = 0 where user_id = @userID
update address set Is_Active = 0 where Address_ID = @addressID

--get all addresses
select Address_ID,Street_Address_1,Street_Address_2,City,State,Zip
from address where Is_Active = 1

--get all pets
select Pet_ID,Owner_ID,Pet_Name,Species,Breed,Size,Personality from Pet where Is_Active = 1

--get all playdates
select Playdate_ID, Address_ID,Date_Time,Creator_User_ID,Number_Of_Attendees,Is_Private from Playdate where Is_Active = 1

--get all categories
select Category_ID,Category_Name from Forum_Category where Is_Active = 1

--get all messages
select Message_ID,Category_ID,User_ID,Message_Title,Message_Body from Forum_Message where Is_Active = 1

--get all responses
select Response_ID,User_ID,Message_ID,Response_Body from Forum_Response where Is_Active = 1

--Potential information in the Vuex Store
--{
--	ProfileUser: {
--		fn:
--		ln:
--		usn:
--		role:
--		usid:
--		jwt:
--		addressIDs: [arrray of ints of ids]
--		petIDs: [arrray of ints of ids]
--		playdates: [ {
--			pldtid:
--			approval:
--			accepted:
--			},
--			{...}]
--		}
--	Addresses: [Every single address {...},
--				{...}]
--	Pets: [Every single pet {...},{...} ]
--	Playdates: [Every single playdate]

--	Forum...