# Update

Used to update a product owned by user.

**URL**: `/api/Products`

**Method**: `PUT`

**Auth required**: YES

**Data constraints**

```json
{
  "id": 0,
  "name": "string",
  "unitPrice": 0.0,
  "unitsInStock": 0
}
```

**Data example**

```json
{
  "id": 1,
  "name": "Updated Product",
  "unitPrice": 6.5,
  "unitsInStock": 12
}
```

## Success Response

**Code**: `200 OK`

**Content example**

```json
{
  "name": "Updated Product",
  "unitPrice": 6.5,
  "unitsInStock": 12
}
```

## Error Response

**Condition**: If user already has product with the same name.

**Code**: `400 BAD REQUEST`

**Content**:

```json
{
  "type": "https://example.com/probs/business",
  "title": "Rule violation",
  "status": 400,
  "detail": "Product name already exists.",
  "instance": null
}
```

#### Or

**Condition**: If product not found.

**Code**: `404 NOT FOUND`

**Content**:

```json
{
  "type": "https://example.com/probs/notfound",
  "title": "Not found",
  "status": 404,
  "detail": "Product don't exists.",
  "instance": null
}
```

#### Or

**Condition**: If product isn't user's.

**Code**: `401 UNAUTHORIZED`

**Content**:

```json
{
  "type": "https://example.com/probs/authorization",
  "title": "Authorization error",
  "status": 401,
  "detail": "Product isn't yours.",
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
