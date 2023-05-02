Dungeons and dragons character storage is an API that allows Dungeons and Dragons players to store their characters in an organized manner. Unlike most available products thhis API supports the use of unofficial homebrew classes and subclasses. 

For this project I've simplified the API a bit(originally I had Races table). I also combined the class features into a single table column, since the amount of class features varies from class to class and it was getting difficult to manage.

# Endpoints/HTTP Methods

## GET https://localhost:7192/api/Characters/
		no request body
		Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": [
					{
						"characterName": "Grog",
						"strength": 19,
						"dexterity": 15,
						"constitution": 20,
						"intelligence": 6,
						"wisdom": 10,
						"charisma": 13,
						"charaClassID": "barbarian",
						"charaClass": {
							"charaClassID": "barbarian",
									proficiences: <proficiences>
									classFeatures: <class_features>
							}
						}
					{
						"characterName": "Vax",
						"strength": 17,
						"dexterity": 15,
						"constitution": 20,
						"intelligence": 6
						<etc...>
					]
				}
							
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}
		

## GET https://localhost:7192/api/Characters/<character_name>
		Sample Succesful Response:
			statusCode	200
			statusDescription	"OK"
			characters	
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": [
					{
						"characterName": "Grog",
						"strength": 19,
						"dexterity": 15,
						"constitution": 20,
						"intelligence": 6,
						"wisdom": 10,
						"charisma": 13,
						"charaClassID": "barbarian",
						"charaClass": {
							"charaClassID": "barbarian",
									proficiences: <proficiences>
									classFeatures: <class_features>
						}
					}
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}

## PUT https://localhost:7192/api/Characters/<character_name>
		Sample request body
        {
            "characterName": "Vax",
            "strength": 17,
            "dexterity": 15,
            "constitution": 20,
            "intelligence": 6,
            "wisdom": 10,
            "charisma": 13,
            "charaClassID": "rogue",
            "charaClass": {
                "charaClassID": "rogue",
				"proficiencies": <proficiencies>,
				"classFeatures": <cool_features>
			}
		}
		Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": []
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}

## POST https://localhost:7192/api/Characters/
		Sample request body
        {
            "characterName": "Vax",
            "strength": 17,
            "dexterity": 15,
            "constitution": 20,
            "intelligence": 6,
            "wisdom": 10,
            "charisma": 13,
            "charaClassID": "rogue",
            "charaClass": {
                "charaClassID": "rogue",
				"proficiencies": <proficiencies>,
				"classFeatures": <cool_features>
			}
		}
		Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": []
			}
		Sample  unsuccesful response
			{
				"statusCode": 407,
				"statusDescription": "Conflict",
				"characters": []
			}
## DELETE https://localhost:7192/api/Characters/<character_name>
		No response body
		Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": []
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}

## GET https://localhost:7192/api/CharacterClasses/
		 no request body
		 Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"classes": [
					{
						"charaClassID": "barbarian",
						"proficiencies": <proficiencies>
						"classFeatures": <Features>
					}

					{
						"charaClassID": "bard",
						"proficiencies": <proficiencies>
						"classFeatures": <Features>
					}
				]
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}


## GET https://localhost:7192/api/CharacterClasses/<Class_name>
		 no request body
		 Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"classes": [
					{
						"charaClassID": "barbarian",
						"proficiencies": <proficiencies>
						"classFeatures": <Features>
					}

				]
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}

## PUT https://localhost:7192/api/CharacterClasses/<Class_name>
		Sample body
					{
						"charaClassID": "barbarian",
						"proficiencies": <proficiencies>
						"classFeatures": <Features>
					}
		 Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": []
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}


## POST https://localhost:7192/api/CharacterClasses/
		Sample body
					{
						"charaClassID": "barbarian",
						"proficiencies": <proficiencies>
						"classFeatures": <Features>
					}
		 Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": []
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}


## DELETE https://localhost:7192/api/CharacterClasses/<Class_name>
		 Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": []
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}



## GET https://localhost:7192/api/CharacterSubClasses/
		 no request body
		 Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"classes": [
					{
						"charaSubClassID": "barbarian_path_of_the_berserker",
						"subClassFeatures": <Features>
					}

					{
						"charaClassID": "rogue_thief",
						"subClassFeatures": <Features>
					}
				]
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}


## GET https://localhost:7192/api/CharacterSubClasses/<subClass_name>
		 no request body
		 Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"classes": [
					{
						"charaSubClassID": "barbarian_path_of_the_berserker",
						"subClassFeatures": <Features>
					}
				]
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}


## PUT https://localhost:7192/api/CharacterSubClasses/<subClass_name>
		Sample body
					{
						"charaClassID": "barbarian_path_of_the_berserker",
						"subClassFeatures": <Features>
					}
		 Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": []
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}


## POST https://localhost:7192/api/CharacterSubClasses/
		Sample body
					{
						"charaClassID": "barbarian_path_of_the_berserker",
						"subClassFeatures": <Features>
					}
		 Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": []
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}


## DELETE https://localhost:7192/api/CharacterSubClasses/<SubClassname>
		 Sample Succesful Response:
			{
				"statusCode": 200,
				"statusDescription": "OK",
				"characters": []
			}
		Sample  unsuccesful response
			{
				"statusCode": 404,
				"statusDescription": "Not Found",
				"characters": []
			}



#Constraint

alter table characters add constraint check(substring(characlassid,1,4) = substring(charasubclassid,1,4))

Ensures that classes and sub classes are matched.