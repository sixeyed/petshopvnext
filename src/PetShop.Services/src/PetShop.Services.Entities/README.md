
Run a database (Windows containers):

```
docker run -it -p 1433:1433 sixeyed/petshop-db:1809
```

EF scaffolding:

```
dotnet-ef dbcontext scaffold "server=localhost;database=MSPetShop4;user id=sa;password=DockerCon!!!" Microsoft.EntityFrameworkCore.SqlServer -c PetShopContext
```