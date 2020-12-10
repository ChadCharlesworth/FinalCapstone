--User profile information
select First_Name,Last_Name,user_role,user_id from users where Is_Active = 1 and username = @username

select Address.Address_ID from Address
join Address_User on Address.Address_ID = Address_User.Address_ID
where Address.Is_Active = 1 and User_ID = @userID

select Pet_ID from Pet
where Is_Active = 1 and Owner_ID = @userID

select Playdate.Playdate_ID, Approval_Status, Accepted from Playdate
join Playdate_Pet on Playdate.Playdate_ID = Playdate_Pet.Playdate_ID
where Playdate.Is_Active = 1 and Pet_ID = @petID

--get all users
select First_Name,Last_Name,user_id,user_role,username from users where Is_Active = 1
select Pet_ID from Pet where Owner_ID = @userID where Is_Active = 1

--post new user
update users set First_Name = @firstName, Last_Name = @lastName where user_id = @userID
insert into address (Street_Address_1,Street_Address_2,City,State,Zip) values (@streetAdress1,@streetAddress2,@city,@state,@zip)
insert into Address_User (User_ID,Address_ID) values (@userID,@addressID)

--update(put) user
select Address_ID from Address_User where User_ID = @userID
update users set First_Name = @firstName,Last_Name = @lastName where user_id = @userID
update address set Street_Address_1 = @streetAdress1,Street_Address_2 = @streetAddress2,City = @city,State = @state,Zip = @zip where Address_ID = @addressID

--delete user
select Address_ID from Address_User where User_ID = @userID
update users set Is_Active = 0 where user_id = @userID
update address set Is_Active = 0 where Address_ID = @addressID

--get all addresses
select Address_ID,Street_Address_1,Street_Address_2,City,State,Zip
from address where Is_Active = 1

--post address
insert into address (Street_Address_1,Street_Address_2,City,State,Zip) values (@streetAdress1,@streetAddress2,@city,@state,@zip)
insert into Address_User (User_ID,Address_ID) values (@userID,@addressID)

--update(put) address
update Address set Street_Address_1 = @streetAdress1,Street_Address_2 = @streetAddress2,City = @city,State = @state,Zip = @zip where Address_ID = @addressID

--delete address
update Address set Is_Active = 0 where Address_ID = @addressID

--get all pets
select Pet_ID,Owner_ID,Pet_Name,Species,Breed,Size,Personality from Pet where Is_Active = 1

--post pets
insert into Pet (Owner_ID,Pet_Name,Species,Breed,Size,Personality) values (@userID,@petName,@species,@breed,@size,@personality)

--update(put) pets
update Pet set Pet_Name = @petName,Species = @species,Breed = @breed,Size = @size,Personality = @personality where Pet_ID = @petID

--delete pets
update Pet set Is_Active = 0 where Pet_ID = @petID

--get all playdates
select Playdate_ID, Address_ID,Date_Time,Creator_User_ID,Number_Of_Attendees,Is_Private from Playdate where Is_Active = 1

--post playdates
insert into Playdate (Address_ID,Date_Time,Creator_User_ID,Number_Of_Attendees,Is_Private) values (@addressID,@dateTime,@userID,@numberOfAttendees,@isPrivate)
insert into Playdate_Pet (Playdate_ID,Pet_ID,Approval_Status,Accepted) values (@playdateID,@petID,@approvalStatus,@accepted)

--update(put) playdates
update Playdate set Address_ID = @addressID,Date_Time = @dateTime,Creator_User_ID = @userID,Number_Of_Attendees = @numberOfAttendees,Is_Private = @isPrivate where Playdate_ID = @playdateID
update Playdate_Pet set Playdate_ID = @playdateID,Pet_ID = @petID,Approval_Status = @approvalStatus,Accepted = @accepted where Playdate_ID = @playdateID

--delete playdates
update Playdate set Address_ID = @addressID,Date_Time = @dateTime,Creator_User_ID = @userID,Number_Of_Attendees = @numberOfAttendees,Is_Private = @isPrivate  where Playdate_ID = @playdateID
update Playdate_Pet set Playdate_ID = @playdateID,Pet_ID = @petID,Approval_Status = @approvalStatus,Accepted = @accepted where Playdate_ID = @playdateID


--get all categories
select Category_ID,Category_Name from Forum_Category where Is_Active = 1

--post categories
insert into Forum_Category (Category_Name) values (@categoryName)

--update(put) categories
update Forum_Category set Category_Name = @categoryName where Category_ID = @categoryID

--delete categories
update Forum_Category set Is_Active = 0 where Category_ID = @categoryID

--get all messages
select Message_ID,Category_ID,User_ID,Message_Title,Message_Body from Forum_Message where Is_Active = 1

--post messages
insert into Forum_Message (Category_ID,User_ID,Message_Title,Message_Body) values (@categoryID,@userID,@messageTitle,@messageBody)

--update(put) messages
update Forum_Message set Category_ID = @categoryID,User_ID = @userID,Message_Title = @messageTitle,Message_Body = @messageBody where Message_ID = @messageID

--delete messages
--update(put) messages
update Forum_Message set Is_Active = 0 where Message_ID = @messageID

--get all responses
select Response_ID,User_ID,Message_ID,Response_Body from Forum_Response where Is_Active = 1

--post responses
insert into Forum_Response (User_ID,Message_ID,Response_Body) values (@userID,@messageID,@responseBody)

--update(put) responses
update Forum_Response set User_ID = @userID,Message_ID = @messageID,Response_Body = @responseBody where Response_ID = @responseID

--delete responses
update Forum_Response set Is_Active = 0 where Response_ID = @responseID

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