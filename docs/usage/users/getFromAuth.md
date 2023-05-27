# GetFromAuth

Used to get a JWT token for a registered user.

**URL**: `/api/Users`

**Method**: `GET`

**Auth required**: YES

## Success Response

**Code**: `200 OK`

**Content example**

```json
{
  "firstName": "Furkan",
  "lastName": "Yazar",
  "email": "contact@furkanyazar.dev"
}
```

## Error Response

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
