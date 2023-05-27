# Login

Used to get a JWT token for a registered user.

**URL**: `/api/Auth/Login`

**Method**: `POST`

**Auth required**: NO

**Data constraints**

```json
{
  "email": "string",
  "password": "string"
}
```

**Data example**

```json
{
  "email": "contact@furkanyazar.dev",
  "password": "1234"
}
```

## Success Response

**Code**: `200 OK`

**Content example**

```json
{
  "token": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9",
  "expiration": "2023-05-27T17:36:17.6720951+03:00"
}
```

## Error Response

**Condition**: If email is wrong.

**Code**: `404 NOT FOUND`

**Content**:

```json
{
  "type": "https://example.com/probs/notfound",
  "title": "Not found",
  "status": 404,
  "detail": "User don't exists.",
  "instance": null
}
```

### Or

**Condition**: If password is wrong.

**Code**: `400 BAD REQUEST`

**Content**:

```json
{
  "type": "https://example.com/probs/business",
  "title": "Rule violation",
  "status": 400,
  "detail": "Password don't match.",
  "instance": null
}
```

### Or

**Condition**: Otherwise.

**Code**: `500 INTERNAL SERVER ERROR`

**Content**:

```json
{
  "type": "https://example.com/probs/internal",
  "title": "Internal server error",
  "status": 500,
  "detail": "Internal server error",
  "instance": null
}
```
