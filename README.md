# Proyecto_cine
Commit de Darlink

# Programacion de software
# Commandos git 
- git fetch
- git pull

- git add *
- git commit -am "Descripcion"
- git push

- git checkout -- .

- Remover todo lo de github
- Control Panel\User Accounts\Credential Manager

# Commandos dotnet 
- dotnet run
- dotnet restore
- dotnet add package NAME --version NUMBER
- dotnet remove package NAME

- dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.8
- dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.8
- dotnet add package System.Data.SqlClient --version 4.9.0
- dotnet remove package System.Data.SqlClient

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Key]
[NotMapped] ICollection<T>?
[ForeignKey("Nombre")] public T?

using System.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public partial class Conexion : DbContext
{
	public string? StringConnection { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
		optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	}

	public DbSet<Nombre>? Nombre { get; set; }
}

// server=localhost;database=db_facturas;uid=sa;pwd=*!;TrustServerCertificate=true;
// server=localhost;database=db_facturas;Integrated Security=True;TrustServerCertificate=true;

.Include(x => x._Nombre)

conexion.SaveChanges();