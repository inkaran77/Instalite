# Instalite
Team
- Ganeistan
- Inkaran
- Mohamed

#Contrat d'accès

**Connexion**
----
  Return un token ou une erreur

* **URL**

   http://localhost:5000/Instalite/Connexion/id/password

* **Method:**

  `GET`

*  **URL Params**

   **Required:**

   `Id=[String]`
   `Password=[String]`

* **Data Params**

  None

* **Success Response:**

  * **Code:** 200 <br />
    **Content:** `{ token : "un code generer"}`

* **Error Response:**

  * **Code:** 404 NOT FOUND <br />
    **Content:** `{ error : "L'utilisateur n'existe pas" }`

  OR

  * **Code:** 401 UNAUTHORIZED <br />
    **Content:** `{ error : "Mot de passe erroné" }`

 
**Mot de passe oublié**
---
     
   Return un String

* **URL**

   à remplir par Back-end team

* **Method:**

   GET

    *  **URL Params**

       **Required:**

       `Id=[String]`


    * **Data Params**

      None

    * **Success Response:**

      * **Code:** 200 <br />
        **Content:** `{ String : "Votre mot de passe à été envoyer par mail"}`

    * **Error Response:**

      * **Code:** 404 NOT FOUND <br />
        **Content:** `{ error : "L'utilisateur n'existe pas" }`


    * **Sample Call:**

    team Front-end dois mettre à jour vue.js

      javascript
        $.ajax({
          url: "/users/1",
          dataType: "json",
          type : "GET",
          success : function(r) {
            console.log(r);
          }
        });
        
**Inscription**
----

* **URL**

  http://localhost:5000/Instalite/Inscription/

* **Method:**

   POST

*  **URL Params**

      **Required:**
			`UserId=[String]`
           `First_Name=[String]`
           `Last_Name=[String]`
           `Birth_date=[Date]`
           `Gender=[String]`
           `Email=[String]`
           `Password=[String]`
        	`My_photo=[String]`
           `City=[String]`
           `Country=[String]`
	
	 **Example:**
	 	{
			"UserId ": "Ik",
			"Password":"123",
			"First_Name":"Inkaran",
			"Last_Name": "Thuraiyappah",
			"Gender":"m",
			"Email":"ik@gmail.com",
			"Birth_date": "2000/01/01",
			"City":"Evry",
			"Country":"France"
		}
	
     * **Data Params**

          None

        * **Success Response:**

          * **Code:** 200 <br />
            **Content:** `{ String : "Félicitation, vous êtes bien inscrit"}`

        * **Error Response:**

          
          * **Code:** 400 BADREQUEST <br />
            **Content:** `{ error : "ID déjà  utilisé" }`

        * **Sample Call:**

        team Front-end dois mettre à jour vue.js

          ```javascript
            $.ajax({
              url: "/users/1",
              dataType: "json",
              type : "GET",
              success : function(r) {
                console.log(r);
              }
            });
            ```
