# RefreshToken

Used to refresh JWT token for a logged user.

**URL**: `/api/Auth/RefreshToken`

**Method**: `POST`

**Auth required**: NO

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
