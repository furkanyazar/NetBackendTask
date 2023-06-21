<a name="readme-top"></a>

<div align="center">
  <h3 align="center">NetCoreBackend</h3>
  <p align="center">
    .NET Backend Developer Project
  </p>
</div>

<!-- TABLE OF CONTENTS -->

<details>
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#about-the-project">About The Project</a></li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->

## About The Project

This project is a REST API project. It was developed with N-Tier architecture. Users can log in after registering to the system. They can add new products, update and delete their own products. They can list their own products and fetch a single product.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->

## Getting Started

This project was developed with .NET 6. It also uses MySQL. Make sure you have the .NET 6 SDK and MySQL is running before using it.

Follow these simple steps to get a local copy up and running.

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/furkanyazar/NetCoreBackend
   ```
2. Change directory
   ```sh
   cd NetCoreBackend
   ```
3. Check the BaseDb connection string in `src/WebAPI/appsettings.Development.json`
   ```json
   "ConnectionStrings": {
     "BaseDb": "server=localhost;User Id=root;password=;database=NetCoreBackend;"
   }
   ```
4. Update database
   _You can use the scripts in `database.sql` and skip this step._
   ```sh
   dotnet ef database update --project src/DataAccess --startup-project src/WebAPI
   ```
5. Run
   ```sh
   dotnet run --project src/WebAPI
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- USAGE EXAMPLES -->

## Usage

[Click here](docs/usage) to go to the usage documentation.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->

## Contact

- Furkan Yazar - [furkanyazar.dev](https://furkanyazar.dev/) - [contact@furkanyazar.dev](mailto:contact@furkanyazar.dev)

Project Link: [https://github.com/furkanyazar/NetCoreBackend](https://github.com/furkanyazar/NetCoreBackend)

<p align="right">(<a href="#readme-top">back to top</a>)</p>
