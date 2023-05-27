# RevokeToken

Used to revoke refresh token for a logged user.

**URL**: `/api/Auth/RevokeToken`

**Method**: `POST`

**Auth required**: NO

**Data constraints**

```json
"string?"
```

**Data example**

```json
"5Day%2Fm7fjHf0efUDe4TSLfKrdIEcc3NQQgHX%2FwzUwo8%3D"
```

## Success Response

**Code**: `200 OK`

## Error Response

**Condition**: If there is no refresh token.

**Code**: `404 NOT FOUND`

**Content**:

```json
{
  "type": "https://example.com/probs/notfound",
  "title": "Not found",
  "status": 404,
  "detail": "Refresh don't exists.",
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
