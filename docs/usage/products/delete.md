# Delete

Used to delete a product owned by user.

**URL**: `/api/Products?Id=1&Permanent=false`

**URL Parameters**:

- `Id=[integer]` where `Id` is the ID of the product.
- `Permanent=[boolean]` where `Permanent` is delete method. if it's `true`, product is completely deleted. Otherwise, it won't deleted, but doesn't appear when called.

**Method**: `DELETE`

**Auth required**: YES

## Success Response

**Code**: `200 OK`

**Content example**

```json
{
  "id": 1,
  "name": "Updated Product",
  "unitPrice": 6.5,
  "unitsInStock": 12
}
```

## Error Response

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
