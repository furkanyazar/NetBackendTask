<a name="readme-top"></a>

<div align="center">
  <h3 align="center">NetCoreBackend Usage Documentation</h3>
  <p align="center">
    .NET Backend Developer Project Usage Documentation
  </p>
</div>

<!-- TABLE OF CONTENTS -->

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#about-the-usage-documentation">About The Usage Documentation</a></li>
    <li>
      <a href="#open-endpoints">Open Endpoints</a>
      <ul>
        <li><a href="#auth">Auth</a></li>
      </ul>
    </li>
    <li>
      <a href="#endpoints-that-require-authentication">Endpoints That Require Authentication</a>
      <ul>
        <li><a href="#users">Users</a></li>
        <li><a href="#products">Products</a></li>
      </ul>
    </li>
  </ol>
</details>

<!-- ABOUT THE USAGE DOCUMENTATION -->

## About The Usage Documentation

This usage documentation is for the [NetCoreBackend](https://github.com/furkanyazar/NetCoreBackend) project and it is a REST API project. In this documentation you will see how some endpoints work.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- OPEN ENDPOINTS -->

## Open Endpoints

Open endpoints require no Authentication.

### Auth

- [Login](auth/login.md) : `POST /api/Auth/Login`
- [RefreshToken](auth/refreshToken.md) : `POST /api/Auth/RefreshToken`
- [Register](auth/register.md) : `POST /api/Auth/Register`
- [RevokeToken](auth/revokeToken.md) : `POST /api/Auth/RevokeToken`

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ENDPOINTS THAT REQUIRE AUTHENTICATION -->

## Endpoints That Require Authentication

Closed endpoints require a valid JWT token to be included in the header of the request. A JWT token can be obtained from the login endpoint.

### Users

- [GetFromAuth](users/getFromAuth.md) : `GET /api/Users`
- [Update](users/update.md) : `PUT /api/Users`

### Products

- [Add](products/add.md) : `POST /api/Products`
- [Delete](products/delete.md) : `DELETE /api/Products`
- [GetById](products/getById.md) : `GET /api/Products/{id}`
- [GetList](products/getList.md) : `GET /api/Products`
- [Update](products/update.md) : `PUT /api/Products`

<p align="right">(<a href="#readme-top">back to top</a>)</p>
