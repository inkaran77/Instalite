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

   `login=[String]`
   `password=[String]`

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
