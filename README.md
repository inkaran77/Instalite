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

  à remplir par Back-end team

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

    **Mot de passe oublié**
    ----
      Return un String

    * **URL**

      à remplir par Back-end team

    * **Method:**

      `GET`

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

        **Inscription**
        ----
          Return un String

        * **URL**

          à remplir par Back-end team

        * **Method:**

          `POST`

        *  **URL Params**

           **Required:**

           `First_name=[String]`
           `Last_name=[String]`
           `Birth_date=[Date]`
           `Gender=[String]`
           `Email=[String]`
           `Password=[String]`
           `Id=[String]`
           `My_photo=[String]`
           `City=[String]`
           `Country=[String]`

        * **Data Params**

          None

        * **Success Response:**

          * **Code:** 200 <br />
            **Content:** `{ String : "Félicitation, vous êtes bien inscrit"}`

        * **Error Response:**

          * **Code:** 404 NOT FOUND <br />
            **Content:** `{ error : "L'utilisateur n'existe pas" }`

          OR

          * **Code:** 401 UNAUTHORIZED <br />
            **Content:** `{ error : "Login existe déja" }`

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
