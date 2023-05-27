# Add

Used to add a new product.

**URL**: `/api/Products`

**Method**: `POST`

**Auth required**: YES

**Data constraints**

```json
{
  "name": "string",
  "unitPrice": 0.0,
  "unitsInStock": 0
}
```

**Data example**

```json
{
  "name": "New Product",
  "unitPrice": 5,
  "unitsInStock": 15
}
```

## Success Response

**Code**: `200 OK`

**Content example**

```json
{
  "id": 1,
  "name": "New Product",
  "unitPrice": 5,
  "unitsInStock": 15
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

### Or

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
