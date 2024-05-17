# Distant education
In this repository is presented a service for distant education app.

Basic entities:
1. User
2. Tariff
3. Study Material
4. Course
5. Personal Statistics 

ERD:
<img width="1193" alt="image" src="https://github.com/valeriaotr/distant_education/assets/112973565/61e495e8-89e3-454a-8b4c-c6d6b91356ac">

## List of API methods:
### User
1. POST api/v1/auth -- register
   
Request example:
```json
{
  "firstName": "string",
  "lastName": "string",
  "password": "string"
}
```

Response example: 
```json
{
  "userId": "string"
}
```


2. POST api/v1/user-tariffs -- buy new tariff

Request example:
```json
{
  "userId": "string",
  "tariffId": "string"
}
```

Response example: 
```json
{
  "tariffUserInfoId": "string"
}
```


3. GET api/v1/user-tarrifs/{userId} -- get user tariffs

Request example:
```json
{
  "userId": "string"
}
```

Response example:
```json
{
  [{"tariffId": "string",
  "name": "string",
  "price": "number",
  "validity": "number"
  }]
}
```


4. GET api/v1/user-tarrifs-info/{userId} -- get full user info

Request example:
```json
{
  "userId": "string"
}
```

Response example:
```json
{
  "userId": "string",
  "firstName": "string",
  "lastName": "string",
  "tariffId": "string",
  "statisticsId": "string"
}
```


5. GET api/v1/user-purchases/{userId} -- ger user's purchases info

Request example:
```json
{
  "userId": "string"
}
```

Response example:
```json
{
  "tariffId": "string",
  "purchaseDate": "string",
  "endDate": "string"
}
```


6. GET api/v1/user/{userId}/statistics -- get user's statistics

Request example:
```json
{
  "userId": "string"
}
```

Response example:
```json
{
  "statisticsId": "string",
  "successTasks": "number",
  "CommonAmountOfTasks": "number"
}
```


7. DELETE api/v1/user/delete/{userId} -- delete user

Request example:
```json
{
  "userId": "string"
}
```

8. GET api/v1/user/{userId}/firstName -- get user's first name

Request example:
```json
{
  "userId": "string"
}
```

Response example:
```json
{
  "firstName": "string"
}

```

9. GET api/v1/user/{userId}/lastName -- get user's last name

Request example:
```json
{
  "userId": "string"
}
```

Response example:
```json
{
  "lastName": "string"
}
```


10. PUT api/v1/user/{userId}/updateFirstName -- update user's first name

Request example:
```json
{
  "userId": "string",
  "newFirstName": "string"
}
```

11. PUT api/v1/user/{userId}/updateLastName -- update user's last name

Request example:
```json
{
  "userId": "string",
  "newLastName": "string"
}
```


12. PUT api/v1/user/{userId}/updatePassword -- update user's password

Request example:
```json
{
  "userId": "string",
  "newPassword": "string"
}
```

### Tariff
1. GET api/v1/tariffs/{tariffId} -- get tariff's info

Request example:
```json
{
  "tariffId": "string"
}
```

Response example:
```json
{
  "tariffId": "string",
  "name": "string",
  "price": "number",
  "validity": "number"
}
```


2. GET api/v1/tariffs -- get all the available tariffs

Response example:
```json
{
  [{
  "tariffId": "string",
  "name": "string",
  "price": "number",
  "validity": "number"
  }]
}
```


3. POST api/v1/tariffs/addNewTariff -- add new tariff

Request example:
```json
{
  "name": "string",
  "price": "number",
  "validity": "number"
}
```

Response example:
```json
{
  "tariffId": "string"
}
```


4. DELETE api/v1/tariffs/delete/{tariffId}  -- delete particular tariff

Request example:
```json
{
  "tariffId": "string"
}
```


5. GET api/v1/tariffs/{tariffId}/name -- get tariff's name

Request example:
```json
{
  "tariffId": "string"
}
```

Response example:
```json
{
  "tariffName": "string"
}
```


6. GET api/v1/tariffs/{tariffId}/price -- get tariff's price

Request example:
```json
{
  "tariffId": "string"
}
```

Response example:
```json
{
  "tariffPrice": "number"
}
```


7. GET api/v1/tariffs/{tariffId}/validity -- get tariff's validity

Request example:
```json
{
  "tariffId": "string"
}
```

Response example:
```json
{
  "tariffValidity": "number"
}
```


8. PUT api/v1/tariffs/{tariffId}/updateName -- update tariff's price

Request example:
```json
{
  "tariffId": "string",
  "newName": "string"
}
```


9. PUT api/v1/tariffs/{tariffId}/updatePrice -- update tariff's price

Request example:
```json
{
  "tariffId": "string",
  "newPrice": "number"
}
```


10. PUT api/v1/tariffs/{tariffId}/updateValidity -- update tariff's validity

Request example:
```json
{
  "tariffId": "string",
  "newValidity": "number"
}
```

### Study Material
1. POST api/v1/materials/addNewMaterial -- create new study material

Request example:
```json
{
  "name": "string",
  "type": "string",
  "courseId": "string"
}
```

Response example:
```json
{
  "materialId": "string"
}
```


2. GET api/v1/materials/{materialId} -- get info about study material

Request example:
```json
{
  "materialId": "string"
}
```

Response example:
```json
{
  "materialId": "string",
  "name": "string",
  "type": "string",
  "courseId": "string"
}
```


3. GET api/v1/materials/{materialId}/name -- get study material name

Request example:
```json
{
  "materialId": "string"
}
```

Response example:
```json
{
  "name": "string"
}
```


4. GET api/v1/materials/{materialId}/type -- get study material type

Request example:
```json
{
  "materialId": "string"
}
```

Response example:
```json
{
  "type": "string"
}
```


5. PUT api/v1/materials/{materialId}/updateName -- update study material name

Request example:
```json
{
  "studyMaterialId": "string",
  "newName": "string"
}
```


6. PUT api/v1/materials/{materialId}/updateType -- update study material type

Request example:
```json
{
  "studyMaterialId": "string",
  "newType": "string"
}
```

### Course
1. GET api/v1/courses/{courseId} -- get info about paricular course

Request example:
```json
{
  "courseId": "string"
}
```

Response example:
```json
{
  "courseId": "string",
  "name": "string",
  "amountOfTasks": "number",
  "tariffId": "string"
}
```

2. POST api/v1/courses/addNewCourse -- create new course

Request example:
```json
{
  "name": "string",
  "tasksAmount": "number"
}
```

Response example:
```json
{
  "courseId": "string"
}
```


3. DELETE api/v1/courses/delete/{courseId} -- delete particular course

Request example:
```json
{
  "courseId": "string"
}
```


4. GET api/v1/courses/{courseId}/name -- get course's name

Request example:
```json
{
  "courseId": "string"
}
```

Response example:
```json
{
  "name": "string"
}
```


5. PUT api/v1/courses/{courseId}/updateName -- update course's name

Request example:
```json
{
  "courseId": "string",
  "newName": "string"
}
```


6. PUT api/v1/courses/{courseId}/updateAmountOfTasks -- update course's amount of tasks

Request example:
```json
{
  "courseId": "string",
  "newAmountOfTasks": "string"
}
```


7. GET api/v1/courses/{courseId}/amountOfTasks -- get course's amount of tasks

Request example:
```json
{
  "courseId": "string"
}
```

Response example:
```json
{
  "amountOfTasks": "number"
}
```


### Personal Statistics
1. GET api/v1/statistics/{statisticId} -- get info about personal statistics

Request example:
```json
{
  "statisticsId": "string"
}
```

Response example:
```json
{
  "statisticsId": "string",
  "successTasks": "number",
  "commonAmountOfTasks": "number",
  "percentSuccessTasks": "number"
}
```

2. GET api/v1/statistics/success-tasks/{statisticId} -- get amount of success tasks in particular personal statistics

Request example:
```json
{
  "statisticsId": "string"
}
```

Response example:
```json
{
  "successTasks": "number"
}
```

3. GET api/v1/statistics/common-tasks/{statisticId} -- get amount of all the available tasks in personal statistics

Request example:
```json
{
  "statisticsId": "string"
}
```

Response example:
```json
{
  "commonTasks": "number"
}
```
