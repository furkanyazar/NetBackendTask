# Update

Used to get a JWT token for a registered user.

**URL**: `/api/Users`

**Method**: `PUT`

**Auth required**: YES

**Data constraints**

```json
{
  "email": "string",
  "password?": "string",
  "firstName": "string",
  "lastName": "string"
}
```

**Data example**

```json
{
  "email": "new-contact@furkanyazar.dev",
  "password": null,
  "firstName": "Furkan",
  "lastName": "Yazar"
}
```

## Success Response

**Code**: `200 OK`

**Content example**

```json
{
  "firstName": "Furkan",
  "lastName": "Yazar",
  "email": "new-contact@furkanyazar.dev"
}
```

## Error Response

**Condition**: If email is already exists.

**Code**: `400 BAD REQUEST`

**Content**:

```json
{
  "type": "https://example.com/probs/business",
  "title": "Rule violation",
  "status": 400,
  "detail": "User mail already exists.",
  "instance": null
}
```

#### Or

**Condition**: If user not authorized.

**Code**: `401 UNAUTHORIZED`

**Content**:

```json
{
  "type": "https://example.com/probs/authorization",
  "title": "Authorization error",
  "status": 401,
  "detail": "Exception of type 'Core.CrossCuttingConcerns.Exception.Types.AuthorizationException' was thrown.",
  "instance": null
}
```

#### Or

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
